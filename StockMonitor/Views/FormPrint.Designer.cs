namespace InventoryManagerment.StockMonitor.Views {
    partial class FormPrint {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint));
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnPreview = new System.Windows.Forms.Button();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printPre = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(29, 144);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 23);
            this.BtnPrint.TabIndex = 0;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnPreview
            // 
            this.BtnPreview.Location = new System.Drawing.Point(153, 144);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(75, 23);
            this.BtnPreview.TabIndex = 0;
            this.BtnPreview.Text = "Preview";
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // printPre
            // 
            this.printPre.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPre.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPre.ClientSize = new System.Drawing.Size(400, 300);
            this.printPre.Enabled = true;
            this.printPre.Icon = ((System.Drawing.Icon)(resources.GetObject("printPre.Icon")));
            this.printPre.Name = "printPre";
            this.printPre.Visible = false;
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.BtnPrint);
            this.Name = "FormPrint";
            this.Text = "FormPrint";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnPreview;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.PrintPreviewDialog printPre;
    }
}