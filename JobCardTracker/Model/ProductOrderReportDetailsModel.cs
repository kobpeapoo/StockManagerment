using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.JobCardTracker.Model
{
    class ProductOrderReportDetailsModel
    {
        public int Order_Detail_ID { get; set; }
        public int RowNo { get; set; }
        public string CreateDate { get; set; }
        public string Order_ID { get; set; }
        public string OrderDayCount { get; set; }
        public string Order_to { get; set; }
        public string Product_Code { get; set; }
        public string Operation_Detail { get; set; }
        public string Vendor { get; set; }
        public string Suggest_Order { get; set; }
        public string Min_Stock { get; set; }
        public string TD_QTY { get; set; }
        public string LP_QTY { get; set; }
        public string TOTAL_QTY { get; set; }
        public bool Order_Status { get; set; }
        public string Note_Close { get; set; }
        public string closeDate { get; set; }
    }
}
