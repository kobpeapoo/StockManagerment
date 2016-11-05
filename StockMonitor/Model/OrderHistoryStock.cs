using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.Model {
   public class OrderHistoryStock {
        public OrderHistoryStock() { }
        public string docDate { get; set; }
        public string orderId { get; set; }
        public string topic { get; set; }
        public string suggestOrder { get; set; }
        public string purchaseAmount { get; set; }
        public string orderStatus { get; set; }
        public string list_Num_Order { get; set; }
    }
}
