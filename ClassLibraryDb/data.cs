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

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "Select id, productName, price, Category_id, product_image, priceType FROM producten";
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
                                    PriceType = reader.GetBoolean("priceType"),
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
                    `Category_id` = @category
                WHERE
                    `id` = @id";
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
                    cmd.Parameters.Add(new MySqlParameter("@priceType", MySqlDbType.Int16) { Value = productdata.id });
                    cmd.Parameters.Add(new MySqlParameter("@img", MySqlDbType.Blob) { Value = imageBytes });
                    cmd.Parameters.Add(new MySqlParameter("@category", MySqlDbType.Int32) { Value = productdata.categoryId });

                    foreach (MySqlParameter p in cmd.Parameters)
                        Console.WriteLine($"{p.ParameterName} = {p.Value}");

                    int affectedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{affectedRows} rij(en) geüpdatet.");
                }
            }
        }

    }
}
