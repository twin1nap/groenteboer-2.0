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

namespace groenteboer_app
{
    public partial class ProductPanel : UserControl
    {
        public string ProductNaam
        {
            get { return LblProductName.Text; }
            set { LblProductName.Text = value; }
        }
        public decimal ProductPrijs
        {
            get { return decimal.Parse(lblProductPrice.Text.Replace("€", "").Trim()); }
            set { lblProductPrice.Text = $"{value:c2}"; }
        }
        public Image ProductImage
        {
            set { PbProductPicture.Image = value; }
        }
        public ProductPanel()
        {
            InitializeComponent();
            EnableClickPassthrough(this);
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
