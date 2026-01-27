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
using System.Windows.Forms.DataVisualization.Charting;

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
            List<DashboardComboBoxItem> dashboardComboBoxItemsRapportages = new List<DashboardComboBoxItem>();
            List<DashboardComboBoxItem> dashboardComboBoxItemsGrafieken = new List<DashboardComboBoxItem>();

            // Gemiddeld bedrag per verkoop
            List<AverageAmountSpend> averageAmountSpends = new List<AverageAmountSpend>();
            averageAmountSpends = db.GetAverageAmountSpend();
            DashboardComboBoxItem _AverageAmountSpend = new DashboardComboBoxItem()
            {
                ItemName = "Gemiddeld besteed bedrag",
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
                    readOnly = true,
                    YearFilter = false
                }
            };
            dashboardComboBoxItemsRapportages.Add(_AverageAmountSpend);
            //dataGridViewRaportages.DataSource = averageAmountSpends;

            List<AnnualTurnoverOverview> annualTurnoverOverviews = new List<AnnualTurnoverOverview>();
            annualTurnoverOverviews = db.GetAnnualTurnoverOverview(dateTimePickerRapportageFilter.Value.Year);
            DashboardComboBoxItem _annualTurnoverOverviews = new DashboardComboBoxItem()
            {
                ItemName = "Jaaroverzicht omzet",
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
                    readOnly = true,
                    YearFilter = true //add the min and maxx based on the dates.
                }
            };
            dashboardComboBoxItemsRapportages.Add(_annualTurnoverOverviews);
            //dataGridViewRaportages.DataSource = annualTurnoverOverviews;

            List<SalesPerProduct> salesPerProducts = new List<SalesPerProduct>();
            salesPerProducts = db.GetSalesPerProduct();
            DashboardComboBoxItem _salesPerProducts = new DashboardComboBoxItem()
            {
                ItemName = "Verkoop per product",
                TableSettings = new TableSettings()
                {
                    DataSource = salesPerProducts,
                    Columns = new List<DataGridViewTextBoxColumn>
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Product",
                            DataPropertyName = "product"
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Totaal Verkocht",
                            DataPropertyName = "Totaal_Verkocht"
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Totale omzet (€)",
                            DataPropertyName = "Totale_omzet" //add string formatting
                        } 
                    },
                    readOnly = true,
                    YearFilter = false
                }
            };
            dashboardComboBoxItemsRapportages.Add(_salesPerProducts);
            //dataGridViewRaportages.DataSource = salesPerProducts;

            List<BusiestDay> busiestDays = new List<BusiestDay>();
            busiestDays = db.GetBusiestDays();
            DashboardComboBoxItem _busiestDays = new DashboardComboBoxItem()
            {
                ItemName = "Drukste dagen",
                TableSettings = new TableSettings()
                {
                    DataSource = busiestDays,
                    Columns = new List<DataGridViewTextBoxColumn>
                    {
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Datum",
                            DataPropertyName = "Datum" //make english variables now that columns are created
                        },
                        new DataGridViewTextBoxColumn()
                        {
                            HeaderText = "Totale omzet (€)",
                            DataPropertyName = "Totale_omzet" //add string formatting
                        }
                    },
                    readOnly = true,
                    YearFilter = false
                }
            };
            dashboardComboBoxItemsRapportages.Add(_busiestDays);
            //dataGridViewRaportages.DataSource = busiestDays;
            
            List<TurnoverPerMonth> turnoverPerMonths = new List<TurnoverPerMonth>();
            turnoverPerMonths = db.GetTurnoverPerMonth(2026);
            DashboardComboBoxItem _turnoverPerMonths = new DashboardComboBoxItem
            {
                ItemName = "Omzet per maand",
                Chartsettings = new Chart()
            };
            _turnoverPerMonths.Chartsettings.Titles.Add(Text = $"Omzet per maand (2026)");

            _turnoverPerMonths.Chartsettings.Series.Add("SeriesDisplay");
            _turnoverPerMonths.Chartsettings.ChartAreas.Add("area");
            Series series_turnoverPerMonths = _turnoverPerMonths.Chartsettings.Series["SeriesDisplay"];
            //Series series_turnoverPerMonths = chartGrafieken.Series["SeriesDisplay"];

            //set legendtext
            series_turnoverPerMonths.LegendText = "Omzet per maand";
            // set type
            series_turnoverPerMonths.ChartType = SeriesChartType.Column;
            // set marker
            //series_turnoverPerMonths.MarkerStyle = MarkerStyle.Circle;
            //series_turnoverPerMonths.MarkerSize = 7;
            // set tooltip
            series_turnoverPerMonths.ToolTip = "#VAL{C}\r\n";
            //set interval
            //_turnoverPerMonths.Chartsettings.ChartAreas["area"].AxisY.Interval = 500;
            //set axislabel in area
                // code
            //set points
            series_turnoverPerMonths.Points.Clear();
            foreach (TurnoverPerMonth month in turnoverPerMonths)
            {
                series_turnoverPerMonths.Points.AddXY(month.Month, month.Turnover);
            }
            dashboardComboBoxItemsGrafieken.Add(_turnoverPerMonths);

            DailyTurnoverInMonth[] DailyTurnoversInMonth = new DailyTurnoverInMonth[DateTime.DaysInMonth(2026, 1)];
            DailyTurnoversInMonth = db.GetDailyTurnoverInMonth(2026, 1);
            DashboardComboBoxItem _DailyTurnoversInMonth = new DashboardComboBoxItem
            {
                ItemName = "Dagomzet binnen een maand",
                Chartsettings = new Chart()
            };
            _DailyTurnoversInMonth.Chartsettings.Titles.Add(Text = $"Dagomzet - {new DateTime(2000, 1, 1).ToString("MMMM")}");

            _DailyTurnoversInMonth.Chartsettings.Series.Add("SeriesDisplay");
            _DailyTurnoversInMonth.Chartsettings.ChartAreas.Add("area");
            Series series_DailyTurnoversInMonth = _DailyTurnoversInMonth.Chartsettings.Series["SeriesDisplay"];
            //Series series_turnoverPerMonths = chartGrafieken.Series["SeriesDisplay"];

            //set legendtext
            series_DailyTurnoversInMonth.LegendText = "Dagomzet binnen een maand";
            // set type
            series_DailyTurnoversInMonth.ChartType = SeriesChartType.Line;
            // set marker
            series_DailyTurnoversInMonth.MarkerStyle = MarkerStyle.Circle;
            series_DailyTurnoversInMonth.MarkerSize = 10;
            //set line
            series_DailyTurnoversInMonth.BorderWidth = 5;
            // set tooltip
            series_DailyTurnoversInMonth.ToolTip = "#VAL{C}\r\n";
            //set interval
            _DailyTurnoversInMonth.Chartsettings.ChartAreas["area"].AxisX.Interval = 1;
            //set axislabel in area
            // code
            //set points
            series_DailyTurnoversInMonth.Points.Clear();
            foreach (DailyTurnoverInMonth day in DailyTurnoversInMonth)
            {
                series_DailyTurnoversInMonth.Points.AddXY(day.day, day.Turnover);
            }
            dashboardComboBoxItemsGrafieken.Add(_DailyTurnoversInMonth);

            List<CategoryTurnover> categoryTurnovers = new List<CategoryTurnover>();
            categoryTurnovers = db.GetCategoryTurnovers();
            DashboardComboBoxItem _categoryTurnovers = new DashboardComboBoxItem
            {
                ItemName = "Omzet per categorie",
                Chartsettings = new Chart()
            };
            _categoryTurnovers.Chartsettings.Titles.Add(Text = $"Omzet per categorie");

            _categoryTurnovers.Chartsettings.Series.Add("SeriesDisplay");
            _categoryTurnovers.Chartsettings.ChartAreas.Add("area");
            Series series_categoryTurnovers = _categoryTurnovers.Chartsettings.Series["SeriesDisplay"];
            //Series series_turnoverPerMonths = chartGrafieken.Series["SeriesDisplay"];

            //set legendtext
            series_categoryTurnovers.LegendText = "Omzet per categorie";
            // set type
            series_categoryTurnovers.ChartType = SeriesChartType.Column;
            // set marker
            //series_categoryTurnovers.MarkerStyle = MarkerStyle.Circle;
            //series_categoryTurnovers.MarkerSize = 10;
            //set line
            //series_categoryTurnovers.BorderWidth = 5;
            // set tooltip
            series_categoryTurnovers.ToolTip = "#VAL{C}\r\n";
            //set interval
            //_categoryTurnovers.Chartsettings.ChartAreas["area"].AxisX.Interval = 1;
            //set axislabel in area
            // code
            //set points
            series_categoryTurnovers.Points.Clear();
            foreach (CategoryTurnover category in categoryTurnovers)
            {
                series_categoryTurnovers.Points.AddXY(category.CategoryName, category.Turnover);
            }
            dashboardComboBoxItemsGrafieken.Add(_categoryTurnovers);

            List<BestSellingProduct> bestSellingProducts = new List<BestSellingProduct>();
            bestSellingProducts = db.GetBestSellingProducts();
            DashboardComboBoxItem _bestSellingProducts = new DashboardComboBoxItem
            {
                ItemName = "Best verkochte producten",
                Chartsettings = new Chart()
            };
            _bestSellingProducts.Chartsettings.Titles.Add(Text = $"Best verkochte producten (Top 5)");

            _bestSellingProducts.Chartsettings.Series.Add("SeriesDisplay");
            _bestSellingProducts.Chartsettings.ChartAreas.Add("area");
            Series series_bestSellingProducts = _bestSellingProducts.Chartsettings.Series["SeriesDisplay"];
            //Series series_turnoverPerMonths = chartGrafieken.Series["SeriesDisplay"];

            //set legendtext
            series_bestSellingProducts.LegendText = "Best verkochte producten";
            // set type
            series_bestSellingProducts.ChartType = SeriesChartType.Column;
            // set marker
            //series_categoryTurnovers.MarkerStyle = MarkerStyle.Circle;
            //series_categoryTurnovers.MarkerSize = 10;
            //set line
            //series_categoryTurnovers.BorderWidth = 5;
            // set tooltip
            series_bestSellingProducts.ToolTip = "#VAL{#######.### stuk/kilo}\r\n";
            //set interval
            //_categoryTurnovers.Chartsettings.ChartAreas["area"].AxisX.Interval = 1;
            //set axislabel in area
            // code
            //set points
            series_bestSellingProducts.Points.Clear();
            foreach (BestSellingProduct product in bestSellingProducts)
            {
                series_bestSellingProducts.Points.AddXY(product.ProductName, product.amount);
            }
            dashboardComboBoxItemsGrafieken.Add(_bestSellingProducts);


            //to keep index after refresh
            int? selectedIndexRapportage = null ;
            int? selectedIndexGrafiek = null ;
            if (comboBoxRaportages.SelectedIndex != -1)
            {
                selectedIndexRapportage = comboBoxRaportages.SelectedIndex;
            }
            comboBoxRaportages.DataSource = dashboardComboBoxItemsRapportages;
            comboBoxRaportages.DisplayMember = "ItemName";
            //comboBoxRaportages.ValueMember = "TableSettings";
            if (selectedIndexRapportage != null)
            {
                comboBoxRaportages.SelectedIndex = (int)selectedIndexRapportage;
            }

            if (comboBoxGrafieken.SelectedIndex != -1)
            {
                selectedIndexGrafiek = comboBoxGrafieken.SelectedIndex;
            }
            comboBoxGrafieken.DataSource = dashboardComboBoxItemsGrafieken;
            comboBoxGrafieken.DisplayMember = "Itemname";
            if (selectedIndexGrafiek != null)
            {
                comboBoxGrafieken.SelectedIndex = (int)selectedIndexGrafiek;
            }
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

        private void tabControlManagerPages_SelectedIndexChanged(object sender, EventArgs e)
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

            dateTimePickerRapportageFilter.Enabled = SelectedTableSettings.YearFilter;
        }

        private void dateTimePickerYearFilter_ValueChanged(object sender, EventArgs e)
        {
            LoadData(); //all functions that load data could be made one function.
        }

        private void comboBoxGrafieken_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashboardComboBoxItem selectedItem = (DashboardComboBoxItem)comboBoxGrafieken.SelectedItem;

            chartGrafieken.Titles.Clear();
            chartGrafieken.Titles.Add(selectedItem.Chartsettings.Titles[0]);
            Series series = chartGrafieken.Series["SeriesDisplay"];
            Series selectedItemSeries = selectedItem.Chartsettings.Series["SeriesDisplay"];
            //set legendtext
            series.LegendText = selectedItemSeries.LegendText;
            // set type
            series.ChartType = selectedItemSeries.ChartType;
            // set marker
            series.MarkerStyle = selectedItemSeries.MarkerStyle;
            series.MarkerSize = selectedItemSeries.MarkerSize;
            //set line
            series.BorderWidth = selectedItemSeries.BorderWidth;
            // set tooltip
            series.ToolTip = selectedItemSeries.ToolTip;
            //set interval
            chartGrafieken.ChartAreas[0].AxisX.Interval = selectedItem.Chartsettings.ChartAreas[0].AxisX.Interval;
            chartGrafieken.ChartAreas[0].AxisY.Interval = selectedItem.Chartsettings.ChartAreas[0].AxisY.Interval;
            //set points
            series.Points.Clear();
            foreach (DataPoint month in selectedItemSeries.Points)
            {
                series.Points.AddXY(month.AxisLabel, month.YValues[0]);
            }
        }
    }
}
