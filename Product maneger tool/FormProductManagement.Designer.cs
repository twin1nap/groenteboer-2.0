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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.FlpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlManagerPages = new System.Windows.Forms.TabControl();
            this.tabPageDashboard = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerRapportageFilter = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewRaportages = new System.Windows.Forms.DataGridView();
            this.comboBoxRaportages = new System.Windows.Forms.ComboBox();
            this.chartGrafieken = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxGrafieken = new System.Windows.Forms.ComboBox();
            this.tabPageProducts.SuspendLayout();
            this.tabControlManagerPages.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaportages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrafieken)).BeginInit();
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
            // tabControlManagerPages
            // 
            this.tabControlManagerPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlManagerPages.Controls.Add(this.tabPageProducts);
            this.tabControlManagerPages.Controls.Add(this.tabPageDashboard);
            this.tabControlManagerPages.Location = new System.Drawing.Point(15, 4);
            this.tabControlManagerPages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlManagerPages.Name = "tabControlManagerPages";
            this.tabControlManagerPages.SelectedIndex = 0;
            this.tabControlManagerPages.Size = new System.Drawing.Size(872, 558);
            this.tabControlManagerPages.TabIndex = 2;
            this.tabControlManagerPages.SelectedIndexChanged += new System.EventHandler(this.tabControlManagerPages_SelectedIndexChanged);
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBoxGrafieken);
            this.groupBox2.Controls.Add(this.chartGrafieken);
            this.groupBox2.Location = new System.Drawing.Point(7, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(404, 499);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "grafieken";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerRapportageFilter);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(240, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "jaar:";
            // 
            // dateTimePickerRapportageFilter
            // 
            this.dateTimePickerRapportageFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerRapportageFilter.CustomFormat = "yyyy";
            this.dateTimePickerRapportageFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.dateTimePickerRapportageFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerRapportageFilter.Location = new System.Drawing.Point(318, 450);
            this.dateTimePickerRapportageFilter.Name = "dateTimePickerRapportageFilter";
            this.dateTimePickerRapportageFilter.ShowUpDown = true;
            this.dateTimePickerRapportageFilter.Size = new System.Drawing.Size(115, 41);
            this.dateTimePickerRapportageFilter.TabIndex = 4;
            this.dateTimePickerRapportageFilter.ValueChanged += new System.EventHandler(this.dateTimePickerYearFilter_ValueChanged);
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
            this.dataGridViewRaportages.Size = new System.Drawing.Size(402, 327);
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
            // chartGrafieken
            // 
            this.chartGrafieken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartGrafieken.ChartAreas.Add(chartArea1);
            legend1.BorderColor = System.Drawing.Color.Black;
            legend1.Name = "Legend1";
            legend1.Title = "legenda:";
            this.chartGrafieken.Legends.Add(legend1);
            this.chartGrafieken.Location = new System.Drawing.Point(6, 115);
            this.chartGrafieken.Name = "chartGrafieken";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "SeriesDisplay";
            this.chartGrafieken.Series.Add(series1);
            this.chartGrafieken.Size = new System.Drawing.Size(392, 327);
            this.chartGrafieken.TabIndex = 0;
            // 
            // comboBoxGrafieken
            // 
            this.comboBoxGrafieken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGrafieken.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrafieken.FormattingEnabled = true;
            this.comboBoxGrafieken.Location = new System.Drawing.Point(6, 51);
            this.comboBoxGrafieken.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxGrafieken.Name = "comboBoxGrafieken";
            this.comboBoxGrafieken.Size = new System.Drawing.Size(377, 28);
            this.comboBoxGrafieken.TabIndex = 4;
            this.comboBoxGrafieken.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrafieken_SelectedIndexChanged);
            // 
            // ProductManeger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.tabControlManagerPages);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductManeger";
            this.Text = "Product maneger";
            this.Load += new System.EventHandler(this.ProductManeger_Load);
            this.tabPageProducts.ResumeLayout(false);
            this.tabPageProducts.PerformLayout();
            this.tabControlManagerPages.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaportages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrafieken)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FlpProducts;
        private System.Windows.Forms.TabControl tabControlManagerPages;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewRaportages;
        private System.Windows.Forms.ComboBox comboBoxRaportages;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerRapportageFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGrafieken;
        private System.Windows.Forms.ComboBox comboBoxGrafieken;
    }
}

