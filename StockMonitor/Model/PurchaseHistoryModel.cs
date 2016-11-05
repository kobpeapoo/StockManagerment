using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.Model {
    class PurchaseHistoryModel {
        public int RowNum { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PURCHASE_DATE { get; set; }
        public string VENDOR_CODE { get; set; }
        public string VENDOR_NAME { get; set; }
        public string QTY { get; set; }
        public string PRICE { get; set; }
        public string DISCOUNT_STR { get; set; }
        public string VAT_RATE { get; set; }
    }
}
