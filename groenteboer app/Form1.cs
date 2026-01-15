using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryDb;
using ClassLibraryDb.models;
//using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;

namespace groenteboer_app
{
    public partial class FormGroenteboer : Form
    {
        private string connectionstring = "server=localhost;database=groenteboer2; user=root; password=";
        private decimal _total;

        decimal total
        {
            get { return _total; }
            set
            {
                _total = value;
                LblTotal.Text = $"totaal:{_total:C2}";
                if (value > 0)
                {
                    BtnPay.Enabled = true;
                }
            }
        }


        Dictionary<ProductPanel, decimal> BonData; //decimal is accurate then a float or double(64 bit float)
        public FormGroenteboer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            total = 0;
            BonData = new Dictionary<ProductPanel, decimal>();
            selectableButton1.Buttons = new List<string> { "1X", "2X", "3X", "5X", };
        }

        void loadData()
        {
            flowLayoutPanelGroente.Controls.Clear();
            flowLayoutPanelFruit.Controls.Clear();
            flowLayoutSmoothie.Controls.Clear();
            flowLayoutPanelAndere.Controls.Clear();


            
            List<Product> products = new List<Product>();
            data db = new data(connectionstring);

            products = db.GetAllActiveProducts();
            foreach (Product product in products)
            {
                ProductPanel productPanel = new ProductPanel
                {
                    productdata = product
                };
                productPanel.Click += button_Product_Click;
                FlowLayoutPanel flowLayoutPanel;
                if (productPanel.productdata.categoryId == 1)
                {
                    flowLayoutPanel = flowLayoutPanelGroente;
                }
                else if (productPanel.productdata.categoryId == 2)
                {
                    flowLayoutPanel = flowLayoutPanelFruit;
                }
                else if ((productPanel.productdata.categoryId == 3))
                {
                    flowLayoutPanel = flowLayoutSmoothie;
                }
                else if (productPanel.productdata.categoryId == 4)
                {
                    flowLayoutPanel = flowLayoutPanelAndere;
                }
                else { flowLayoutPanel = flowLayoutPanelAndere; }
                flowLayoutPanel.Controls.Add(productPanel);

            }

        }

        private void button_Product_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectableButton1.SelectedButton.Text);
            ProductPanel product = (ProductPanel)sender;
            //MessageBox.Show(product.ProductPrijs);
            //ListBoxBon.Items.Add($"{product.ProductNaam} | {product.ProductPrijs:C2}");
            //total += product.ProductPrijs;
            decimal amount;
            if (product.productdata.PriceType == 2)
            {
                Numpad numpad = new Numpad();
                if (numpad.ShowDialog() == DialogResult.OK)
                {
                    amount = numpad.result;
                }
                else return; //dont add product
            }
            else
            {
                amount = decimal.Parse(selectableButton1.SelectedButton.Text.Replace("X", "").Trim());
            }

            if (BonData.ContainsKey(product))
            {
                BonData[product] += amount; //doesnt add if not there
            }
            else
            {
                BonData[product] = amount; //adds if not there otherwise changes
            }
            reload_bon();
            selectableButton1.ResetButtons();
            //MessageBox.Show($"product = {product.ProductNaam}, amount = {BonData[product]} ");
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"betaalt: {total:C2}", "betaalt", MessageBoxButtons.OK);
            ListBoxBon.Items.Clear();
            BtnPay.Enabled = false;
            BtnDelete.Enabled = false;
            total = 0;
            BonData.Clear();
            tabControlCategories.SelectedTab = tabGroente;
            loadData();
        }

        private void reload_bon()
        {
            ListBoxBon.Items.Clear();
            total = 0;
            foreach (KeyValuePair<ProductPanel, decimal> item in BonData)
            {
                ProductPanel key = item.Key;
                decimal amount = item.Value;
                if (key.productdata.PriceType == 2)
                {
                    ListBoxBon.Items.Add($"{amount} kilo \t {key.productdata.ProductNaam}({key.productdata.ProductPrijs:C2} per kilo) | {(key.productdata.ProductPrijs * amount):C2} ");
                }
                else
                {
                    ListBoxBon.Items.Add($"{amount}X \t {key.productdata.ProductNaam}({key.productdata.ProductPrijs:C2}) | {(key.productdata.ProductPrijs * amount):C2} ");
                }
                total += key.productdata.ProductPrijs * amount;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxBon.SelectedIndex != -1)
            {
                string product = ListBoxBon.SelectedItem.ToString();
                int tabIndex = product.IndexOf('\t');
                int parenIndex = product.IndexOf('(');

                string name = product.Substring(tabIndex + 1, parenIndex - tabIndex - 1).Trim();
                //MessageBox.Show($"Product name: {name}");

                // ^\d+X\s+(.*?)\( → start of line (^), digits + 'X' (\d+X), spaces (\s+), capture name (.*?) until first '('
                //Match match = Regex.Match(line, @"^\d+X\s+(.*?)\(");
                foreach (ProductPanel item in BonData.Keys)
                {
                    if (item.productdata.ProductNaam == name)
                    {
                        //new Form { BackgroundImage = item.ProductImage, Size = new Size(400, 300) }.ShowDialog();
                        BonData.Remove(item);
                        BtnDelete.Enabled=false;
                        if (ListBoxBon.Items.Count <= 1)
                        {
                            Console.WriteLine($"ListBoxBon.Items.Count = {ListBoxBon.Items.Count}");
                            BtnPay.Enabled=false;
                        }
                        reload_bon();
                        return;
                    }
                }
            }
        }

        private void ListBoxBon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxBon.SelectedIndex != -1)
            {
                BtnDelete.Enabled = true;
            }
        }
    }
}
