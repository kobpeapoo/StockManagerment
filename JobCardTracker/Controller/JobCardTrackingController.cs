using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InventoryManagerment.JobCardTracker.Model;
using InventoryManagerment.JobCardTracker.SqlQuery;

namespace InventoryManagerment.JobCardTracker.Controller
{
    class JobCardTrackingController
    {
        // define log4net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // define connection string to connect databse
        private string connectionString = Utility.ConnectionDb.connectString;

        // define sql query class
        private ProductOrderReportDetailsQuery query = new ProductOrderReportDetailsQuery();

        public List<ProductOrderReportDetailsModel> GetProductOrderReportDetails(ProductOrderReportDetailsSearchModel search)
        {
            string sql = query.PRODUCT_ORDER_REPORT_DETAILS_LIST;
            if (search != null)
            {
                sql += !search.Product_Code.Equals("") ? 
                    string.Format(" AND PORD.Product_Code LIKE '%{0}%' ", search.Product_Code) : "";

                sql += !search.Operation_Detail.Equals("") ? 
                    string.Format(" AND PORD.Operation_Detail LIKE '%{0}%' ", search.Operation_Detail) : "";

                sql += !search.Order_ID.Equals("") ? 
                    string.Format(" AND FORMAT(PORD.Order_ID, '0000') LIKE '%{0}%' ", search.Order_ID) : "";

                sql += !search.Order_to.Equals("") ? 
                    string.Format(" AND PORD.Order_to LIKE '%{0}%' ", search.Order_to) : "";

                sql += !search.Vendor.Equals("") ? 
                    string.Format(" AND PORD.Vendor LIKE '%{0}%' ", search.Vendor) : "";

                sql += !search.OrderDateFrom.Equals("") ? 
                    string.Format(" AND CAST(POR.CreateDate AS DATE) >= FORMAT(CONVERT(DATE,'{0}',103), 'yyyyMMdd') ", search.OrderDateFrom) : "";

                sql += !search.OrderDateTo.Equals("") ? 
                    string.Format(" AND CAST(POR.CreateDate AS DATE) <= FORMAT(CONVERT(DATE,'{0}',103), 'yyyyMMdd') ", search.OrderDateTo) : "";

                sql += !search.OrderCloseDateFrom.Equals("") ? 
                    string.Format(" AND CAST(PORD.closeDate AS DATE) >= FORMAT(CONVERT(DATE,'{0}',103), 'yyyyMMdd') ", search.OrderCloseDateFrom) : "";

                sql += !search.OrderCloseDateTo.Equals("") ? 
                    string.Format(" AND CAST(PORD.closeDate AS DATE) <= FORMAT(CONVERT(DATE,'{0}',103), 'yyyyMMdd') ", search.OrderCloseDateTo) : "";

                sql += !search.OrderStatus.Equals("") ? 
                    string.Format(" AND PORD.Order_Status = {0} ", search.OrderStatus) : "";
            }

            log.Debug("SQL[PRODUCT ORDERREPORT DETAILS LIST] : " + sql);

            List<ProductOrderReportDetailsModel> orderReportList = new List<ProductOrderReportDetailsModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    log.Debug("Connect to Sqlserver success.");

                    using (SqlCommand sqlcmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader dataReader = sqlcmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                ProductOrderReportDetailsModel model = new ProductOrderReportDetailsModel();
                                model.Order_Detail_ID = Convert.ToInt32(dataReader["Datail_ID"]);
                                model.RowNo = Convert.ToInt32(dataReader["RowNo"]);
                                model.CreateDate = dataReader["CreateDate"].ToString().Trim();
                                model.Order_ID = dataReader["Order_ID"].ToString().Trim();
                                model.OrderDayCount = dataReader["OrderDayCount"].ToString().Trim();
                                model.Order_to = dataReader["Order_to"].ToString().Trim();
                                model.Product_Code = dataReader["Product_Code"].ToString().Trim();
                                model.Operation_Detail = dataReader["Operation_Detail"].ToString().Trim();
                                model.Vendor = dataReader["Vendor"].ToString().Trim();
                                model.Suggest_Order = dataReader["Suggest_Order"].ToString().Trim();
                                model.Min_Stock = dataReader["Min_Stock"].ToString().Trim();
                                model.TD_QTY = dataReader["TD_QTY"].ToString().Trim();
                                model.LP_QTY = dataReader["LP_QTY"].ToString().Trim();
                                model.TOTAL_QTY = dataReader["TOTAL_QTY"].ToString().Trim();
                                model.Order_Status = Convert.ToInt32(dataReader["Order_Status"]) == 0 ? false : true;
                                model.Note_Close = dataReader["Note_Close"].ToString().Trim();
                                model.closeDate = dataReader["closeDate"].ToString().Trim();

                                orderReportList.Add(model);
                            }
                        }
                    }
                }

                log.Debug("Disconnect to Sqlserver.");
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                throw ex;
            }

            return orderReportList;
        }

        public List<ProductOrderReportWarningModel> GetProductOrderReportWaring(string orderDetailId)
        {
            string sql = query.PRODUCT_ORDER_REPORT_WARNING_LIST_BY_DETAIL_ID;
            if (orderDetailId != null)
            {
                sql += !orderDetailId.Equals("") ?
                    string.Format(" AND PORW.Order_Detail_ID = {0} ", orderDetailId) : "";
            }

            log.Debug("SQL[PRODUCT ORDERREPORT WARNING LIST] : " + sql);

            List<ProductOrderReportWarningModel> orderReportWarningList = new List<ProductOrderReportWarningModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    log.Debug("Connect to Sqlserver success.");

                    using (SqlCommand sqlcmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader dataReader = sqlcmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                ProductOrderReportWarningModel model = new ProductOrderReportWarningModel();
                                model.Warning_No = Convert.ToInt32(dataReader["Warning_No"]);
                                model.Warning_Date = dataReader["Warning_Date"].ToString().Trim();
                                model.Warning_Noted_Date = dataReader["Warning_Noted_Date"].ToString().Trim();
                                model.Reason = dataReader["Reason"].ToString().Trim();

                                orderReportWarningList.Add(model);
                            }
                        }
                    }
                }

                log.Debug("Disconnect to Sqlserver.");
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                throw ex;
            }

            return orderReportWarningList;
        }

        public bool UpdateOrderStatus(int orderStatus, string noteClose, int detailId)
        {
            bool updateResult = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    log.Debug("Connect to Sqlserver success.");

                    string sql = query.UPDATE_ORDER_STATUS_IN_PRODUCT_ORDER_REPORT_DETAILS;

                    using (SqlCommand sqlcmd = new SqlCommand(sql, conn))
                    {
                        sqlcmd.Parameters.AddWithValue("@OrderStatus", orderStatus);
                        sqlcmd.Parameters.AddWithValue("@NoteClose", noteClose.Equals("") ? (object)DBNull.Value : noteClose);
                        sqlcmd.Parameters.AddWithValue("@DetailID", detailId);

                        sqlcmd.ExecuteNonQuery();

                        log.Debug("Update Order status success.");
                    }
                }

                log.Debug("Disconnect to Sqlserver.");
            }
            catch (Exception ex)
            {
                updateResult = false;

                log.Error("Error", ex);
            }

            return updateResult;
        }

        public bool UpdateWarningNoted(int orderDetailId, string reason, int WarningNo)
        {
            bool updateResult = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    log.Debug("Connect to Sqlserver success.");

                    string sql = query.UPDATE_ORDER_WARNING_IN_PRODUCT_ORDER_REPORT_WARING;

                    using (SqlCommand sqlcmd = new SqlCommand(sql, conn))
                    {
                        sqlcmd.Parameters.AddWithValue("@OrderDetailID", orderDetailId);
                        sqlcmd.Parameters.AddWithValue("@Reason", reason.Equals("") ? (object)DBNull.Value : reason);
                        sqlcmd.Parameters.AddWithValue("@WarningNo", WarningNo);

                        sqlcmd.ExecuteNonQuery();

                        log.Debug("Update Warning Noted success.");
                    }
                }

                log.Debug("Disconnect to Sqlserver.");
            }
            catch (Exception ex)
            {
                updateResult = false;

                log.Error("Error", ex);
            }

            return updateResult;
        }

        public List<ProductOrderReportWarningModel> GetProductOrderReportWaring()
        {
            string sql = query.PRODUCT_ORDER_REPORT_WARNING_ALERT;

            log.Debug("SQL[PRODUCT ORDERREPORT WARNING LIST] : " + sql);

            List<ProductOrderReportWarningModel> orderReportWarningList = new List<ProductOrderReportWarningModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    log.Debug("Connect to Sqlserver success.");

                    using (SqlCommand sqlcmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader dataReader = sqlcmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                ProductOrderReportWarningModel model = new ProductOrderReportWarningModel();
                                model.RowNo = Convert.ToInt32(dataReader["RowNo"]);
                                model.Order_Detail_ID = Convert.ToInt32(dataReader["Order_Detail_ID"]);
                                model.Warning_No = Convert.ToInt32(dataReader["Warning_No"]);
                                model.Warning_Date = dataReader["Warning_Date"].ToString().Trim();
                                model.Order_ID = dataReader["Order_ID"].ToString().Trim();
                                model.Order_Day_Count = Convert.ToInt32(dataReader["Order_Day_Count"]);
                                model.Order_to = dataReader["Order_to"].ToString().Trim();
                                model.Product_Code = dataReader["Product_Code"].ToString().Trim();
                                model.Operation_Detail = dataReader["Operation_Detail"].ToString().Trim();

                                orderReportWarningList.Add(model);
                            }
                        }
                    }
                }

                log.Debug("Disconnect to Sqlserver.");
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                throw ex;
            }

            return orderReportWarningList;
        }
    }
}
