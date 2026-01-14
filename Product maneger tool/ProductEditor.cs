using ClassLibraryDb;
using ClassLibraryDb.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Product_maneger_tool
{
    public partial class ProductEditor : Form
    {
        private string connectionstring = "server=localhost;database=groenteboer; user=root; password=";
        public Product productdata { get; set; }
        //public int Product_Id
        //{
        //    get { return (int)NumID.Value; }
        //    set {NumID.Value = value; }
        //}
        //public string ProductNaam
        //{
        //    get { return TbName.Text; }
        //    set { TbName.Text = value; }
        //}
        //public decimal ProductPrijs
        //{
        //    get { return NumPrice.Value; }
        //    set { NumPrice.Value = value; }
        //}
        //public Image ProductImage
        //{
        //    get { return PbProductPicture.Image; }
        //    set { PbProductPicture.Image = value; }
        //}
        public ProductEditor()
        {
            InitializeComponent();
        }
        private void ProductEditor_Load(object sender, EventArgs e)
        {
            NumID.Value = productdata.id;
            TbName.Text = productdata.ProductNaam;
            NumPrice.Value = productdata.ProductPrijs;
            PbProductPicture.Image = productdata.ProductImage;
        }

        private void PbProductPicture_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("image not (yet) editable using this tool", "change image | info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (openFileDialogimg.ShowDialog() == DialogResult.OK)
            {
                PbProductPicture.Image =Image.FromFile(openFileDialogimg.FileName);


            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //NumID.Value = productdata.id;
            productdata.id = int.Parse(NumID.Value.ToString());
            //TbName.Text = productdata.ProductNaam;
            productdata.ProductNaam = TbName.Text;
            //NumPrice.Value = productdata.ProductPrijs;
            productdata.ProductPrijs = NumPrice.Value;
            //PbProductPicture.Image = productdata.ProductImage;
            productdata.ProductImage = PbProductPicture.Image;
            //Button button = sender as Button;
            data db = new data(connectionstring);

            db.UpdateProduct(productdata);

            this.DialogResult = DialogResult.OK;
        }

    }
}
