using ClassLibraryDb.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                        foreach (MySqlParameter p in cmd.Parameters)
                            Console.WriteLine($"{p.ParameterName} = {p.Value}");

                        int affectedRows = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{affectedRows} rij(en) geüpdatet.");
                    }
                }
            }
        }
    }
}

// QUERY RECEIPT:

//--Get all products for a specific receipt, with total price and price type text
//SELECT 
//    rp.receipt_ID,                             -- The receipt ID
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
