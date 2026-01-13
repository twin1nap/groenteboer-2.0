namespace groenteboer_app
{
    partial class SelectableButton
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
            this.FlpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FlpButtons
            // 
            this.FlpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlpButtons.Location = new System.Drawing.Point(0, 0);
            this.FlpButtons.Name = "FlpButtons";
            this.FlpButtons.Size = new System.Drawing.Size(487, 58);
            this.FlpButtons.TabIndex = 0;
            // 
            // SelectableButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FlpButtons);
            this.Name = "SelectableButton";
            this.Size = new System.Drawing.Size(487, 58);
            this.Load += new System.EventHandler(this.SelectableButton_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlpButtons;
    }
}
