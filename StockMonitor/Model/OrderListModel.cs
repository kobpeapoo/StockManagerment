using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.Model {
   public class OrderListModel {
        public string OrderNumber { get; set; }
        public int RowNum { get; set; }
        public string List_Num_Order { get; set; }
        public string CreateDate { get; set; }
        public string CreateTimestamp { get; set; }
        public string Product_code { get; set; }
        public string Product_Name { get; set; }
        public string Use { get; set; }
        public string Topic { get; set; }
        public double ReaminTD { get; set; }
        public double RemainLP { get; set; }
        public double RemainAll { get; set; }
        public double Suggest_Order { get; set; }
        public string PUnit_Name { get; set; }

        public double MinumunStock { get; set; }
        public string SUnit_Name { get; set; }
        public string ToOwner { get; set; }
        public string Note_Vendor { get; set; }
        public string Purchase_Name { get; set; }
        public string AccountCode { get; set; }
    }
}
