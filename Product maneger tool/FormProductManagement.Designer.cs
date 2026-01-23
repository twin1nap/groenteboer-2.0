namespace Product_maneger_tool
{
    partial class ProductManeger
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
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.FlpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDashboard = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRaportages = new System.Windows.Forms.DataGridView();
            this.comboBoxRaportages = new System.Windows.Forms.ComboBox();
            this.tabPageProducts.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaportages)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Controls.Add(this.label1);
            this.tabPageProducts.Controls.Add(this.FlpProducts);
            this.tabPageProducts.Location = new System.Drawing.Point(4, 29);
            this.tabPageProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageProducts.Size = new System.Drawing.Size(864, 525);
            this.tabPageProducts.TabIndex = 0;
            this.tabPageProducts.Text = "producten";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "klik op een product om het product te bewerken";
            // 
            // FlpProducts
            // 
            this.FlpProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlpProducts.AutoScroll = true;
            this.FlpProducts.Location = new System.Drawing.Point(11, 38);
            this.FlpProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FlpProducts.Name = "FlpProducts";
            this.FlpProducts.Size = new System.Drawing.Size(845, 475);
            this.FlpProducts.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageProducts);
            this.tabControl1.Controls.Add(this.tabPageDashboard);
            this.tabControl1.Location = new System.Drawing.Point(15, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 558);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageDashboard
            // 
            this.tabPageDashboard.Controls.Add(this.groupBox2);
            this.tabPageDashboard.Controls.Add(this.groupBox1);
            this.tabPageDashboard.Location = new System.Drawing.Point(4, 29);
            this.tabPageDashboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageDashboard.Name = "tabPageDashboard";
            this.tabPageDashboard.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageDashboard.Size = new System.Drawing.Size(864, 525);
            this.tabPageDashboard.TabIndex = 1;
            this.tabPageDashboard.Text = "Dashboard";
            this.tabPageDashboard.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Location = new System.Drawing.Point(7, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(404, 499);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridViewRaportages);
            this.groupBox1.Controls.Add(this.comboBoxRaportages);
            this.groupBox1.Location = new System.Drawing.Point(417, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(439, 506);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "rapportages";
            // 
            // dataGridViewRaportages
            // 
            this.dataGridViewRaportages.AllowUserToAddRows = false;
            this.dataGridViewRaportages.AllowUserToDeleteRows = false;
            this.dataGridViewRaportages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRaportages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRaportages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaportages.Location = new System.Drawing.Point(30, 115);
            this.dataGridViewRaportages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewRaportages.Name = "dataGridViewRaportages";
            this.dataGridViewRaportages.ReadOnly = true;
            this.dataGridViewRaportages.RowHeadersVisible = false;
            this.dataGridViewRaportages.RowHeadersWidth = 51;
            this.dataGridViewRaportages.RowTemplate.Height = 24;
            this.dataGridViewRaportages.Size = new System.Drawing.Size(402, 384);
            this.dataGridViewRaportages.TabIndex = 2;
            // 
            // comboBoxRaportages
            // 
            this.comboBoxRaportages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRaportages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRaportages.FormattingEnabled = true;
            this.comboBoxRaportages.Location = new System.Drawing.Point(30, 51);
            this.comboBoxRaportages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxRaportages.Name = "comboBoxRaportages";
            this.comboBoxRaportages.Size = new System.Drawing.Size(401, 28);
            this.comboBoxRaportages.TabIndex = 3;
            this.comboBoxRaportages.SelectedIndexChanged += new System.EventHandler(this.comboBoxRaportages_SelectedIndexChanged);
            // 
            // ProductManeger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductManeger";
            this.Text = "Product maneger";
            this.Load += new System.EventHandler(this.ProductManeger_Load);
            this.tabPageProducts.ResumeLayout(false);
            this.tabPageProducts.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaportages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FlpProducts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewRaportages;
        private System.Windows.Forms.ComboBox comboBoxRaportages;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

