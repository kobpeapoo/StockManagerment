using InventoryManagerment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagerment.Views {

    public partial class PrintDocOrderReportForm : Form {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<OrderListModel> lsOrder = new List<OrderListModel>();
        Utility.CommonUtill comm = new Utility.CommonUtill();
        private PrintPreviewDialog previewDlg = null;
        private PrintDocument pd = new PrintDocument();
        public PrintDocOrderReportForm() {
            InitializeComponent();
        }
        int i = 0;
        int lineperpage = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            try
            {
                lineperpage = 0;            
                int countOrder = lsOrder.Count;
                
                while (i < countOrder)
                {
                    
                    OrderListModel order = lsOrder[i];

                    float y = (float)205 * lineperpage;

                    string createDate = order.CreateDate;
                    DateTime value = new DateTime(Convert.ToInt32(createDate.Substring(0, 4)) - 543, Convert.ToInt32(createDate.Substring(4, 2)), Convert.ToInt32(createDate.Substring(6, 2)));
                    int day = (int)value.DayOfWeek;

                    #region Line 1
                    float xTextLine1 = 5;
                    float yTextLine1 = 20 + y;
                    Font drawFont = new Font("CordiaUPC", 12, GraphicsUnit.Point);
                    e.Graphics.PageUnit = GraphicsUnit.Point;
                    e.Graphics.DrawString("" + order.List_Num_Order.PadLeft(4, '0') + " ใบสั่งงานย่อย/ใบสั่งงาน " + comm.dayThaiOfWeek(day) + "-" + comm.convertIntToShortDate(createDate) + ":"+order.CreateTimestamp.Substring(0,2)+"น.", drawFont, Brushes.Black, xTextLine1, yTextLine1);

                    // Set format of string.
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    drawFormat.LineAlignment = StringAlignment.Far;//Near,Far,Center

                    StringFormat drawFormatLeft = new StringFormat();
                    drawFormatLeft.LineAlignment = StringAlignment.Center;//Near,Far,Center

                    drawFont = new Font("CordiaUPC", 12);
                    float xBoxLin1 = 220;
                    float yBoxLine1 = 10 + y;
                    float wBoxLine1App1 = 35;
                    float hBoxLine1App1 = 20;
                    RectangleF rectFAppove1 = new RectangleF(xBoxLin1, yBoxLine1, wBoxLine1App1, hBoxLine1App1);
                    e.Graphics.DrawString("ผู้อนุมัติ", drawFont, Brushes.Black, rectFAppove1, drawFormat);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectFAppove1));
                    float wBoxLine1App2 = 70;
                    RectangleF rectFAppove2 = new RectangleF(xBoxLin1 + wBoxLine1App1, yBoxLine1, wBoxLine1App2, hBoxLine1App1);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectFAppove2));

                    float wBoxAudit1 = 50;
                    float xBoxAudit1 = xBoxLin1 + wBoxLine1App2 + 40;
                    RectangleF rectFAudit1 = new RectangleF(xBoxAudit1, yBoxLine1, wBoxAudit1, hBoxLine1App1);
                    e.Graphics.DrawString("ผู้ตรวจสอบ", drawFont, Brushes.Black, rectFAudit1, drawFormat);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectFAudit1));

                    float wBoxAudit2 = 60;
                    RectangleF rectFAudit2 = new RectangleF(xBoxAudit1 + wBoxAudit1, yBoxLine1, wBoxAudit2, hBoxLine1App1);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectFAudit2));

                    float wBoxLin1Store = 25;
                    RectangleF rectFAudit3 = new RectangleF(xBoxAudit1 + wBoxAudit1 + wBoxAudit2, yBoxLine1, wBoxLin1Store, hBoxLine1App1);
                    e.Graphics.DrawString("สโตร์", drawFont, Brushes.Black, rectFAudit3, drawFormat);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectFAudit3));

                    float wBoxPrepare1 = 35;
                    float xBoxPrepare1 = xBoxAudit1 + wBoxAudit1 + wBoxAudit2 + wBoxLin1Store + 5;
                    RectangleF rectFPrepare1 = new RectangleF(xBoxPrepare1, yBoxLine1, wBoxPrepare1, hBoxLine1App1);
                    e.Graphics.DrawString("ผู้เตรียม", drawFont, Brushes.Black, rectFPrepare1, drawFormat);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectFPrepare1));

                    float wBoxPrepare2 = 70;
                    RectangleF rectFPrepare2 = new RectangleF(xBoxPrepare1 + wBoxPrepare1, yBoxLine1, wBoxPrepare2, hBoxLine1App1);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectFPrepare2));

                    #endregion
                    #region Line2
                    float wBoxOrderTo = 90;
                    float xBoxOrderTo = 5;
                    float yTextLine2 = yTextLine1 + 20;
                    RectangleF rectOrderTo = new RectangleF(xBoxOrderTo, yTextLine2, wBoxOrderTo, hBoxLine1App1);
                    e.Graphics.DrawString("ถึง:คุณ " + order.ToOwner, drawFont, Brushes.Black, rectOrderTo, drawFormatLeft);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectOrderTo));

                    float xTextTopic = wBoxOrderTo + 10;
                    float yextTopic = yTextLine2 + 5;
                    e.Graphics.DrawString("เรื่อง : ", drawFont, Brushes.Black, xTextTopic, yextTopic);

                    float wBoxTopic = 200;
                    float xBoxTopic = xTextTopic + 25;
                    RectangleF rectTopic = new RectangleF(xBoxTopic, yTextLine2, wBoxTopic, hBoxLine1App1);
                    e.Graphics.DrawString("" + order.Topic, drawFont, Brushes.Black, rectTopic, drawFormatLeft);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectTopic));

                    float xSuggestOrder = xBoxAudit1;
                    float wSugestOrder = wBoxAudit1 + wBoxAudit2 + wBoxLin1Store;
                    RectangleF rectSuggestOrder = new RectangleF(xSuggestOrder, yTextLine2, wSugestOrder, hBoxLine1App1);
                    e.Graphics.DrawString("จำนวนสั่งทำ/ซื้อ " + order.Suggest_Order + "  " + order.PUnit_Name, drawFont, Brushes.Black, rectSuggestOrder, drawFormatLeft);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectSuggestOrder));

                    float xMinStock = xBoxPrepare1;
                    float wMinStock = wBoxPrepare1 + wBoxPrepare2;
                    RectangleF rectMin = new RectangleF(xMinStock, yTextLine2, wMinStock, hBoxLine1App1);
                    e.Graphics.DrawString("min  " + order.MinumunStock + "  " + order.PUnit_Name, drawFont, Brushes.Black, rectMin, drawFormatLeft);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectMin));
                    #endregion
                    #region Line3
                    float xLine3 = xBoxOrderTo;
                    float yLine3 = yTextLine2 + 37;

                    Point point1 = new Point((int)xLine3 + 40, (int)yLine3);
                    Point point2 = new Point((int)xMinStock + (int)wMinStock, (int)yLine3);

                    e.Graphics.DrawString(order.Product_code + "  " + order.Product_Name, drawFont, Brushes.Black, xLine3, yLine3 - 15);
                    e.Graphics.DrawLine(new Pen(Color.Black, 0.5f), point1, point2);
                    #endregion
                    #region Line4
                    float xLine4 = xBoxOrderTo;
                    float yLine4 = yLine3 + 20;

                    Point point41 = new Point((int)xLine4, (int)yLine4);
                    Point point42 = new Point((int)xMinStock + (int)wMinStock, (int)yLine4);

                    e.Graphics.DrawString("use : " + order.Use, drawFont, Brushes.Black, xLine4, yLine4 - 15);
                    e.Graphics.DrawLine(new Pen(Color.Black, 0.5f), point41, point42);
                    #endregion
                    #region
                    float wBoxtManager = 80;
                    float xBoxtManager = xLine4;
                    float yLineManager = yLine4;
                    float hBoxManager = 30;
                    RectangleF rectManager = new RectangleF(xBoxtManager, yLineManager, wBoxtManager, hBoxManager);
                    e.Graphics.DrawString("หัวหน้าแผนก หรือ ผจก.ฝ่ายนั้นๆเซ็น", drawFont, Brushes.Black, rectManager, drawFormatLeft);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectManager));
                    e.Graphics.DrawString("..................... ว/ด/ป ............. จำนวนส่งงานเข้า ................ ผู้ส่ง ................. ว/ด/ป...............", drawFont, Brushes.Black, xBoxtManager + wBoxtManager, yLineManager + 15);
                    #endregion
                    #region Line5,6,7
                    float xLine5 = xBoxOrderTo;
                    float yLine5 = yLine4 + 47;

                    Point point51 = new Point((int)xLine5, (int)yLine5);
                    Point point52 = new Point((int)xSuggestOrder + (int)wSugestOrder, (int)yLine5);

                    e.Graphics.DrawString("Note Vender : " + order.Note_Vendor, drawFont, Brushes.Black, xLine5, yLine5 - 13);
                    e.Graphics.DrawLine(new Pen(Color.Black, 0.5f), point51, point52);

                    float yLine6 = yLine5 + 17;
                    Point point61 = new Point((int)xLine5, (int)yLine6);
                    Point point62 = new Point((int)xSuggestOrder + (int)wSugestOrder, (int)yLine6);

                    e.Graphics.DrawString("ชื่อสั่งซื้อ : " + order.Purchase_Name, drawFont, Brushes.Black, xLine5, yLine6 - 13);
                    e.Graphics.DrawLine(new Pen(Color.Black, 0.5f), point61, point62);

                    float yLine7 = yLine6 + 17;
                    Point point71 = new Point((int)xLine5, (int)yLine7);
                    Point point72 = new Point((int)xSuggestOrder + (int)wSugestOrder, (int)yLine7);

                    e.Graphics.DrawString("Code บ/ช : " + order.AccountCode, drawFont, Brushes.Black, xLine5, yLine7 - 13);
                    e.Graphics.DrawLine(new Pen(Color.Black, 0.5f), point71, point72);

                    float xLine8 = xTextTopic;
                    float yLine8 = yLine7 + 7;
                    e.Graphics.DrawString("รับสำเนาแล้ว ลงชื่อ __________________(                       ) วันที่ __________________", drawFont, Brushes.Black, xLine8, yLine8);
                    #endregion
                    #region boxRight
                    float xBoxRight = xBoxPrepare1;
                    float yBoxRigth = yLine4;
                    float wBoxRight = 40;
                    float hBoxRight = 80;
                    RectangleF rectBoxRight1 = new RectangleF(xBoxRight, yBoxRigth, wBoxRight, hBoxRight);
                    e.Graphics.DrawString("เหลือ LP\nที่ตั้ง LP\nเหลือ TD\nที่ตั้ง TD\nเหลือรวม", drawFont, Brushes.Black, rectBoxRight1);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectBoxRight1));

                    float wBoxRight2 = 70;
                    RectangleF rectBoxRight2 = new RectangleF(xBoxRight + wBoxRight, yBoxRigth, wBoxRight2, hBoxRight);
                    e.Graphics.DrawString(order.RemainLP + "  " + order.SUnit_Name + "\n0\n" + order.ReaminTD + "  " + order.SUnit_Name + "\n0\n" + order.RemainAll + "  " + order.SUnit_Name + "", drawFont, Brushes.Black, rectBoxRight2);
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 0.5f), Rectangle.Round(rectBoxRight2));


                    float xLineR1 = xBoxRight;
                    float yLineR1 = yBoxRigth + 33;
                    float xEndR1 = xBoxRight + wBoxRight + wBoxRight2;

                    Point pointR1 = new Point((int)xLineR1, (int)yLineR1);
                    Point pointR2 = new Point((int)xEndR1, (int)yLineR1);
                    e.Graphics.DrawLine(new Pen(Color.Black, 0.5f), pointR1, pointR2);

                    float xLineR2 = xBoxRight;
                    float yLineR2 = yLineR1 + 30;


                    Point pointR3 = new Point((int)xLineR2, (int)yLineR2);
                    Point pointR4 = new Point((int)xEndR1, (int)yLineR2);
                    e.Graphics.DrawLine(new Pen(Color.Black, 0.5f), pointR3, pointR4);
                    #endregion
                    
                    lineperpage++;
                    i++;
                    if (lineperpage >= 4)
                    {
                        lineperpage = 0;
                        e.HasMorePages = true;
                        return;
                    }
                }
                i = 0;
                e.HasMorePages = false;
                log.Info("Print Document success.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }


        }
        private void buttonPrint_Click(object sender, EventArgs e) {
            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button_Preview_Click(object sender, EventArgs e) {
           
            previewDlg = new PrintPreviewDialog();
            previewDlg.PrintPreviewControl.Zoom = 1.0;
            previewDlg.WindowState = FormWindowState.Maximized;

            //Create a PrintDocument object
            PaperSize pkCustomSize1 = new PaperSize("A4", 827, 1169);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = pkCustomSize1;
            //Add print-page event handler
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            //Set Document property of PrintPreviewDialog
            previewDlg.Document = pd;

            //Display dialog
            previewDlg.Show();
        }
        public void print_Preview() {
            //printPreviewDialog1.Document = printDocument1;  
            // Show PrintPreview Dialog
            //printPreviewDialog1.ShowDialog();


            // PaperSize pkCustomSize1 = new PaperSize("A4", 827, 1169);
            // printDocument1.DefaultPageSettings.PaperSize = pkCustomSize1;
            //printPreviewDialog1.Document = printDocument1;           
            //// Show PrintPreview Dialog

            //printPreviewDialog1.ShowDialog();

            //Create a PrintPreviewDialog object

            previewDlg = new PrintPreviewDialog();
            previewDlg.PrintPreviewControl.Zoom = 1.0;
            previewDlg.WindowState = FormWindowState.Maximized;

            //Create a PrintDocument object
            PaperSize pkCustomSize1 = new PaperSize("A4", 827, 1169);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = pkCustomSize1;
            //Add print-page event handler
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            //Set Document property of PrintPreviewDialog
            previewDlg.Document = pd;
            previewDlg.ShowDialog();
        }
        public void print_Preview(List<OrderListModel> _lsOrder) {

            lsOrder = _lsOrder;
            previewDlg = new PrintPreviewDialog();

            ToolStripButton b = new ToolStripButton();
            b.ImageIndex = ((ToolStripButton)((ToolStrip)previewDlg.Controls[1]).Items[0]).ImageIndex;

            ((ToolStrip)previewDlg.Controls[1]).Items.Remove(((ToolStripButton)((ToolStrip)previewDlg.Controls[1]).Items[0]));
            b.Visible = true;
            ((ToolStrip)previewDlg.Controls[1]).Items.Insert(0, b);
            ((ToolStripButton)((ToolStrip)previewDlg.Controls[1]).Items[0]).Click += new System.EventHandler(buttonPrint_Click);


            previewDlg.PrintPreviewControl.Zoom = 1.0;
            previewDlg.WindowState = FormWindowState.Maximized;

            //Create a PrintDocument object
            PaperSize pkCustomSize1 = new PaperSize("A4", 827, 1169);
            pd.DefaultPageSettings.PaperSize = pkCustomSize1;
            //Add print-page event handler
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            //Set Document property of PrintPreviewDialog
            previewDlg.Document = pd;
            //printDocument1.PrinterSettings.PrinterName = printDialog1.PrinterSettings.PrinterName;
            previewDlg.ShowDialog();


           
        }


        PaperSize paperSize = new PaperSize("papersize", 150, 500);//set the paper size
        int totalnumber = 0;
        int itemperpage = 0;
        int linesPrinted = 0;
        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e) {

            float x = (float)e.MarginBounds.Left;
            float y = (float)e.MarginBounds.Top;
            Font drawFont = new Font("CordiaUPC", 10);
            while (linesPrinted < 100)
            {
                e.Graphics.DrawString("" + (linesPrinted++), drawFont, Brushes.Black, x, y);
                y += 20;
                
                itemperpage++;
                if (itemperpage > 19)
                {
                    itemperpage = 0;
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;


        }

        private void button2_Click(object sender, EventArgs e) {

            this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog2.Document = this.printDocument2;
            this.printPreviewDialog2.Enabled = true;
            this.printPreviewDialog2.Location = new System.Drawing.Point(88, 116);
            this.printPreviewDialog2.MaximumSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog2.Name = "printPreviewDialog2";
            this.printPreviewDialog2.Opacity = 1;
            this.printPreviewDialog2.TransparencyKey = System.Drawing.Color.Empty;
            this.printPreviewDialog2.Visible = false;

            printPreviewDialog2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            printDialog2.Document = printDocument2;

            if (printDialog2.ShowDialog() == DialogResult.OK)
            {
                
                printDocument2.Print();
            }
        }
    }
}
