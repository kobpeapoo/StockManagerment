using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.Model {
    public class ProductsModel{
        private bool _select_Product = false;
        
        public ProductsModel() { }
        public int HaveToOder { get; set; }
        public int RowNum { get; set; }
        public bool Select_Product { get { return _select_Product; } set { _select_Product = value; } }       
        public string Product_Type { get; set; }          
        public string Max_Stock { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public string Use { get; set; }
        public string Min_Stock { get; set; }
        public string Order_to { get; set; }
        public string Check_LP { get; set; }
        public string Check_TD { get; set; }
        public string TD_QTY { get; set; }
        public string LP_QTY { get; set; }
        public string TOTAL_QTY { get; set; }
        public string SUnit_Name { get; set; }
        public string Note_QTY { get; set; }
        public string Total_ConvertQTY { get; set; }
        public string Factor { get; set; }
        public string Note_Unit_Convert { get; set; }
        public string Suggest_Order { get; set; }
        public string Note_Purchase { get; set; }
        public string Stock_Unit_Code { get; set; }
        public string PUnit_Code { get; set; }
        public string PUnit_Name { get; set; }
        public string Note_Suggest_Order { get; set; }
        public string Chang_Stock_TD { get; set; }
        public string Chang_Stock_LP { get; set; }
        public string Vendor { get; set; }
        public string Note_Vendor { get; set; }
        public string Vendor_to_Purchase { get; set; }
        public string P0 { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P_Note { get; set; }
        public string VAT { get; set; }
        public string S0 { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S_Note { get; set; }
        public string QC_Form { get; set; }
        public string FDDATE { get; set; }
        public string CostAvg { get; set; }
        public string CostNote { get; set; }
        public string Empty { get; set; }
    }
}
