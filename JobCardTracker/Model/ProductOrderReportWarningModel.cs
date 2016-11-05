using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.JobCardTracker.Model
{
    class ProductOrderReportWarningModel
    {
        public int Warning_No { get; set; }
        public string Warning_Date { get; set; }
        public string Warning_Noted_Date { get; set; }
        public string Reason { get; set; }

        #region popup warning details

        public int Order_Detail_ID { get; set; }
        public int RowNo { get; set; }
        public string Order_ID { get; set; }
        public int Order_Day_Count { get; set; }
        public string Order_to { get; set; }
        public string Product_Code { get; set; }
        public string Operation_Detail { get; set; }

        #endregion
    }
}
