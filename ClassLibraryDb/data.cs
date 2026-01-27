using ClassLibraryDb.models;
using ClassLibraryDb.models.dashboard;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ClassLibraryDb
{
    public class data
    {
        string _connectionString;

        public data(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("no or blank connection string");
            }
            else
            {
                _connectionString = connectionString;
            }
        }

        public List<Product> GetAllActiveProducts()
        {
            List<Product> products = new List<Product>();
            string query = "Select id, productName, price, Category_id, product_image, priceType FROM producten WHERE `active` = 1;";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                //conn.Open();
                //try//extra voor als de database niet aan staat
                //{
                //    //MessageBox.Show("Verbinding gemaakt!");
                //}
                //catch (MySqlException ex)
                //{
                //    Console.WriteLine("Fout bij verbinden met de database:\n" + ex.Message);
                //    return null;
                //}

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen producten gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Image image = null;
                                if (!reader.IsDBNull(reader.GetOrdinal("product_image")))
                                {
                                    byte[] imageBytes = (byte[])reader["product_image"];

                                    //MemoryStream ms = new MemoryStream(imageBytes);
                                    //Image = Image.FromStream(ms);

                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        using (var img = Image.FromStream(ms))
                                        {
                                            image = new Bitmap(img);
                                        }
                                    }
                                }

                                Product product = new Product()
                                {
                                    id = reader.GetInt32("id"),
                                    ProductNaam = reader.GetString("productName"),
                                    PriceType = reader.GetInt32("priceType"),
                                    ProductPrijs = reader.GetDecimal("price"),
                                    ProductImage = image,
                                    categoryId = reader.GetInt32("Category_id"),
                                };
                                products.Add(product);

                            }
                        }
                    }
                }

            }
            return products;
        }

        public void UpdateProduct(Product productdata)
        {

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                string query = @"
                UPDATE
                    `producten`
                SET
                    `productName` = @naam,
                    `price` = @price,
                    `product_image` = @img,
                    `priceType` = @priceType,
                    `Category_id` = @category,
                    `active` = @active
                WHERE
                    `id` = @id;";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    Image img = productdata.ProductImage;
                    byte[] imageBytes;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }

                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32) { Value = productdata.id });
                    cmd.Parameters.Add(new MySqlParameter("@naam", MySqlDbType.VarChar) { Value = productdata.ProductNaam });
                    cmd.Parameters.Add(new MySqlParameter("@price", MySqlDbType.Decimal) { Value = productdata.ProductPrijs });
                    cmd.Parameters.Add(new MySqlParameter("@priceType", MySqlDbType.Int16) { Value = productdata.PriceType });
                    cmd.Parameters.Add(new MySqlParameter("@img", MySqlDbType.Blob) { Value = imageBytes });
                    cmd.Parameters.Add(new MySqlParameter("@category", MySqlDbType.Int32) { Value = productdata.categoryId });
                    cmd.Parameters.Add(new MySqlParameter("@active", MySqlDbType.Int16) { Value = productdata.active });

                    //foreach (MySqlParameter p in cmd.Parameters)
                    //    Console.WriteLine($"{p.ParameterName} = {p.Value}");

                    int affectedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{affectedRows} rij(en) geüpdatet.");
                }
            }
        }

        public List<DropDownItem> GetAllCategories()
        {
            List<DropDownItem> categories = new List<DropDownItem>();
            string query = "Select id, name FROM categories";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen categorien gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {

                                DropDownItem category = new DropDownItem()
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = reader.GetString("name"),
                                };
                                categories.Add(category);

                            }
                        }
                    }
                }

            }
            return categories;
        }

        public void AddProduct(Product productdata)
        {

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                string query = @"
                INSERT INTO `producten`(
                    -- `id`,
                    `productName`,
                    `price`,
                    `product_image`,
                    `priceType`,
                    `Category_id`
                )
                VALUES(
                    @naam,
                    @price,
                    @img,
                    @priceType,
                    @category
                )";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    //img logic
                    Image img = productdata.ProductImage;
                    byte[] imageBytes;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }

                    cmd.Parameters.Add(new MySqlParameter("@naam", MySqlDbType.VarChar) { Value = productdata.ProductNaam });
                    cmd.Parameters.Add(new MySqlParameter("@price", MySqlDbType.Decimal) { Value = productdata.ProductPrijs });
                    cmd.Parameters.Add(new MySqlParameter("@priceType", MySqlDbType.Int16) { Value = productdata.PriceType });
                    cmd.Parameters.Add(new MySqlParameter("@img", MySqlDbType.Blob) { Value = imageBytes });
                    cmd.Parameters.Add(new MySqlParameter("@category", MySqlDbType.Int32) { Value = productdata.categoryId });

                    foreach (MySqlParameter p in cmd.Parameters)
                        Console.WriteLine($"{p.ParameterName} = {p.Value}");

                    int affectedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{affectedRows} rij(en) geüpdatet.");
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "Select id, productName, price, Category_id, product_image, priceType, `active` FROM producten;";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen producten gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Image image = null;
                                if (!reader.IsDBNull(reader.GetOrdinal("product_image")))
                                {
                                    byte[] imageBytes = (byte[])reader["product_image"];

                                    //MemoryStream ms = new MemoryStream(imageBytes);
                                    //Image = Image.FromStream(ms);

                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        using (var img = Image.FromStream(ms))
                                        {
                                            image = new Bitmap(img);
                                        }
                                    }
                                }

                                Product product = new Product()
                                {
                                    id = reader.GetInt32("id"),
                                    ProductNaam = reader.GetString("productName"),
                                    PriceType = reader.GetInt32("priceType"),
                                    ProductPrijs = reader.GetDecimal("price"),
                                    ProductImage = image,
                                    categoryId = reader.GetInt32("Category_id"),
                                    active = reader.GetBoolean("active"),
                                };
                                products.Add(product);

                            }
                        }
                    }
                }

            }
            return products;
        }

        public List<DropDownItem> GetAllPriceTypes()
        {
            List<DropDownItem> priceTypes = new List<DropDownItem>();
            string query = "Select id, type FROM pricetype";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen pricetypes gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                DropDownItem PriceType = new DropDownItem()
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = reader.GetString("type"),
                                };
                                priceTypes.Add(PriceType);

                            }
                        }
                    }
                }

            }
            return priceTypes;
        }

        public void AddReceipt(Dictionary<Product, decimal> receipt)
        {

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                //make receipt
                string queryReceipt = @"
                INSERT INTO receipt_metadata(TIMESTAMP)
                VALUES(CURRENT_TIMESTAMP());

                -- get the id of inserted receipt
                SELECT
                    LAST_INSERT_ID()
";
                conn.Open();
                int receiptId;
                using (MySqlCommand cmd = new MySqlCommand(queryReceipt, conn))
                {
                    receiptId = Convert.ToInt32(cmd.ExecuteScalar());
                }


                // add products

                foreach (KeyValuePair<Product, decimal> product in receipt)
                {
                    string queryproducts = @"
                    INSERT INTO receipt_products(
                        receipt_ID,
                        product_ID,
                        amount,
                        price_at_sale,
                        pricetype_at_sale
                    )
                    VALUES(
                        @receiptId,
                        @productId,
                        @amount,
                        @price,
                        @priceType
                    )
";
                    using (MySqlCommand cmd = new MySqlCommand(queryproducts, conn))
                    {

                        cmd.Parameters.Add(new MySqlParameter("@receiptId", MySqlDbType.Int32) { Value = receiptId });
                        cmd.Parameters.Add(new MySqlParameter("@productId", MySqlDbType.Int32) { Value = product.Key.id });
                        cmd.Parameters.Add(new MySqlParameter("@amount", MySqlDbType.Decimal) { Value = product.Value });
                        cmd.Parameters.Add(new MySqlParameter("@price", MySqlDbType.Decimal) { Value = product.Key.ProductPrijs });
                        cmd.Parameters.Add(new MySqlParameter("@priceType", MySqlDbType.Int16) { Value = product.Key.PriceType });

                        //foreach (MySqlParameter p in cmd.Parameters)
                        //    Console.WriteLine($"{p.ParameterName} = {p.Value}");

                        int affectedRows = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{affectedRows} rij(en) geüpdatet.");
                    }
                }
            }
        }

        // raportages and grafieken get:
        public List<AverageAmountSpend> GetAverageAmountSpend()
        {
            List<AverageAmountSpend> averageAmountSpends = new List<AverageAmountSpend>();
            string query = @"
            SELECT AVG(receipt_total) AS AverageSpent
            FROM (
                SELECT receipt_ID, SUM(amount * price_at_sale) AS receipt_total
                FROM receipt_products
                GROUP BY receipt_ID
            ) AS receipt_totals;
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    AverageAmountSpend averageAmountSpend = new AverageAmountSpend()
                    {
                        omschrijving = "gemiddeld bedrag per verkoop(€)",
                        amount = (decimal)cmd.ExecuteScalar()
                    };
                    averageAmountSpends.Add(averageAmountSpend);
                }
                return averageAmountSpends;

            }
        }
        public List<AnnualTurnoverOverview> GetAnnualTurnoverOverview(int year)
        {
            List<AnnualTurnoverOverview> annualTurnoverOverviews = new List<AnnualTurnoverOverview>();
            string query = @"
            SELECT
                COUNT(r.id) AS total_receipts,                           						-- Total amount of receipts
                COALESCE(SUM(rp.amount * rp.price_at_sale), 0) AS total_omzet,         			-- Total money spent 			-- COALESCE means if NULL replace with the value in the input
                COALESCE(AVG(rp.amount * rp.price_at_sale), 0) AS average_spent_per_receipt     -- Average spend per receipt	-- COALESCE means if NULL replace with the value in the input
            FROM receipt_metadata r
            JOIN receipt_products rp ON rp.receipt_ID = r.id -- to get the year)
            WHERE YEAR(r.Timestamp) = @Year
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@Year", MySqlDbType.Int32) { Value = year });
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen producten gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                AnnualTurnoverOverview annualTurnoverOverview = new AnnualTurnoverOverview()
                                {
                                    Totaal_aantal_verkopen = reader.GetInt32("total_receipts"),
                                    Totale_jaaromzet = reader.GetDecimal("total_omzet"),
                                    //Gemiddelde_omzet_per_verkoop = GetAverageAmountSpend()[0].amount
                                    Gemiddelde_omzet_per_verkoop = reader.GetDecimal("average_spent_per_receipt")
                                };
                                annualTurnoverOverviews.Add(annualTurnoverOverview);
                            }
                        }
                    }
                }
                return annualTurnoverOverviews;

            }
        }
        public List<SalesPerProduct> GetSalesPerProduct()
        {
            List<SalesPerProduct> salesPerProducts = new List<SalesPerProduct>();
            string query = @"
            SELECT
                p.productName,
                SUM(`amount`) AS ""totaal_verkocht"",
                SUM(`amount` * `price_at_sale`) AS ""totaal_omzet""
            -- also get price type to display well
            FROM
                `receipt_products` rp
            INNER JOIN producten p ON
                rp.product_ID = p.id
            GROUP BY
                product_ID
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen producten gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                SalesPerProduct salesPerProduct = new SalesPerProduct()
                                {
                                    product = reader.GetString("productName"),
                                    Totaal_Verkocht = reader.GetDecimal("totaal_verkocht"),
                                    Totale_omzet = reader.GetDecimal("totaal_omzet")
                                };
                                salesPerProducts.Add(salesPerProduct);
                            }
                        }
                    }
                }
                return salesPerProducts;

            }
        }
        public List<BusiestDay> GetBusiestDays()
        {
            List<BusiestDay> busiestDays = new List<BusiestDay>();
            string query = @"
            SELECT
                DATE(r.Timestamp) as ""date"",
                SUM(rp.amount * rp.price_at_sale) AS totaal_omzet_dag
            FROM
                receipt_metadata r
            INNER JOIN receipt_products rp ON
                r.id = rp.receipt_ID
            GROUP BY
                DATE(r.Timestamp)
            ORDER BY
                totaal_omzet_dag
            DESC
            LIMIT 5
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen producten gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                BusiestDay busiestDay = new BusiestDay()
                                {
                                    Datum = reader.GetDateTime("date"),
                                    Totale_omzet = reader.GetDecimal("totaal_omzet_dag")
                                };
                                busiestDays.Add(busiestDay);
                            }
                        }
                    }
                }
                return busiestDays;

            }
        }

        public List<TurnoverPerMonth> GetTurnoverPerMonth(int year)
        {
            List<TurnoverPerMonth> TurnoverPerMonths = new List<TurnoverPerMonth>();
            string query = @"
            SELECT
                MONTH(r.Timestamp) AS ""maand"",
                SUM(rp.amount * rp.price_at_sale) AS ""omzet""
            FROM
                receipt_metadata r
            INNER JOIN receipt_products rp ON
                r.id = rp.receipt_ID
            WHERE
                YEAR(r.Timestamp) = @Year
            GROUP BY
                MONTH(r.Timestamp) -- format with .ToString(""MMM"", new CultureInfo(""nl-NL""))
            ORDER BY
                maand ASC;
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@Year", MySqlDbType.Int32) { Value = year });
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen omzet gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                TurnoverPerMonth turnoverPerMonth = new TurnoverPerMonth()
                                {
                                    Month = new DateTime(2000, reader.GetInt16("maand"), 1).ToString("MMM"),
                                    Turnover = reader.GetDecimal("omzet")
                                };
                                TurnoverPerMonths.Add(turnoverPerMonth);
                            }
                        }
                    }
                }
                return TurnoverPerMonths;

            }
        }

        public DailyTurnoverInMonth[] GetDailyTurnoverInMonth(int year, int month)
        {
            DailyTurnoverInMonth[] AllDays = new DailyTurnoverInMonth[DateTime.DaysInMonth(year, month)];
            string query = @"
            SELECT
                DAY(r.Timestamp) AS dag,
                SUM(rp.amount * rp.price_at_sale) AS totaal_omzet_dag
            FROM
                receipt_metadata r
            INNER JOIN receipt_products rp ON
                r.id = rp.receipt_ID
            WHERE
                YEAR(r.Timestamp) = @Year AND MONTH(r.Timestamp) = @Month
            GROUP BY
                DAY(r.Timestamp)
            ORDER BY
                dag ASC
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@Year", MySqlDbType.Int32) { Value = year });
                    cmd.Parameters.Add(new MySqlParameter("@Month", MySqlDbType.Int32) { Value = month });
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen omzet gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {
                            Dictionary<int, decimal> days = new Dictionary<int, decimal>();
                            while (reader.Read())
                            {
                                //get all days
                                days[reader.GetInt16("dag")] = reader.GetDecimal("totaal_omzet_dag");
                            }
                            //make list with all days 0
                            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
                            {
                                AllDays[day - 1] = new DailyTurnoverInMonth
                                {
                                    day = day,
                                    Turnover = 0
                                };
                            }

                            //replace all days that are not 0 with the right value
                            foreach (KeyValuePair<int, decimal> day in days)
                            {
                                AllDays[day.Key - 1] = new DailyTurnoverInMonth
                                {
                                    day = day.Key,
                                    Turnover = day.Value
                                };

                                //while (reader.Read())
                                //{
                                //    int day = reader.GetInt16("dag");
                                //    AllDays[day - 1].Turnover = reader.GetDecimal("totaal_omzet_dag");
                                //}

                            }

                        }
                    }
                }
                return AllDays;

            }
        }

        public List<CategoryTurnover> GetCategoryTurnovers()
        {
            List<CategoryTurnover> categoryTurnovers = new List<CategoryTurnover>();
            string query = @"
            SELECT
                c.name AS categorie,
                SUM(rp.amount * rp.price_at_sale) AS totaal_verkocht
            FROM
                categories c
            LEFT JOIN producten p ON
                p.Category_id = c.id
            LEFT JOIN receipt_products rp ON
                rp.product_ID = p.id
            GROUP BY
                c.id,
                c.name
            ORDER BY
                c.id ASC;
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen omzet gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {

                            while (reader.Read())
                            {
                                CategoryTurnover category = new CategoryTurnover()
                                {
                                    CategoryName = reader.GetString("categorie"),
                                    Turnover = reader.GetDecimal("totaal_verkocht")
                                };
                                categoryTurnovers.Add(category);
                            }

                        }
                    }
                }
                return categoryTurnovers;

            }
        }

        public List<BestSellingProduct> GetBestSellingProducts()
        {
            List<BestSellingProduct> bestSellingProducts = new List<BestSellingProduct>();
            string query = @"
            SELECT
                p.productName,
                sum(rp.amount) as ""amount""
            FROM
                producten p
            inner JOIN receipt_products rp ON
                rp.product_ID = p.id
            GROUP BY
                p.productName
            ORDER BY
                amount
            DESC
            LIMIT 5;
";
            using (MySqlConnection conn = new MySqlConnection(_connectionString)) // using = auto-dispose for what the garbage collector ignores
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("geen omzet gevonden");
                            //LblOutput.Text = "Null";
                        }
                        else
                        {

                            while (reader.Read())
                            {
                                BestSellingProduct product = new BestSellingProduct()
                                {
                                    ProductName = reader.GetString("productName"),
                                    amount = reader.GetDecimal("amount")
                                };
                                bestSellingProducts.Add(product);
                            }

                        }
                    }
                }
                return bestSellingProducts;

            }
        }
    }
}

// QUERY RECEIPT:

//--Get all products for a specific receipt, with total price and price type text
//SELECT
//    rp.receipt_ID,                             --The receipt ID
//    p.productName AS Product,                  -- Product name instead of product ID
//    rp.amount,                                 -- Quantity purchased
//    rp.price_at_sale AS PricePerUnit,          -- Price at the time of sale
//    pt.type AS PriceType,                  -- Price type text (from price_type table)
//    (rp.price_at_sale * rp.amount) AS LineTotal -- Total price for this line item
//FROM 
//    receipt_products rp
//    LEFT JOIN producten p ON rp.product_ID = p.id        -- Join to get product info
//    LEFT JOIN pricetype pt ON rp.pricetype_at_sale = pt.ID  -- Join to get price type text
//WHERE 
//    rp.receipt_ID = 1; --Filter by the specific receipt

//SELECT SUM(rp2.price_at_sale * rp2.amount) AS TotalPrice
//     FROM receipt_products rp2 
//     WHERE rp2.receipt_ID = 1 
