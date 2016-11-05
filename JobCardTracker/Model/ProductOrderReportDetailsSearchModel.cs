using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.JobCardTracker.Model
{
    class ProductOrderReportDetailsSearchModel
    {
        public string Product_Code { get; set; } = "";
        public string Operation_Detail { get; set; } = "";
        public string Order_ID { get; set; } = "";
        public string Order_to { get; set; } = "";
        public string Vendor { get; set; } = "";
        public string OrderStatus { get; set; } = "";
        public string OrderDateFrom { get; set; } = "";
        public string OrderDateTo { get; set; } = "";
        public string OrderCloseDateFrom { get; set; } = "";
        public string OrderCloseDateTo { get; set; } = "";
    }
}
