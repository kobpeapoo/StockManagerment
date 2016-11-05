using InventoryManagerment.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using InventoryManagerment.ReportForm;
using InventoryManagerment.Utility;
using InventoryManagerment.Control;
using System.Windows.Data;

namespace InventoryManagerment.Views {
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : Window {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<ProductsModel> lsProd = null;
        string cond = "";
        string dateCond = "";
        string condRadio = "";
        string loadForm = null;
        int Order_Id = 0;
        CommonUtill comm = new CommonUtill();
        DateTime now = DateTime.Now;
        public ProductsView() {

            //string years = (Convert.ToInt32(now.ToString("yyyy")) + 543).ToString();
            string years = (Convert.ToInt32(now.ToString("yyyy"))).ToString();
            string month = now.ToString("MM");
            string day = now.ToString("dd");
            dateCond = years + "" + month + "" + day;
            
            dateCond = "25591104";
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            
            textCurentDate.Text = comm.convertIntToDate(dateCond);

            log.Debug("Date Condition : " + dateCond);
            log.Debug("Current Date : " + textCurentDate.Text);
            //genData();
            //loadForm = "loaded";
        }
        private void genData() {
            lsProd = new List<ProductsModel>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(Utility.ConnectionDb.connectString))
                {
                    log.Debug("Connect Sqlserver Success.");
                    cnn.Open();
                    string sql = "SELECT * FROM V_PRODUCT_MONITOR_PROPERTIES a "
                        + "INNER JOIN(SELECT c.* FROM "
                        + "V_STOCK_MONITOR c "
                        + "INNER JOIN(SELECT PRODUCT_CODE, MAX(FDDATE) FDDATE FROM V_STOCK_MONITOR "
                        + "WHERE FDDATE <= '" + dateCond + "' "
                        + "GROUP BY PRODUCT_CODE) d ON c.PRODUCT_CODE = d.PRODUCT_CODE AND c.FDDATE = d.FDDATE) b "
                        + "ON LOWER(a.Product_Code) = LOWER(b.PRODUCT_CODE) COLLATE Thai_CI_AI "
                        + "WHERE 1=1 " + cond + condRadio+ " ORDER BY a.Product_Code ASC";
                    log.Debug("Sql Statement : " + sql);
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            int i = 0;
                            while (dataReader.Read())
                            {
                                ProductsModel prod = new ProductsModel();
                                prod.RowNum = ++i;
                                prod.HaveToOder = 0;
                                //log.Debug(dataReader["Product_Code"].ToString());
                                //Check เคลื่อนไหว
                                if (dataReader["FDDATE"].ToString().Trim().Equals(dateCond))
                                {
                                    double minStock = Convert.ToDouble(dataReader["Min_Stock"].ToString().Trim());
                                    double total_qty = Convert.ToDouble(dataReader["TOTAL_QTY"].ToString().Trim());
                                    //double diffStock = Convert.ToDouble(dataReader["DIFF_TD_QTY"].ToString().Trim()) + Convert.ToDouble(dataReader["DIFF_LP_QTY"].ToString().Trim());
                                    double minStock10 = (minStock * 0.1) + minStock;
                                    if (minStock10 >= total_qty && (Convert.ToDouble(dataReader["DIFF_TD_QTY"].ToString().Trim()) != 0 || Convert.ToDouble(dataReader["DIFF_LP_QTY"].ToString().Trim()) != 0))
                                    {
                                        prod.HaveToOder = 1;
                                    } else if (minStock==0 && total_qty==0&& (Convert.ToDouble(dataReader["DIFF_TD_QTY"].ToString().Trim()) != 0 || Convert.ToDouble(dataReader["DIFF_LP_QTY"].ToString().Trim()) != 0)) {
                                        prod.HaveToOder = 1;
                                    }

                                }



                                prod.Select_Product = false;

                                prod.FDDATE = dataReader["FDDATE"].ToString().Trim();
                                prod.TD_QTY = comm.convertShowNumber2Point(dataReader["TD_QTY"].ToString().Trim());
                                prod.LP_QTY = comm.convertShowNumber2Point(dataReader["LP_QTY"].ToString().Trim());
                                prod.TOTAL_QTY = comm.convertShowNumber2Point(dataReader["TOTAL_QTY"].ToString().Trim());

                                prod.Product_Code = dataReader["Product_Code"].ToString().Trim();
                                prod.Product_Name = dataReader["Product_Name"].ToString().Trim();
                                prod.Use = dataReader["Operation_Detail"].ToString().Trim();
                                prod.Order_to = dataReader["Order_to"].ToString().Trim();
                                prod.Product_Type = dataReader["Product_Type"].ToString().Trim();
                                prod.Stock_Unit_Code = dataReader["Stock_Unit"].ToString().Trim();
                                prod.SUnit_Name = dataReader["SUnit_Name"].ToString().Trim();
                                prod.PUnit_Code = dataReader["Purchase_Unit"].ToString().Trim();
                                prod.PUnit_Name = dataReader["PUnit_Name"].ToString().Trim();
                                prod.Min_Stock = comm.convertShowNumber2Point(dataReader["Min_Stock"].ToString().Trim());
                                prod.Suggest_Order = comm.convertShowNumber2Point(dataReader["Suggest_Order"].ToString().Trim());
                                prod.Factor = comm.convertShowNumber2Point(dataReader["FACTOR"].ToString().Trim());
                                prod.Check_LP = dataReader["Check_LP"].ToString().Trim();
                                prod.Check_TD = dataReader["Check_LP"].ToString().Trim();

                                double convertFac = Convert.ToDouble(dataReader["FACTOR"].ToString().Trim()) * Convert.ToDouble(dataReader["TOTAL_QTY"].ToString().Trim());
                                prod.Total_ConvertQTY = comm.convertShowNumber2Point(convertFac.ToString().Trim());
                                prod.Note_Unit_Convert = dataReader["Note_Unit_Convert"].ToString().Trim();

                                prod.Note_Purchase = dataReader["Note_Purchase"].ToString().Trim();
                                prod.Vendor = dataReader["Vendor"].ToString().Trim();
                                prod.Note_Vendor = dataReader["Note_Vendor"].ToString().Trim();
                                prod.Vendor_to_Purchase = dataReader["Vendor_to_Purchase"].ToString().Trim();
                                prod.P0 = dataReader["P0"].ToString().Trim();
                                prod.P1 = dataReader["P1"].ToString().Trim();
                                prod.P2 = dataReader["P2"].ToString().Trim();
                                prod.P3 = dataReader["P3"].ToString().Trim();
                                prod.P_Note = dataReader["P_Note"].ToString().Trim();
                                prod.VAT = dataReader["VAT"].ToString().Trim();
                                prod.S0 = dataReader["S0"].ToString().Trim();
                                prod.S1 = dataReader["S1"].ToString().Trim();
                                prod.S2 = dataReader["S2"].ToString().Trim();
                                prod.S3 = dataReader["S3"].ToString().Trim();
                                prod.S_Note = dataReader["S_Note"].ToString().Trim();
                                prod.QC_Form = dataReader["QC_Form"].ToString().Trim();
                                prod.Chang_Stock_TD = comm.convertShowNumber2Point(dataReader["DIFF_TD_QTY"].ToString().Trim());
                                prod.Chang_Stock_LP = comm.convertShowNumber2Point(dataReader["DIFF_LP_QTY"].ToString().Trim());

                                lsProd.Add(prod);
                            }
                        }
                    }

                }
                DataGridPrducts.ItemsSource = lsProd;
                //DataGridPrducts.ScrollIntoView(lsProd[lsProd.Count - 1]);
                log.Debug("Add List to Datagrid Success.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        private void datagrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            log.Debug("Datagrid selected.");
            try
            {
                //History Purchase
                string sqlVendorHis = "SELECT PRODUCT_CODE,PURCHASE_DATE,VENDOR_CODE,VENDOR_NAME,QTY,PRICE,DISCOUNT_STR,VAT_RATE FROM V_PURCHASE_HISTORY_ATF where 1=1 ";
                string cond = "";
                string groupby = " GROUP BY  PRODUCT_CODE,PURCHASE_DATE,VENDOR_CODE,VENDOR_NAME,QTY,PRICE,DISCOUNT_STR,VAT_RATE ";
                string orderBy = " ORDER BY PURCHASE_DATE DESC ";

                //History Order
                string sqlHisOrder = "select a.CreateDate,b.* from Product_Order_Report a"
                    + " INNER JOIN Product_Order_Report_Details b "
                    + " ON a.Order_ID = b.Order_ID"
                    + " where 1=1 AND b.Product_Code = @Product_Code "
                    + " ORDER BY CreateDate DESC,b.List_Num_Order DESC";

                if (DataGridPrducts.SelectedItem != null)
                {
                    if (DataGridPrducts.SelectedItem is ProductsModel)
                    {
                        var row = (ProductsModel)DataGridPrducts.SelectedItem;
                        if (row != null)
                        {
                            txtDatailSelect.Text = row.Product_Name;
                            txtUseDetail.Text = row.Use;
                            log.Debug("Insert data to Text box Success.");
                            cond = " AND PRODUCT_CODE = '" + (row.Product_Code.ToLower()) + "'";

                            sqlVendorHis += cond + groupby + orderBy;
                            log.Debug("Sql Vendor History : " + sqlVendorHis);
                            List<PurchaseHistoryModel> lsPurchaseHis = new List<PurchaseHistoryModel>();
                            List<OrderHistoryStock> lsOrderHisStock = new List<OrderHistoryStock>();
                            using (SqlConnection cnn = new SqlConnection(Utility.ConnectionDb.connectString))
                            {
                                cnn.Open();
                                using (SqlCommand cmd = new SqlCommand(sqlVendorHis, cnn), cmd2 = new SqlCommand(sqlHisOrder, cnn))
                                {
                                    cmd2.Parameters.AddWithValue("@Product_Code", row.Product_Code.Trim());
                                    using (SqlDataReader dataReader = cmd.ExecuteReader(), dataReader2 = cmd2.ExecuteReader())
                                    {
                                        int i = 0;
                                        while (dataReader.Read())
                                        {
                                            PurchaseHistoryModel pch = new PurchaseHistoryModel();
                                            pch.RowNum = ++i;
                                            pch.PRODUCT_CODE = dataReader["PRODUCT_CODE"].ToString().Trim();
                                            pch.PURCHASE_DATE = comm.convertIntToShortDate(dataReader["PURCHASE_DATE"].ToString().Trim());
                                            pch.VENDOR_CODE = dataReader["VENDOR_CODE"].ToString().Trim();
                                            pch.VENDOR_NAME = dataReader["VENDOR_NAME"].ToString().Trim();
                                            pch.QTY = comm.convertShowNumber2Point(dataReader["QTY"].ToString());
                                            pch.PRICE = comm.convertShowNumber2Point(dataReader["PRICE"].ToString());
                                            pch.VAT_RATE = comm.convertShowNumber2Point(dataReader["VAT_RATE"].ToString().Trim());
                                            pch.DISCOUNT_STR = dataReader["DISCOUNT_STR"].ToString().Trim();
                                            lsPurchaseHis.Add(pch);
                                        }
                                        while (dataReader2.Read())
                                        {
                                            OrderHistoryStock ohs = new OrderHistoryStock();
                                            ohs.docDate = comm.convertIntToShortDate(dataReader2["CreateDate"].ToString());
                                            ohs.orderId = dataReader2["Order_ID"].ToString();
                                            ohs.list_Num_Order = dataReader2["List_Num_Order"].ToString().PadLeft(4, '0');
                                            ohs.topic = dataReader2["Vendor"].ToString();
                                            ohs.suggestOrder = comm.convertShowNumber2Point(dataReader2["Suggest_Order"].ToString());
                                            ohs.orderStatus = (dataReader2["Order_Status"].ToString().Equals("1")) ? "ปิดงาน" : "รอปิดงาน";
                                            lsOrderHisStock.Add(ohs);
                                        }
                                    }
                                }
                            }
                            dataGridHistoryOrder.ItemsSource = lsOrderHisStock;
                            dataGridPurHis.ItemsSource = lsPurchaseHis;
                            log.Debug("Insert List Vendor History to Datagrid success.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }

        }
        private void btnSearch_Click(object sender, RoutedEventArgs e) {
            conditionSearchString();
            log.Debug("Search Data.");
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรม ใช่หรือไม่ ", "ยืนยัน", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                //SaveAllData();

                log.Debug("Exit Program.");
                this.Close();
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            HeadCheck(sender, e, true);
            log.Debug("Check All.");
        }
        private void UnheckBox_Checked(object sender, RoutedEventArgs e) {
            HeadCheck(sender, e, false);
            log.Debug("Uncheck All.");
        }
        private void HeadCheck(object sender, RoutedEventArgs e, bool IsChecked) {
            List<ProductsModel> lsProductItemS = new List<ProductsModel>();
            foreach (object item in DataGridPrducts.ItemsSource)
            {
                ProductsModel product = (ProductsModel)item;
                product.Select_Product = IsChecked;
                lsProductItemS.Add(product);
            }
            DataGridPrducts.ItemsSource = lsProductItemS;
        }
        //private void BtnSave_Click(object sender, RoutedEventArgs e) {
        //    try
        //    {
        //        if (MessageBox.Show("คุณต้องการบันทึกข้อมูล ใช่หรือไม่ ", "ยืนยันการบันทึก", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //        {
        //            SaveAllData();
        //        }
        //        MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "บันทึกสำเร็จ", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error : " + ex.Message, "พบข้อผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Error);
        //        log.Error("" + ex);
        //    }


        //}
        private void radioButton_Checked(object sender, RoutedEventArgs e) {
            conditionSearchString();
        }
        private void conditionSearchString() {
            if (radBtn2.IsChecked == true)
            {//น้อยกว่า Min
                condRadio = " AND ((a.Min_Stock*0.1)+a.Min_Stock)>=b.TOTAL_QTY ";
            }
            else if (radBtn3.IsChecked == true)
            {//เคลื่อนไหว น้อยกว่า Min ต้องสั่ง
                condRadio = " AND  b.DIFF_LP_QTY IS NOT NULL "+
                    " AND b.DIFF_TD_QTY IS NOT NULL"
                    + " AND (b.DIFF_LP_QTY <> 0 OR b.DIFF_TD_QTY<> 0) "
                    + " AND a.Suggest_Order <> 0 "
                    + " AND ((((a.Min_Stock*0.1)+a.Min_Stock)>=b.TOTAL_QTY AND a.Min_Stock <> 0) OR (a.Min_Stock=0 AND b.TOTAL_QTY=0)) "
                    + " AND b.FDDATE = '" + dateCond + "'  ";
            }
            else {//ทั้งหมด
                condRadio = " ";//AND a.Product_Code = 'PN051'
            }

            #region textBox
            cond = "";

            if (TbProduct_code.Text != null && TbProduct_code.Text.Trim() != "")
            {
                cond += " AND  (a.Product_Code LIKE '%" + TbProduct_code.Text.Trim().ToLower() + "%' OR a.Product_Code LIKE '%" + TbProduct_code.Text.Trim().ToUpper() + "%')";
            }
            if (TbProduct_Name.Text != null && TbProduct_Name.Text != "")
            {
                cond += " AND  (a.Product_Name LIKE '%" + TbProduct_Name.Text.Trim().ToLower() + "%' OR a.Product_Name LIKE '%" + TbProduct_Name.Text.Trim().ToUpper() + "%')";
            }
            if (textUse.Text != null && textUse.Text.Trim() != "")
            {
                cond += " AND  (a.Operation_Detail LIKE '%" + textUse.Text.Trim().ToLower() + "%' OR a.Operation_Detail LIKE '%" + textUse.Text.Trim().ToUpper() + "%')";
            }
            if (textOrderTO.Text != null && textOrderTO.Text.Trim() != "")
            {
                cond += " AND  (a.Order_to LIKE '%" + textOrderTO.Text.Trim().ToLower() + "%' OR a.Order_to LIKE '%" + textOrderTO.Text.Trim().ToUpper() + "%')";
            }
            if (textVendorName.Text != null && textVendorName.Text.Trim() != "")
            {
                cond += " AND  (a.Vendor LIKE '%" + textVendorName.Text.Trim().ToLower() + "%' OR a.Vendor LIKE '%" + textVendorName.Text.Trim().ToUpper() + "%')";
            }

            #endregion
            
                genData();
            
        }
        private void btnClear_Click(object sender, RoutedEventArgs e) {
            TbProduct_code.Text = "";
            TbProduct_Name.Text = "";
            textUse.Text = "";
            textOrderTO.Text = "";
            textVendorName.Text = "";

            radBtn3.IsChecked = true;

            conditionSearchString();
            log.Debug("Clear Search.");
        }
        private void btnPrint_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("คุณต้องการบันทึกข้อมูลและออกใบงานย่อย ใช่หรือไม่ ", "ยืนยันการบันทึก", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {

                    SaveSelectData();
                    log.Info("Save Data success.");
                    //MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "บันทึกสำเร็จ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "พบข้อผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Error);
                    log.Error("" + ex);
                }
            }
        }
        private void SaveAllData(List<ProductsModel> lsSaveAll) {

            try
            {
                ProductListToDB pro = new ProductListToDB();
                pro.UpdateP_Product_Monitor_Properties(lsSaveAll);

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        private void SaveSelectData() {
            log.Debug("Save Data.");
            try
            {
                List<ProductsModel> lsProductReport = new List<ProductsModel>();
                foreach (ProductsModel p in DataGridPrducts.ItemsSource)
                {
                    if (p.Select_Product == true)
                    {
                        lsProductReport.Add(p);
                    }

                }

                if (lsProductReport.Count > 0)
                {



                    OrderListFormPDF reportOrder = new OrderListFormPDF();
                    int Order_ID = reportOrder.InsertToTable_Report(lsProductReport, dateCond);
                    reportOrder.CreatePrintPreView(Order_ID);
                }
                else {
                    MessageBox.Show("กรุณาเลือกข้อมูลอย่างน้อย 1 รายการ ", "โปรดทราบ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CreateReport() {

        }

        //private void DataGridPrducts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {
        //    List<ProductsModel> lsSaveRow = new List<ProductsModel>();
        //    ProductsModel pro = e.Row.Item as ProductsModel;
        //    lsSaveRow.Add(pro);

        //}


        private void DataGridPrducts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e) {
            try
            {
                if (e.EditAction == DataGridEditAction.Commit)
                {
                    var obj = e.Row.Item as ProductsModel;
                    if (obj != null)
                    {
                        List<ProductsModel> lsProductAll = new List<ProductsModel>();
                        lsProductAll.Add(obj);
                        SaveAllData(lsProductAll);
                    }
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error : " + ex.Message, "พบข้อผิดพลาด", MessageBoxButton.OK, MessageBoxImage.Error);
                log.Error("" + ex);
            }
        }

    
    }
}
