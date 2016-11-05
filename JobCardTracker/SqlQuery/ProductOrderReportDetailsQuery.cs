using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.JobCardTracker.SqlQuery
{
    class ProductOrderReportDetailsQuery
    {
        public string PRODUCT_ORDER_REPORT_DETAILS_LIST =
            " SELECT " +
            " PORD.Datail_ID, " +
            " ROW_NUMBER() OVER(ORDER BY PORD.Datail_ID ASC) AS RowNo, " +
            " CONVERT(VARCHAR(10), CAST(POR.CreateDate AS DATE), 103) AS CreateDate, " +
            " FORMAT(PORD.Order_ID, '0000') AS Order_ID, " +
            " DATEDIFF(DAY, CAST(POR.CreateDate AS DATE), DATEADD(YEAR, 543, GETDATE())) AS OrderDayCount, " +
            " PORD.Order_to, " +
            " PORD.Product_Code, " +
            " PORD.Operation_Detail, " +
            " PORD.Vendor, " +
            " CAST(PORD.Suggest_Order AS DECIMAL(10,2)) AS Suggest_Order, " +
            " CAST(PORD.Min_Stock AS DECIMAL(10,2)) AS Min_Stock, " +
            " CAST(PORD.TD_QTY AS DECIMAL(10,2)) AS TD_QTY, " +
            " CAST(PORD.LP_QTY AS DECIMAL(10,2)) AS LP_QTY, " +
            " CAST(PORD.TOTAL_QTY AS DECIMAL(10,2)) AS TOTAL_QTY, " +
            " PORD.Order_Status, " +
            " PORD.Note_Close, " +
            " CONVERT(VARCHAR(10), CAST(PORD.closeDate AS DATE), 103) AS closeDate " +
            " FROM Product_Order_Report_Details PORD " +
            " LEFT JOIN Product_Order_Report POR ON POR.Order_ID = PORD.Order_ID " +
            " WHERE 1=1 ";

        public string PRODUCT_ORDER_REPORT_WARNING_LIST_BY_DETAIL_ID =
            " SELECT " +
            " PORW.Order_Detail_ID, " +
            " PORW.Warning_No, " +
            " FORMAT(CAST(PORW.Warning_Date AS DATE), 'dd/MM/yyyy') AS Warning_Date, " +
            " FORMAT(CAST(PORW.Warning_Noted_Date AS DATE), 'dd/MM/yyyy') AS Warning_Noted_Date, " +
            " PORW.Reason " +
            " FROM Product_Order_Report_Warning PORW " +
            " WHERE 1=1 ";

        public string UPDATE_ORDER_STATUS_IN_PRODUCT_ORDER_REPORT_DETAILS =
            " UPDATE Product_Order_Report_Details " +
            " SET Order_Status = @OrderStatus, " +
            " 	  Note_Close = CASE WHEN @NoteClose IS NULL OR @OrderStatus = 0 THEN NULL ELSE @NoteClose END, " +
            " 	  closeDate = CASE WHEN @OrderStatus = 0 THEN NULL ELSE FORMAT(DATEADD(YEAR, 543, GETDATE()), 'yyyyMMdd') END " +
            "  WHERE Datail_ID = @DetailID ";

        public string UPDATE_ORDER_WARNING_IN_PRODUCT_ORDER_REPORT_WARING =
            " UPDATE Product_Order_Report_Warning " +
            " SET Warning_Noted_Date = FORMAT(DATEADD(YEAR, 543, GETDATE()), 'yyyyMMdd'), " +
            " 	  Reason = @Reason " +
            " WHERE Order_Detail_ID = @OrderDetailID AND Warning_No = @WarningNo ";

        public string PRODUCT_ORDER_REPORT_WARNING_ALERT =
            " WITH CTE AS " +
            " ( " +
            " 	SELECT " +
            " 		Order_Detail_ID, " +
            " 		MAX(Warning_No) AS Warning_No, " +
            " 		MAX(Warning_Date) AS Warning_Date, " +
            " 		MAX(Warning_Noted_Date) AS Warning_Noted_Date " +
            " 	FROM Product_Order_Report_Warning " +
            " 	GROUP BY Order_Detail_ID " +
            " ) " +
            " SELECT   " +
            " 	ROW_NUMBER() OVER(ORDER BY PORW.Order_Detail_ID ASC) AS RowNo,   " +
            " 	PORW.Order_Detail_ID,   " +
            " 	PORW.Warning_No,   " +
            " 	CONVERT(VARCHAR(10), CAST(PORW.Warning_Date AS DATE), 103) AS Warning_Date,   " +
            " 	FORMAT(PORD.Order_ID, '0000') AS Order_ID,   " +
            " 	DATEDIFF(DAY, CAST(POR.CreateDate AS DATE), DATEADD(YEAR, 543, GETDATE())) AS Order_Day_Count,   " +
            " 	PORD.Order_to,   " +
            " 	PORD.Product_Code,   " +
            " 	PORD.Operation_Detail   " +
            " FROM CTE PORW  " +
            " LEFT JOIN Product_Order_Report_Details PORD ON PORD.Datail_ID = PORW.Order_Detail_ID   " +
            " LEFT JOIN Product_Order_Report POR ON POR.Order_ID = PORD.Order_ID   " +
            " WHERE PORD.Order_Status = 0 AND PORW.Warning_Noted_Date IS NULL ";
    }
}
