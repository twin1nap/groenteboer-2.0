using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace groenteboer_app
{
    public partial class Numpad : Form
    {
        private string grams
        {
            get { return lblOutput.Text; }
            set 
            { 
                lblOutput.Text = value;
                if (int.Parse(value) > 0)
                {
                    btnOk.Enabled = true;
                }
                else
                {
                    btnOk.Enabled = false;
                }
            }
        }

        public decimal result{
            get; private set;
        }
        public Numpad()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (grams != "0")
            {
                grams += btn.Text;
            }
            else
            {
                grams = btn.Text;
            }
        }

        private void Numpad_Load(object sender, EventArgs e)
        {
            Focus();
            grams = "0";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            result = (decimal.Parse(grams) / 1000);
            this.DialogResult = DialogResult.OK;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
