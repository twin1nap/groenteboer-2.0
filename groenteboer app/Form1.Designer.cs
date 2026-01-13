namespace groenteboer_app
{
    partial class FormGroenteboer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroenteboer));
            this.tabControlCategories = new System.Windows.Forms.TabControl();
            this.tabGroente = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelGroente = new System.Windows.Forms.FlowLayoutPanel();
            this.tabFruit = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelFruit = new System.Windows.Forms.FlowLayoutPanel();
            this.tabSmoothie = new System.Windows.Forms.TabPage();
            this.flowLayoutSmoothie = new System.Windows.Forms.FlowLayoutPanel();
            this.tabAndere = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelAndere = new System.Windows.Forms.FlowLayoutPanel();
            this.ListBoxBon = new System.Windows.Forms.ListBox();
            this.GroupPay = new System.Windows.Forms.GroupBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.BtnPay = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.selectableButton1 = new groenteboer_app.SelectableButton();
            this.tabControlCategories.SuspendLayout();
            this.tabGroente.SuspendLayout();
            this.tabFruit.SuspendLayout();
            this.tabSmoothie.SuspendLayout();
            this.tabAndere.SuspendLayout();
            this.GroupPay.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlCategories
            // 
            this.tabControlCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlCategories.Controls.Add(this.tabGroente);
            this.tabControlCategories.Controls.Add(this.tabFruit);
            this.tabControlCategories.Controls.Add(this.tabSmoothie);
            this.tabControlCategories.Controls.Add(this.tabAndere);
            this.tabControlCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlCategories.Location = new System.Drawing.Point(12, 12);
            this.tabControlCategories.Name = "tabControlCategories";
            this.tabControlCategories.SelectedIndex = 0;
            this.tabControlCategories.Size = new System.Drawing.Size(553, 446);
            this.tabControlCategories.TabIndex = 0;
            // 
            // tabGroente
            // 
            this.tabGroente.Controls.Add(this.flowLayoutPanelGroente);
            this.tabGroente.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGroente.Location = new System.Drawing.Point(4, 38);
            this.tabGroente.Name = "tabGroente";
            this.tabGroente.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroente.Size = new System.Drawing.Size(545, 404);
            this.tabGroente.TabIndex = 0;
            this.tabGroente.Text = "groente";
            this.tabGroente.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelGroente
            // 
            this.flowLayoutPanelGroente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelGroente.AutoScroll = true;
            this.flowLayoutPanelGroente.Location = new System.Drawing.Point(6, 3);
            this.flowLayoutPanelGroente.Name = "flowLayoutPanelGroente";
            this.flowLayoutPanelGroente.Size = new System.Drawing.Size(533, 395);
            this.flowLayoutPanelGroente.TabIndex = 0;
            // 
            // tabFruit
            // 
            this.tabFruit.Controls.Add(this.flowLayoutPanelFruit);
            this.tabFruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFruit.Location = new System.Drawing.Point(4, 38);
            this.tabFruit.Name = "tabFruit";
            this.tabFruit.Padding = new System.Windows.Forms.Padding(3);
            this.tabFruit.Size = new System.Drawing.Size(623, 404);
            this.tabFruit.TabIndex = 1;
            this.tabFruit.Text = "fruit";
            this.tabFruit.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelFruit
            // 
            this.flowLayoutPanelFruit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFruit.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutPanelFruit.Name = "flowLayoutPanelFruit";
            this.flowLayoutPanelFruit.Size = new System.Drawing.Size(676, 393);
            this.flowLayoutPanelFruit.TabIndex = 1;
            // 
            // tabSmoothie
            // 
            this.tabSmoothie.Controls.Add(this.flowLayoutSmoothie);
            this.tabSmoothie.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSmoothie.Location = new System.Drawing.Point(4, 38);
            this.tabSmoothie.Name = "tabSmoothie";
            this.tabSmoothie.Size = new System.Drawing.Size(623, 404);
            this.tabSmoothie.TabIndex = 2;
            this.tabSmoothie.Text = "smoothies";
            this.tabSmoothie.UseVisualStyleBackColor = true;
            // 
            // flowLayoutSmoothie
            // 
            this.flowLayoutSmoothie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutSmoothie.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutSmoothie.Name = "flowLayoutSmoothie";
            this.flowLayoutSmoothie.Size = new System.Drawing.Size(679, 396);
            this.flowLayoutSmoothie.TabIndex = 1;
            // 
            // tabAndere
            // 
            this.tabAndere.Controls.Add(this.flowLayoutPanelAndere);
            this.tabAndere.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAndere.Location = new System.Drawing.Point(4, 38);
            this.tabAndere.Name = "tabAndere";
            this.tabAndere.Size = new System.Drawing.Size(623, 404);
            this.tabAndere.TabIndex = 3;
            this.tabAndere.Text = "andere";
            this.tabAndere.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelAndere
            // 
            this.flowLayoutPanelAndere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelAndere.Location = new System.Drawing.Point(6, 5);
            this.flowLayoutPanelAndere.Name = "flowLayoutPanelAndere";
            this.flowLayoutPanelAndere.Size = new System.Drawing.Size(679, 396);
            this.flowLayoutPanelAndere.TabIndex = 1;
            // 
            // ListBoxBon
            // 
            this.ListBoxBon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxBon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxBon.FormattingEnabled = true;
            this.ListBoxBon.ItemHeight = 29;
            this.ListBoxBon.Location = new System.Drawing.Point(571, 12);
            this.ListBoxBon.Name = "ListBoxBon";
            this.ListBoxBon.Size = new System.Drawing.Size(617, 323);
            this.ListBoxBon.TabIndex = 1;
            this.ListBoxBon.SelectedIndexChanged += new System.EventHandler(this.ListBoxBon_SelectedIndexChanged);
            // 
            // GroupPay
            // 
            this.GroupPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupPay.BackColor = System.Drawing.SystemColors.Window;
            this.GroupPay.Controls.Add(this.LblTotal);
            this.GroupPay.Controls.Add(this.BtnPay);
            this.GroupPay.Location = new System.Drawing.Point(571, 396);
            this.GroupPay.Name = "GroupPay";
            this.GroupPay.Size = new System.Drawing.Size(617, 141);
            this.GroupPay.TabIndex = 2;
            this.GroupPay.TabStop = false;
            // 
            // LblTotal
            // 
            this.LblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(177, 36);
            this.LblTotal.MinimumSize = new System.Drawing.Size(264, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(264, 29);
            this.LblTotal.TabIndex = 3;
            this.LblTotal.Text = "totaal: €";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPay
            // 
            this.BtnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPay.Enabled = false;
            this.BtnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPay.Location = new System.Drawing.Point(6, 91);
            this.BtnPay.Name = "BtnPay";
            this.BtnPay.Size = new System.Drawing.Size(605, 44);
            this.BtnPay.TabIndex = 2;
            this.BtnPay.Text = "betalen";
            this.BtnPay.UseVisualStyleBackColor = true;
            this.BtnPay.Click += new System.EventHandler(this.BtnPay_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.BtnDelete.Location = new System.Drawing.Point(816, 343);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(372, 49);
            this.BtnDelete.TabIndex = 4;
            this.BtnDelete.Text = "verwijder product uit bon";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // selectableButton1
            // 
            this.selectableButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectableButton1.Buttons = ((System.Collections.Generic.List<string>)(resources.GetObject("selectableButton1.Buttons")));
            this.selectableButton1.Location = new System.Drawing.Point(12, 464);
            this.selectableButton1.Name = "selectableButton1";
            this.selectableButton1.SelectedButton = null;
            this.selectableButton1.Size = new System.Drawing.Size(553, 77);
            this.selectableButton1.TabIndex = 0;
            // 
            // FormGroenteboer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 553);
            this.Controls.Add(this.selectableButton1);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.GroupPay);
            this.Controls.Add(this.ListBoxBon);
            this.Controls.Add(this.tabControlCategories);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormGroenteboer";
            this.Text = "groenteboer app";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlCategories.ResumeLayout(false);
            this.tabGroente.ResumeLayout(false);
            this.tabFruit.ResumeLayout(false);
            this.tabSmoothie.ResumeLayout(false);
            this.tabAndere.ResumeLayout(false);
            this.GroupPay.ResumeLayout(false);
            this.GroupPay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCategories;
        private System.Windows.Forms.TabPage tabGroente;
        private System.Windows.Forms.TabPage tabFruit;
        private System.Windows.Forms.TabPage tabSmoothie;
        private System.Windows.Forms.TabPage tabAndere;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGroente;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFruit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSmoothie;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAndere;
        private System.Windows.Forms.ListBox ListBoxBon;
        private System.Windows.Forms.GroupBox GroupPay;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnPay;
        private System.Windows.Forms.Button BtnDelete;
        private SelectableButton selectableButton1;
    }
}

