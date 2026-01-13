using System;
using System.Collections;
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
using Mysqlx.Crud;

namespace Product_maneger_tool
{
    public partial class ProductEditor : Form
    {
        public int Product_Id
        {
            get { return (int)NumID.Value; }
            set {NumID.Value = value; }
        }
        public string ProductNaam
        {
            get { return TbName.Text; }
            set { TbName.Text = value; }
        }
        public decimal ProductPrijs
        {
            get { return NumPrice.Value; }
            set { NumPrice.Value = value; }
        }
        public Image ProductImage
        {
            get { return PbProductPicture.Image; }
            set { PbProductPicture.Image = value; }
        }
        public ProductEditor()
        {
            InitializeComponent();
        }

        private void PbProductPicture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("image not (yet) editable using this tool", "change image | info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string connectionstring = "server=localhost;database=groenteboer; user=root; password=";
            string query = $"UPDATE `producten` SET `productName` = '{ProductNaam}', `price` = '{ProductPrijs.ToString(System.Globalization.CultureInfo.InvariantCulture)}' WHERE `producten`.`id` = {Product_Id};";

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

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int affectedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{affectedRows} rij(en) geüpdatet.");
                } 
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
