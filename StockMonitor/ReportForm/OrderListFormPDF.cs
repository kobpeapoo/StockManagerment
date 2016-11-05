using System;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using InventoryManagerment.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using InventoryManagerment.Views;

namespace InventoryManagerment.ReportForm {

    public class OrderListFormPDF {
        int List_Num_Order = 0;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public OrderListFormPDF() { }

        public int InsertToTable_Report(List<ProductsModel> lsProductReport, string currentDate) {
            DateTime now = DateTime.Now;
            int Order_ID = 0;
            try
            {
                string sqlCheckDate = "select TOP 1 Order_ID  from Product_Order_Report where CreateDate = '" + currentDate + "'";
                using (SqlConnection cnn = new SqlConnection(Utility.ConnectionDb.connectString))
                {
                    cnn.Open();
                    log.Debug("Connect Database success.");

                    try
                    {
                        using (IDbTransaction tran = cnn.BeginTransaction())
                        {
                            try
                            {
                                string sqlInsert1 = "INSERT INTO Product_Order_Report VALUES(@currentDate,@CreateTimestamp);";
                                using (SqlCommand cmd1 = new SqlCommand(sqlCheckDate, cnn), cmd2 = new SqlCommand(sqlInsert1, cnn))
                                {
                                    cmd2.Parameters.AddWithValue("currentDate", currentDate);
                                    cmd2.Parameters.AddWithValue("CreateTimestamp", now.ToString("HH:mm:ss"));
                                    if (Order_ID == 0)
                                    {//Alway Isert New data
                                        cmd2.Transaction = tran as SqlTransaction;
                                        cmd2.ExecuteNonQuery();
                                        log.Debug("Query Insert New data " + sqlInsert1);
                                    }
                                }
                                string sqlMax = "select MAX(Order_ID) as Order_ID FROM Product_Order_Report";
                                using (SqlCommand cmdMax = new SqlCommand(sqlMax, cnn))
                                {
                                    cmdMax.Transaction = tran as SqlTransaction;
                                    using (SqlDataReader data = cmdMax.ExecuteReader())
                                    {
                                        while (data.Read())
                                        {
                                            Order_ID = Convert.ToInt32(data["Order_ID"]);
                                        }
                                    }
                                    log.Debug("After Inserted then query MAX ID " + sqlMax);
                                }
                                tran.Commit();
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                log.Error(ex);
                                log.Error("Transaction Rollback.");
                                throw ex;
                            }

                        }
                        string strListNum = "";
                        using (IDbTransaction tran = cnn.BeginTransaction())
                        {
                            try
                            {

                                string sqlListNum = "select MAX(List_Num_Order) as List_Num_Order from Product_Order_Report_Details  WHERE Order_ID IN (Select Order_ID from Product_Order_Report where CreateDate = '" + currentDate + "')";
                                using (SqlCommand cmdMax = new SqlCommand(sqlListNum, cnn))
                                {
                                    cmdMax.Transaction = tran as SqlTransaction;
                                    using (SqlDataReader data = cmdMax.ExecuteReader())
                                    {
                                        while (data.Read())
                                        {
                                            strListNum = data["List_Num_Order"].ToString();
                                        }
                                    }
                                    log.Debug("Order_ID is alreay exist then select Max List mumber order." + sqlListNum);
                                }
                                tran.Commit();
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                log.Error(ex);
                                log.Error("Transaction Rollback.");
                                throw ex;
                            }
                        }

                        if (strListNum == null || strListNum.Equals(""))
                        {
                            List_Num_Order = 0;
                        }
                        else {
                            List_Num_Order = Convert.ToInt32(strListNum);
                        }

                        using (IDbTransaction tran = cnn.BeginTransaction())
                        {
                            try
                            {
                                int i = List_Num_Order;
                                foreach (ProductsModel p in lsProductReport)
                                {
                                    string SqlInsertDetail = "INSERT INTO Product_Order_Report_Details (FDDATE,Product_Code,Order_ID,List_Num_Order,P_Amount,PUnit_Name,Order_to,Operation_Detail,Suggest_Order,SUnit_Name,Min_Stock,TD_QTY,LP_QTY,TOTAL_QTY,Note_Vendor,Purchase_Name,P0,P1,P2,P3,P_Note,Order_Status,Vendor) "
                            + "VALUES " +
                            "(@FDDATE,@Product_Code,@Order_ID,@i,@P_Amount,@PUnit_Name,@Order_to,@Use,@Suggest_Order" +
                            ",@SUnit_Name,@Min_Stock,@TD_QTY,@LP_QTY,@TOTAL_QTY,@Note_Vendor,@Vendor_to_Purchase,@P0,@P1,@P2,@P3,@P_Note,0,@Vendor)";
                                    using (SqlCommand cmdInsertLs = new SqlCommand(SqlInsertDetail, cnn))
                                    {
                                        cmdInsertLs.Transaction = tran as SqlTransaction;

                                        cmdInsertLs.Parameters.AddWithValue("FDDATE", p.FDDATE);
                                        cmdInsertLs.Parameters.AddWithValue("Product_Code", p.Product_Code);
                                        cmdInsertLs.Parameters.AddWithValue("Order_ID", Order_ID);
                                        cmdInsertLs.Parameters.AddWithValue("i", ++i);
                                        cmdInsertLs.Parameters.AddWithValue("P_Amount", 0);
                                        cmdInsertLs.Parameters.AddWithValue("PUnit_Name", p.PUnit_Name);
                                        cmdInsertLs.Parameters.AddWithValue("Order_to", p.Order_to);
                                        cmdInsertLs.Parameters.AddWithValue("Use", p.Use);
                                        cmdInsertLs.Parameters.AddWithValue("Suggest_Order", Convert.ToDouble(p.Suggest_Order));
                                        cmdInsertLs.Parameters.AddWithValue("SUnit_Name", p.SUnit_Name);
                                        cmdInsertLs.Parameters.AddWithValue("Min_Stock", Convert.ToDouble(p.Min_Stock));
                                        cmdInsertLs.Parameters.AddWithValue("TD_QTY", Convert.ToDouble(p.TD_QTY));
                                        cmdInsertLs.Parameters.AddWithValue("LP_QTY", Convert.ToDouble(p.LP_QTY));
                                        cmdInsertLs.Parameters.AddWithValue("TOTAL_QTY", Convert.ToDouble(p.TOTAL_QTY));
                                        cmdInsertLs.Parameters.AddWithValue("Note_Vendor", p.Note_Vendor);
                                        cmdInsertLs.Parameters.AddWithValue("Vendor_to_Purchase", p.Vendor_to_Purchase);
                                        cmdInsertLs.Parameters.AddWithValue("P0", p.P0);
                                        cmdInsertLs.Parameters.AddWithValue("P1", p.P1);
                                        cmdInsertLs.Parameters.AddWithValue("P2", p.P2);
                                        cmdInsertLs.Parameters.AddWithValue("P3", p.P3);
                                        cmdInsertLs.Parameters.AddWithValue("P_Note", p.P_Note);
                                        cmdInsertLs.Parameters.AddWithValue("Vendor", p.Vendor);

                                        cmdInsertLs.ExecuteNonQuery();
                                    }
                                }
                                //values = values.Substring(0, values.Length - 1);

                                //SqlInsertDetail += values;      

                                tran.Commit();
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                log.Error(ex);
                                log.Error("Transaction Rollback.");
                                throw ex;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        log.Error("Transaction Rollback.");
                        throw ex;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Order_ID;
        }
        public void CreatePrintPreView(int Order_ID) {
            try
            {
                List<OrderListModel> lsOrder = new List<OrderListModel>();
                string sql_Product_Report = "select a.*,b.*,c.Product_Name from Product_Order_Report a " +
                    " Inner join Product_Order_Report_Details b " +
                    " ON a.Order_ID = b.Order_ID " +
                    " Inner join V_PRODUCT_MONITOR_PROPERTIES c " +
                    " ON c.Product_Code = b.Product_Code " +
                    " where a.Order_ID = " + Order_ID + " " +
                    " ORDER BY b.List_Num_Order ";
                using (SqlConnection cnn = new SqlConnection(Utility.ConnectionDb.connectString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql_Product_Report, cnn))
                    {
                        using (SqlDataReader data = cmd.ExecuteReader())
                        {
                            while (data.Read())
                            {
                                OrderListModel order = new OrderListModel();
                                order.CreateDate = data["CreateDate"].ToString();
                                order.List_Num_Order = data["List_Num_Order"].ToString();
                                order.MinumunStock = Convert.ToDouble(data["Min_Stock"].ToString());
                                order.Product_code = data["Product_Code"].ToString();
                                order.Product_Name = data["Product_Name"].ToString();
                                order.ReaminTD = Convert.ToDouble(data["TD_QTY"].ToString());
                                order.RemainLP = Convert.ToDouble(data["LP_QTY"].ToString());
                                order.RemainAll = Convert.ToDouble(data["TOTAL_QTY"].ToString());
                                order.Suggest_Order = Convert.ToDouble(data["Suggest_Order"].ToString());
                                order.ToOwner = data["Order_to"].ToString();
                                order.Topic = data["Vendor"].ToString();
                                order.Use = data["Operation_Detail"].ToString();
                                order.Note_Vendor = data["Note_Vendor"].ToString();
                                order.Purchase_Name = data["Purchase_Name"].ToString();
                                order.AccountCode = "ราคาตั้ง : ";
                                order.PUnit_Name = data["PUnit_Name"].ToString();
                                order.SUnit_Name = data["SUnit_Name"].ToString();
                                order.CreateTimestamp = data["CreateTimestamp"].ToString();
                                lsOrder.Add(order);
                            }
                        }
                    }

                }
                
                PrintDocOrderReportForm print = new PrintDocOrderReportForm();
                print.print_Preview(lsOrder);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }


        }
        public void createPrintDocPDF(int Order_Id) {

            List<ProductsModel> lsProductReport = new List<ProductsModel>();
            Rectangle rec = new Rectangle(PageSize.A4);
            Document doc = new Document(rec, 16, 16, 16, 16);
            DateTime now = DateTime.Now;
            string fileName = "D:\\reportOrder_" + now.ToString("yyyyMMddHHmmss") + ".pdf";
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            float ySubPage = 210;
            int j = 0;
            int numberOfOrder = List_Num_Order;
            foreach (ProductsModel p in lsProductReport)
            {//4 pices per page
                numberOfOrder++;
                if (j == 0)
                {
                    doc.NewPage();//New Page
                }
                float w = doc.PageSize.Width;//595
                float h = doc.PageSize.Height;//842
                PdfContentByte cb = writer.DirectContent;
                float xTextHead = 20;
                float yTextHead = h - 20 - (ySubPage * j);
                cb.BeginText();
                cb.SetFontAndSize(GetTahoma().BaseFont, 9f);//Set the font information           
                cb.MoveText(20, yTextHead);//Position the cursor for drawing
                string docCode = "" + numberOfOrder.ToString().PadLeft(4, '0');
                string createDateTimeDoc = now.ToString("dd/MM/yyyy") + "   " + now.ToString("HH:mm") + " น.";
                cb.ShowText(docCode + "  ใบสั่งงานย่อย/ใบสั่งงาน  " + createDateTimeDoc); //Write some text
                cb.EndText();

                #region box1
                float xBox1 = 260;
                float yBox1 = h - 25 - (ySubPage * j);
                float wBox1 = 80;
                float hBox1 = 20;

                cb.BeginText();
                cb.SetFontAndSize(GetTahoma().BaseFont, 9f);
                cb.MoveText(xBox1 + 3, yBox1 + 5);
                cb.ShowText("ผู้อนุมัติ");
                cb.EndText();


                cb.Rectangle(xBox1, yBox1, wBox1, hBox1);//X,Y,W,H
                cb.Stroke();
                float xLine1 = xBox1 + 35;
                float yLine1 = h - 5 - (ySubPage * j);
                cb.MoveTo(xLine1, yBox1);
                cb.LineTo(xLine1, yLine1);
                cb.Stroke();
                #endregion

                #region box2
                float xBox2 = xBox1 + wBox1 + 5;
                float yBox2 = yBox1;
                float wbox2 = 130;
                float hBox2 = hBox1;

                cb.BeginText();
                cb.MoveText(xBox2 + 3, yBox2 + 5);
                cb.ShowText("ผู้ตรวจสอบ");
                cb.EndText();

                cb.Rectangle(xBox2, yBox2, wbox2, hBox2);//X,Y,W,H
                cb.Stroke();

                float xLine2 = xBox2 + 45;
                float yLine2 = yLine1;
                cb.MoveTo(xLine2, yBox2);
                cb.LineTo(xLine2, yLine2);
                cb.Stroke();

                cb.BeginText();
                cb.MoveText(xBox2 + 3, yBox2 + 5);
                cb.ShowText("ผู้ตรวจสอบ");
                cb.EndText();

                cb.BeginText();
                cb.MoveText(xBox2 + 100, yBox2 + 5);
                cb.ShowText("สโตร์");
                cb.EndText();
                cb.MoveTo(xLine2 + 50, yBox2);
                cb.LineTo(xLine2 + 50, yLine2);
                cb.Stroke();
                #endregion

                #region Box3
                float xBox3 = xBox2 + wbox2 + 5;
                float yBox3 = yBox1;
                float wbox3 = wBox1 + 20;
                float hBox3 = hBox1;

                cb.BeginText();
                cb.MoveText(xBox3 + 3, yBox3 + 5);
                cb.ShowText("ผู้เตรียม");
                cb.EndText();

                cb.Rectangle(xBox3, yBox3, wbox3, hBox3);//X,Y,W,H
                cb.Stroke();

                float xLine3 = xBox3 + 40;
                float yLine3 = yLine1;
                cb.MoveTo(xLine3, yBox3);
                cb.LineTo(xLine3, yLine3);
                cb.Stroke();
                #endregion

                #region Line2
                float xBox_OrderTo = xTextHead;
                float yBox_OrderTo = yBox3 - 17;
                float wBox_OrderTo = 130;
                float hBox_OrderTo = 15;

                cb.BeginText();
                cb.MoveText(xBox_OrderTo + 3, yBox_OrderTo + 5);
                cb.ShowText("ถึง :คุณ " + p.Order_to);
                cb.EndText();

                cb.Rectangle(xBox_OrderTo, yBox_OrderTo, wBox_OrderTo, hBox_OrderTo);//X,Y,W,H
                cb.Stroke();



                float xBox_Topic = xBox_OrderTo + 150;
                float yBox_Topic = yBox_OrderTo;
                float wBox_Topic = 145;
                float hBox_Topic = hBox_OrderTo;
                cb.BeginText();
                cb.MoveText(xBox_Topic, yBox_OrderTo + 5);
                cb.ShowText("เรื่อง : " + p.Vendor);
                cb.EndText();

                cb.Rectangle(xBox_Topic + 25, yBox_Topic, wBox_Topic, hBox_Topic);//X,Y,W,H
                cb.Stroke();

                float xBox_Order = xBox_Topic + 180;
                float yBox_Order = yBox_Topic;
                float wBox_Order = 130;
                float hBox_Order = hBox_Topic;
                cb.BeginText();
                cb.SetFontAndSize(GetTahoma().BaseFont, 7f);
                cb.MoveText(xBox_Order, yBox_Order + 5);
                cb.ShowText("จำนวนสั่งทำ/ซื้อ          " + p.Suggest_Order + "   " + p.PUnit_Name);
                cb.EndText();
                cb.Rectangle(xBox_Order - 5, yBox_Order, wBox_Order, hBox_Order);//X,Y,W,H
                cb.Stroke();

                float xBox_Min = xBox3 + 5;
                float yBox_Min = yBox_Order;
                float wBox_Min = 100;
                float hBox_Min = hBox_Order;

                cb.BeginText();
                cb.SetFontAndSize(GetTahoma().BaseFont, 9f);
                cb.MoveText(xBox_Min, yBox_Min + 5);
                cb.ShowText("min     " + p.Min_Stock + "   " + p.SUnit_Name);
                cb.EndText();
                cb.Rectangle(xBox_Min - 5, yBox_Min, wBox_Min, hBox_Min);//X,Y,W,H
                cb.Stroke();
                #endregion
                #region Line3
                float xLine_productName = xTextHead;
                float yLine_ProductName = yBox_OrderTo - 13;

                cb.BeginText();
                cb.SetFontAndSize(GetTahoma().BaseFont, 9f);
                cb.MoveText(xLine_productName, yLine_ProductName);
                cb.ShowText(p.Product_Code + " : " + p.Product_Name);
                cb.EndText();

                //float yLine_productUnder = 
                cb.MoveTo(xLine_productName + 2, yLine_ProductName - 3);
                cb.LineTo(575, yLine_ProductName - 3);
                cb.Stroke();
                #endregion
                #region Line4
                float xLine_use = xLine_productName;
                float yline_use = yLine_ProductName - 15;

                cb.BeginText();
                cb.MoveText(xLine_use, yline_use);
                cb.ShowText("use : " + p.Use);
                cb.EndText();

                cb.MoveTo(xLine_use, yline_use - 3);
                cb.LineTo(575, yline_use - 3);
                cb.Stroke();

                #endregion
                #region line5
                float xbox5 = xLine_use;
                float ybox5 = yline_use - 23;
                float wBox5 = 67;
                float hBox5 = 20;
                float yTextInBox5 = ybox5 + 11;
                cb.Rectangle(xbox5, ybox5, wBox5, hBox5);//X,Y,W,H
                cb.Stroke();

                cb.BeginText();
                cb.SetFontAndSize(GetTahoma().BaseFont, 8f);
                cb.MoveText(xbox5 + 2, yTextInBox5);
                cb.ShowText("หัวหน้าแผนก หรือ");
                cb.EndText();
                cb.BeginText();
                cb.MoveText(xbox5 + 2, yTextInBox5 - 8);
                cb.ShowText("ผจก. ฝ่ายนั้นๆ เซ็น   ...........................  ว/ด/ป ................. จำนวนส่งงานเข้า ........................ ผู้ส่ง .................. ว/ด/ป ..................");
                cb.EndText();
                #endregion
                #region Lin6,7,8
                float xLine6 = xbox5;
                float yLin6 = ybox5 - 15;
                float xEndLine6 = 473;
                cb.MoveTo(xLine6, yLin6);
                cb.LineTo(xEndLine6, yLin6);
                cb.Stroke();
                float yLine7 = yLin6 - 15;
                cb.MoveTo(xLine6, yLine7);
                cb.LineTo(xEndLine6, yLine7);
                cb.Stroke();
                float yLine8 = yLine7 - 15;
                cb.MoveTo(xLine6, yLine8);
                cb.LineTo(xEndLine6, yLine8);
                cb.Stroke();
                #endregion
                #region lin9
                float xline9_sign = 150;
                float yLine9_sign = yLine8 - 20;
                cb.BeginText();
                cb.SetFontAndSize(GetTahoma().BaseFont, 9f);
                cb.MoveText(xline9_sign, yLine9_sign);
                cb.ShowText("รับสำเนาแล้ว  ลงชื่อ __________________ (                       ) วันที่ ____________");
                cb.EndText();
                #endregion
                #region box QTY
                float xBoxQty = 480;
                float yBoxQty = ybox5 - 70;
                float wBoxQty = 100;
                float hBoxQty = 90;
                cb.Rectangle(xBoxQty, yBoxQty, wBoxQty, hBoxQty);
                cb.Stroke();

                float xLineBoxQty = xBoxQty + 40;
                cb.MoveTo(xLineBoxQty, yBoxQty);//Vertical
                cb.LineTo(xLineBoxQty, yBoxQty + hBoxQty);
                cb.Stroke();

                float yLineHoBoxQty = yBoxQty + 55;
                cb.MoveTo(xBoxQty, yLineHoBoxQty);//Hori
                cb.LineTo(580, yLineHoBoxQty);
                cb.Stroke();

                float yTextRemainLP = yLineHoBoxQty + 25;
                cb.BeginText();
                cb.MoveText(xBoxQty + 2, yTextRemainLP);
                cb.ShowText("เหลือ LP       " + p.LP_QTY + "   " + p.SUnit_Name);
                cb.EndText();
                cb.BeginText();
                cb.MoveText(xBoxQty + 2, yTextRemainLP - 18);
                cb.ShowText("ที่ตั้ง LP");
                cb.EndText();


                cb.MoveTo(xBoxQty, yLineHoBoxQty - 30);//Hori
                cb.LineTo(580, yLineHoBoxQty - 30);
                cb.Stroke();

                float yTextRemainTD = yTextRemainLP - 18 - 18;
                cb.BeginText();
                cb.MoveText(xBoxQty + 2, yTextRemainTD);
                cb.ShowText("เหลือ TD     " + p.TD_QTY + "   " + p.SUnit_Name);
                cb.EndText();
                cb.BeginText();
                cb.MoveText(xBoxQty + 2, yTextRemainTD - 15);
                cb.ShowText("ที่ตั้ง TD");
                cb.EndText();

                float yTextTotalQty = yTextRemainTD - 15;
                cb.BeginText();
                cb.MoveText(xBoxQty + 2, yTextTotalQty - 18);
                cb.ShowText("เหลือรวม     " + p.TOTAL_QTY + "   " + p.SUnit_Name);
                cb.EndText();

                #endregion
                j++;
                if (j == 4)
                {
                    j = 0;
                }

            }
            doc.Close();
        }
        public static Font GetTahoma() {
            //var fontName = "Tahoma";
            var fontName = "Tahoma";
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\tahoma.ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }
    }
}
