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
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math;

namespace groenteboer_app
{
    public partial class FormGroenteboer : Form
    {
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


            string connectionstring = "server=localhost;database=groenteboer; user=root; password=";
            
        }

        private void button_Product_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectableButton1.SelectedButton.Text);
            ProductPanel product = (ProductPanel)sender;
            //MessageBox.Show(product.ProductPrijs);
            //ListBoxBon.Items.Add($"{product.ProductNaam} | {product.ProductPrijs:C2}");
            //total += product.ProductPrijs;
            decimal amount;
            if (product.PriceType)
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
                if (key.PriceType)
                {
                    ListBoxBon.Items.Add($"{amount} kilo \t {key.ProductNaam}({key.ProductPrijs:C2} per kilo) | {(key.ProductPrijs * amount):C2} ");
                }
                else
                {
                    ListBoxBon.Items.Add($"{amount}X \t {key.ProductNaam}({key.ProductPrijs:C2}) | {(key.ProductPrijs * amount):C2} ");
                }
                total += key.ProductPrijs * amount;
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
                    if (item.ProductNaam == name)
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
