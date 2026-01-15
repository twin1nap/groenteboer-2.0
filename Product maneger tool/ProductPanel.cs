using ClassLibraryDb.models;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Product_maneger_tool
{
    public partial class ProductPanel : UserControl
    {
        public Product productdata {  get; set; }
        //public string ProductNaam
        //{
        //    get { return LblProductName.Text; }
        //    set { LblProductName.Text = value; }
        //}
        //public bool PriceType
        //{
        //    get; set;
        //}
        //public decimal ProductPrijs
        //{
        //    get 
        //    {
        //        int index = lblProductPrice.Text.Replace("€", "").IndexOf("per");

        //        return decimal.Parse(lblProductPrice.Text.Replace("€", "").Substring(0, index).Trim()); 
        //    }
        //    set 
        //    { 
        //        Console.WriteLine(PriceType.ToString());
        //        if (PriceType)
        //        {
        //            lblProductPrice.Text = $"{value:c2} per kilo"; 
        //        }
        //        else
        //        {
        //            lblProductPrice.Text = $"{value:c2} per stuk";
        //        }
        //    }
        //}
        //public Image ProductImage
        //{
        //    set { PbProductPicture.Image = value; }
        //}
        public ProductPanel()
        {
            InitializeComponent();
            EnableClickPassthrough(this);
        }
        private void ProductPanel_Load(object sender, EventArgs e)
        {
            LblProductName.Text = productdata.ProductNaam;
            if (productdata.PriceType == 2)
            {
                lblProductPrice.Text = $"{productdata.ProductPrijs:c2} per kilo";
            }
            else
            {
                lblProductPrice.Text = $"{productdata.ProductPrijs:c2} per stuk";
            }
            PbProductPicture.Image = productdata.ProductImage;

            if (productdata.categoryId == 1)
            {
                panel1.BackColor = Color.Lime;
            }
            else if (productdata.categoryId == 2)
            {
                panel1.BackColor = Color.Tomato;
            }
            else if (productdata.categoryId == 3)
            {
                panel1.BackColor = Color.LightPink;
            }
            else
            {
                panel1.BackColor = SystemColors.ControlDark;
            }

        }

        private void EnableClickPassthrough(Control parent)
        {
            foreach (Control ctl in parent.Controls)
            {
                ctl.Click += (s, e) => this.OnClick(e);
                if (ctl.HasChildren)
                {
                    EnableClickPassthrough(ctl);  // recurse into child controls
                }
            }
        }

    }
}
