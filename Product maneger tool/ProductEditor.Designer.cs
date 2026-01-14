namespace Product_maneger_tool
{
    partial class ProductEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbName = new System.Windows.Forms.TextBox();
            this.PbProductPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NumPrice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NumID = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCancle = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.openFileDialogimg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PbProductPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumID)).BeginInit();
            this.SuspendLayout();
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(126, 364);
            this.TbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(186, 26);
            this.TbName.TabIndex = 0;
            // 
            // PbProductPicture
            // 
            this.PbProductPicture.BackColor = System.Drawing.Color.White;
            this.PbProductPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbProductPicture.Location = new System.Drawing.Point(14, 15);
            this.PbProductPicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PbProductPicture.Name = "PbProductPicture";
            this.PbProductPicture.Size = new System.Drawing.Size(299, 332);
            this.PbProductPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbProductPicture.TabIndex = 1;
            this.PbProductPicture.TabStop = false;
            this.PbProductPicture.Click += new System.EventHandler(this.PbProductPicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "naam:";
            // 
            // NumPrice
            // 
            this.NumPrice.DecimalPlaces = 2;
            this.NumPrice.Location = new System.Drawing.Point(126, 400);
            this.NumPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumPrice.Name = "NumPrice";
            this.NumPrice.Size = new System.Drawing.Size(187, 26);
            this.NumPrice.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "prijs";
            // 
            // NumID
            // 
            this.NumID.Location = new System.Drawing.Point(126, 435);
            this.NumID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumID.Name = "NumID";
            this.NumID.Size = new System.Drawing.Size(187, 26);
            this.NumID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID:";
            // 
            // BtnCancle
            // 
            this.BtnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancle.Location = new System.Drawing.Point(14, 491);
            this.BtnCancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(84, 29);
            this.BtnCancle.TabIndex = 7;
            this.BtnCancle.Text = "cancel";
            this.BtnCancle.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(227, 491);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(84, 29);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // openFileDialogimg
            // 
            this.openFileDialogimg.FileName = "Select an image";
            this.openFileDialogimg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // 
            // ProductEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 529);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbProductPicture);
            this.Controls.Add(this.TbName);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(339, 522);
            this.Name = "ProductEditor";
            this.Text = "Product Editor";
            this.Load += new System.EventHandler(this.ProductEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbProductPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.PictureBox PbProductPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCancle;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialogimg;
    }
}