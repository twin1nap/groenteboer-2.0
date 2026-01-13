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
        public int Product_Id {  get; set; }
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
            get { return PbProductPicture.Image; }
            set { PbProductPicture.Image = value; }
        }
        private int _categorie;
        public int Product_categorie
        {
            get { return _categorie; }
            set
            {
                _categorie = value;
                if (value == 1)
                {
                    panel1.BackColor = Color.Lime;
                }
                else if (value == 2)
                {
                    panel1.BackColor = Color.Tomato;
                }
                else if (value == 3)
                {
                    panel1.BackColor = Color.LightPink;
                }
                else
                {
                    panel1.BackColor = SystemColors.ControlDark;
                }
            }
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
