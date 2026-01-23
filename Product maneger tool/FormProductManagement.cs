using ClassLibraryDb;
using ClassLibraryDb.models;
using ClassLibraryDb.models.dashboard;
using groenteboer_app.models;
using Product_maneger_tool.Models;
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

            // dashboard
            List<DashboardComboBoxItem> dashboardComboBoxItems = new List<DashboardComboBoxItem>();

            // Gemiddeld bedrag per verkoop
            List<AverageAmountSpend> averageAmountSpends = new List<AverageAmountSpend>();
            averageAmountSpends = db.GetAverageAmountSpend();
            DashboardComboBoxItem _AverageAmountSpend = new DashboardComboBoxItem()
            {
                ItemName = "Gemiddeld bedrag per verkoop",
                TableSettings = new TableSettings()
                {
                    DataSource = averageAmountSpends,
                    Columns = new List<DataGridViewTextBoxColumn>
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = averageAmountSpends[0].omschrijving,
                            DataPropertyName = "amount"
                        } //automate this
                    },
                    readOnly = true
                }
            };
            dashboardComboBoxItems.Add(_AverageAmountSpend);
            //dataGridViewRaportages.DataSource = averageAmountSpends;

            List<AnnualTurnoverOverview> annualTurnoverOverviews = new List<AnnualTurnoverOverview>();
            annualTurnoverOverviews = db.GetAnnualTurnoverOverview(2026);
            DashboardComboBoxItem _annualTurnoverOverviews = new DashboardComboBoxItem()
            {
                ItemName = "Gemiddeld bedrag per verkoop",
                TableSettings = new TableSettings()
                {
                    DataSource = annualTurnoverOverviews,
                    Columns = new List<DataGridViewTextBoxColumn> //change source object so there is an omschrijving and Waarde
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Totaal aantal verkopen",
                            DataPropertyName = "Totaal_aantal_verkopen"
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Totale jaaromzet (€)",
                            DataPropertyName = "Totale_jaaromzet" //add string formatting
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Gemiddelde omzet per verkoop",
                            DataPropertyName = "Gemiddelde_omzet_per_verkoop" //add string formatting
                        } 
                        //automate this
                    },
                    readOnly = true
                }
            };
            dashboardComboBoxItems.Add(_annualTurnoverOverviews);
            //dataGridViewRaportages.DataSource = annualTurnoverOverviews;

            List<SalesPerProduct> salesPerProducts = new List<SalesPerProduct>();
            salesPerProducts = db.GetSalesPerProduct();
            DashboardComboBoxItem __annualTurnoverOverviews = new DashboardComboBoxItem()
            {
                ItemName = "Gemiddeld bedrag per verkoop",
                TableSettings = new TableSettings()
                {
                    DataSource = annualTurnoverOverviews,
                    Columns = new List<DataGridViewTextBoxColumn> //change source object so there is an omschrijving and Waarde
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Totaal aantal verkopen",
                            DataPropertyName = "Totaal_aantal_verkopen"
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Totale jaaromzet (€)",
                            DataPropertyName = "Totale_jaaromzet" //add string formatting
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Gemiddelde omzet per verkoop",
                            DataPropertyName = "Gemiddelde_omzet_per_verkoop" //add string formatting
                        } 
                        //automate this
                    },
                    readOnly = true
                }
            };
            dashboardComboBoxItems.Add(_annualTurnoverOverviews);
            dataGridViewRaportages.DataSource = salesPerProducts;

            //List<BusiestDay> busiestDays = new List<BusiestDay>();
            //busiestDays = db.GetBusiestDays();
            //dataGridViewRaportages.DataSource = busiestDays;

            //dataGridViewRaportages.Columns =

            //comboBoxRaportages.DataSource = dashboardComboBoxItems;
            //comboBoxRaportages.DisplayMember = "ItemName";
            ////comboBoxRaportages.ValueMember = "TableSettings";
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBoxRaportages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add keep selected index
            dataGridViewRaportages.AutoGenerateColumns = false;
            dataGridViewRaportages.Columns.Clear();

            DashboardComboBoxItem selectedItem = (DashboardComboBoxItem)comboBoxRaportages.SelectedItem;
            TableSettings SelectedTableSettings = selectedItem.TableSettings;
            foreach (DataGridViewTextBoxColumn column in SelectedTableSettings.Columns)
            {
                dataGridViewRaportages.Columns.Add(column);
            }
            dataGridViewRaportages.DataSource = SelectedTableSettings.DataSource;
            dataGridViewRaportages.ReadOnly = SelectedTableSettings.readOnly;
        }
    }
}
