using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Product_maneger_tool
{
    public partial class ProductManeger : Form
    {
        public ProductManeger()
        {
            InitializeComponent();
        }

        private void ProductManeger_Load(object sender, EventArgs e)
        {
            DataRequest("Select * FROM producten");
        }
        private void DataRequest(string query)
        {
            FlpProducts.Controls.Clear();
            string connectionstring = "server=localhost;database=groenteboer; user=root; password=";

            using (MySqlConnection conn = new MySqlConnection(connectionstring)) // using = auto-dispose for what the garbage collector ignores
            {
                //conn.Open();
                try//extra voor als de database niet aan staat
                {
                    conn.Open();
                    Console.WriteLine("Verbinding gemaakt!");
                    //MessageBox.Show("Verbinding gemaakt!");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Fout bij verbinden met de database:\n" + ex.Message);
                    return;
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) //andere manier van using nesten
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("geen producten gevonden");
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


                            ProductPanel ProductPanel = new ProductPanel
                            {
                                Product_Id = reader.GetInt32("id"),
                                ProductNaam = reader.GetString("productName"),
                                ProductPrijs = reader.GetDecimal("price"),
                                ProductImage = image,
                                Product_categorie = reader.GetInt16("Category_id")
                            };
                            ProductPanel.Click += button_Product_Click;

                            FlpProducts.Controls.Add(ProductPanel);
                        }
                    }
                }
            }
            Button BtnNew = new Button();
            BtnNew.Text = "+";
            BtnNew.Font = new Font(BtnNew.Font.FontFamily, 16); // 16 is the new font size
            BtnNew.AutoSize = false;
            BtnNew.Size = new System.Drawing.Size(200, 200);
            BtnNew.Click += BtnNew_Click;
            FlpProducts.Controls.Add(BtnNew);

        }

        private void button_Product_Click(object sender, EventArgs e)
        {
            ProductPanel product = sender as ProductPanel;
            //MessageBox.Show(product.Product_Id.ToString());
            ProductEditor productEditor = new ProductEditor
            {
                ProductNaam = product.ProductNaam,
                ProductPrijs = product.ProductPrijs,
                ProductImage = product.ProductImage,
                Product_Id = product.Product_Id
            };

            if (productEditor.ShowDialog() == DialogResult.OK)
            {
                DataRequest("Select * FROM producten");
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("producten kunnen nog niet toegevoegd worden", "add product | info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
