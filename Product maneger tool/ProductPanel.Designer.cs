namespace Product_maneger_tool
{
    partial class ProductPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.LblProductName = new System.Windows.Forms.Label();
            this.PbProductPicture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbProductPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.lblProductPrice);
            this.panel1.Controls.Add(this.LblProductName);
            this.panel1.Location = new System.Drawing.Point(0, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 67);
            this.panel1.TabIndex = 2;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.Location = new System.Drawing.Point(0, 35);
            this.lblProductPrice.MinimumSize = new System.Drawing.Size(200, 0);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(252, 22);
            this.lblProductPrice.TabIndex = 1;
            this.lblProductPrice.Text = "prijs";
            this.lblProductPrice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LblProductName
            // 
            this.LblProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProductName.Location = new System.Drawing.Point(0, 0);
            this.LblProductName.MinimumSize = new System.Drawing.Size(200, 0);
            this.LblProductName.Name = "LblProductName";
            this.LblProductName.Size = new System.Drawing.Size(252, 22);
            this.LblProductName.TabIndex = 0;
            this.LblProductName.Text = "naam";
            this.LblProductName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // PbProductPicture
            // 
            this.PbProductPicture.BackColor = System.Drawing.Color.White;
            this.PbProductPicture.Location = new System.Drawing.Point(-2, -2);
            this.PbProductPicture.Name = "PbProductPicture";
            this.PbProductPicture.Size = new System.Drawing.Size(250, 184);
            this.PbProductPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbProductPicture.TabIndex = 3;
            this.PbProductPicture.TabStop = false;
            // 
            // ProductPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.PbProductPicture);
            this.Controls.Add(this.panel1);
            this.Name = "ProductPanel";
            this.Size = new System.Drawing.Size(250, 250);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbProductPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label LblProductName;
        private System.Windows.Forms.PictureBox PbProductPicture;
    }
}
