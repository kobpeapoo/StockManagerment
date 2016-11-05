using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagerment.StockMonitor.Views {
    public partial class FormPrint : Form {
        private int linesPrinted;
        public FormPrint() {
            InitializeComponent();


            //this.printPre.AutoScrollMargin = new System.Drawing.Size(0, 0);
            //this.printPre.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            //this.printPre.ClientSize = new System.Drawing.Size(400, 300);
            //this.printPre.Document = this.printDoc;
            //this.printPre.Enabled = true; 
            //this.printPre.Location = new System.Drawing.Point(88, 116);
            //this.printPre.MaximumSize = new System.Drawing.Size(0, 0);
            //this.printPre.Name = "printPreviewDialog1";
            //this.printPre.Opacity = 1;
            //this.printPre.TransparencyKey = System.Drawing.Color.Empty;
            //this.printPre.Visible = false;
        }

        private void BtnPreview_Click(object sender, EventArgs e) {
            this.printPre.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPre.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPre.ClientSize = new System.Drawing.Size(400, 300);
            this.printPre.Document = this.printDoc;
            this.printPre.Enabled = true; 
            this.printPre.Location = new System.Drawing.Point(88, 116);
            this.printPre.MaximumSize = new System.Drawing.Size(0, 0);
            this.printPre.Name = "printPreviewDialog1";
            this.printPre.Opacity = 1;
            this.printPre.TransparencyKey = System.Drawing.Color.Empty;
            this.printPre.Visible = false;
            printPre.ShowDialog();
        }

        private void BtnPrint_Click(object sender, EventArgs e) {

        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            float x = (float)e.MarginBounds.Left;
            float y = (float)e.MarginBounds.Top;
            Font drawFont = new Font("AngsanaNew", 10);
            while (linesPrinted < 100)
            {
                e.Graphics.DrawString(""+(linesPrinted++), drawFont, Brushes.Black, x, y);
                y += 20;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }
    }
}
