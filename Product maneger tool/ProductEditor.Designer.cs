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
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.comboBoxPriceType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbProductPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumID)).BeginInit();
            this.SuspendLayout();
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(112, 291);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(166, 22);
            this.TbName.TabIndex = 0;
            // 
            // PbProductPicture
            // 
            this.PbProductPicture.BackColor = System.Drawing.Color.White;
            this.PbProductPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbProductPicture.Location = new System.Drawing.Point(12, 12);
            this.PbProductPicture.Name = "PbProductPicture";
            this.PbProductPicture.Size = new System.Drawing.Size(266, 266);
            this.PbProductPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbProductPicture.TabIndex = 1;
            this.PbProductPicture.TabStop = false;
            this.PbProductPicture.Click += new System.EventHandler(this.PbProductPicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "naam:";
            // 
            // NumPrice
            // 
            this.NumPrice.DecimalPlaces = 2;
            this.NumPrice.Location = new System.Drawing.Point(112, 320);
            this.NumPrice.Name = "NumPrice";
            this.NumPrice.Size = new System.Drawing.Size(166, 22);
            this.NumPrice.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "prijs";
            // 
            // NumID
            // 
            this.NumID.Enabled = false;
            this.NumID.Location = new System.Drawing.Point(112, 348);
            this.NumID.Name = "NumID";
            this.NumID.ReadOnly = true;
            this.NumID.Size = new System.Drawing.Size(166, 22);
            this.NumID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID:";
            // 
            // BtnCancle
            // 
            this.BtnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancle.Location = new System.Drawing.Point(12, 479);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(75, 23);
            this.BtnCancle.TabIndex = 7;
            this.BtnCancle.Text = "cancel";
            this.BtnCancle.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(187, 479);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "categorie:";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(112, 377);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(170, 24);
            this.comboBoxCategories.TabIndex = 10;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(12, 443);
            this.checkBoxActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(65, 20);
            this.checkBoxActive.TabIndex = 11;
            this.checkBoxActive.Text = "active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // comboBoxPriceType
            // 
            this.comboBoxPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriceType.FormattingEnabled = true;
            this.comboBoxPriceType.Location = new System.Drawing.Point(113, 412);
            this.comboBoxPriceType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPriceType.Name = "comboBoxPriceType";
            this.comboBoxPriceType.Size = new System.Drawing.Size(170, 24);
            this.comboBoxPriceType.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "pijs type:";
            // 
            // ProductEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 520);
            this.Controls.Add(this.comboBoxPriceType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnCancle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbProductPicture);
            this.Controls.Add(this.TbName);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(303, 427);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.ComboBox comboBoxPriceType;
        private System.Windows.Forms.Label label5;
    }
}