using ClassLibraryDb;
using ClassLibraryDb.models;
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

namespace Product_maneger_tool
{
    public partial class ProductManeger : Form
    {
        string connectionstring = "server=localhost;database=groenteboer2; user=root; password=";
        public ProductManeger()
        {
            InitializeComponent();
        }

        private void ProductManeger_Load(object sender, EventArgs e)
        {
            //DataRequest("Select * FROM producten");
            LoadData();

        }
        private void LoadData()
        {
            List<Product> products = new List<Product>();
            data db = new data(connectionstring);

            products = db.GetAllProducts();

            FlpProducts.Controls.Clear();

            foreach (Product product in products)
            {
                ProductPanel productPanel = new ProductPanel
                {
                    productdata = product
                };
                productPanel.Click += button_Product_Click;

                FlpProducts.Controls.Add(productPanel);
            }

            Button BtnNew = new Button();
            BtnNew.Text = "+";
            BtnNew.Font = new Font(BtnNew.Font.FontFamily, 16); // 16 is the new font size
            BtnNew.AutoSize = false;
            BtnNew.Size = new Size(200, 200);
            BtnNew.Click += BtnNew_Click;
            FlpProducts.Controls.Add(BtnNew);

        }

        private void button_Product_Click(object sender, EventArgs e)
        {
            ProductPanel product = sender as ProductPanel;
            //MessageBox.Show(product.Product_Id.ToString());
            ProductEditor productEditor = new ProductEditor
            {
                //ProductNaam = product.productdata.ProductNaam,
                //ProductPrijs = product.productdata.ProductPrijs,
                //ProductImage = product.productdata.ProductImage,
                //Product_Id = product.productdata.id
                productdata = product.productdata
            };

            if (productEditor.ShowDialog() == DialogResult.OK)
            {
                //DataRequest("Select * FROM producten");
                LoadData();
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("producten kunnen nog niet toegevoegd worden", "add product | info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductEditor productEditor = new ProductEditor();
            if (productEditor.ShowDialog() == DialogResult.OK)
            {
                //DataRequest("Select * FROM producten");
                LoadData();
            }
        }
    }
}
