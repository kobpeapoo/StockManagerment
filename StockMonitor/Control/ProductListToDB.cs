using InventoryManagerment.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerment.Control {
    
    public class ProductListToDB {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ProductListToDB() { }
        public void UpdateP_Product_Monitor_Properties(List<ProductsModel> lsSaveAll) {
            try
            {
                using (SqlConnection cnn = new SqlConnection(Utility.ConnectionDb.connectString))
                {
                    cnn.Open();
                    foreach (ProductsModel p in lsSaveAll)
                    {
                   
                        string sqlUpdate = "UPDATE Product_Monitor_Properties SET " +
                            " Check_LP=@Check_LP,Check_TD=@Check_TD," +
                            "Note_Unit_Convert=@Note_Unit_Convert,Note_Purchase=@Note_Purchase," +
                            "Vendor=@Vendor,Note_Vendor=@Note_Vendor,Vendor_to_Purchase=@Vendor_to_Purchase," +
                            "P0=@P0,P1=@P1,P2=@P2,P3=@P3,P_Note=@P_Note," +
                            "VAT=@VAT,S0=@S0,S1=@S1,S2=@S2,S3=@S3,S_Note=@S_Note,QC_Form=@QC_Form"+
                            "  Where LOWER(Product_Code) = @Product_Code ";
                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cnn))
                        {
                            cmdUpdate.Parameters.AddWithValue("Check_LP",p.Check_LP);
                            cmdUpdate.Parameters.AddWithValue("Check_TD",p.Check_TD);
                            cmdUpdate.Parameters.AddWithValue("Note_Unit_Convert",p.Note_Unit_Convert);
                            cmdUpdate.Parameters.AddWithValue("Note_Purchase", p.Note_Purchase);
                            cmdUpdate.Parameters.AddWithValue("Vendor",p.Vendor);
                            cmdUpdate.Parameters.AddWithValue("Note_Vendor", p.Note_Vendor);
                            cmdUpdate.Parameters.AddWithValue("Vendor_to_Purchase", p.Vendor_to_Purchase);
                            cmdUpdate.Parameters.AddWithValue("P0", p.P0);
                            cmdUpdate.Parameters.AddWithValue("P1", p.P1);
                            cmdUpdate.Parameters.AddWithValue("P2", p.P2);
                            cmdUpdate.Parameters.AddWithValue("P3", p.P3);
                            cmdUpdate.Parameters.AddWithValue("P_Note", p.P_Note);
                            cmdUpdate.Parameters.AddWithValue("VAT", p.VAT);
                            cmdUpdate.Parameters.AddWithValue("S0", p.S0);
                            cmdUpdate.Parameters.AddWithValue("S1", p.S1);
                            cmdUpdate.Parameters.AddWithValue("S2", p.S2);
                            cmdUpdate.Parameters.AddWithValue("S3", p.S3);
                            cmdUpdate.Parameters.AddWithValue("S_Note", p.S_Note);
                            cmdUpdate.Parameters.AddWithValue("QC_Form", p.QC_Form);
                            //Where
                            cmdUpdate.Parameters.AddWithValue("Product_Code",p.Product_Code.ToLower());

                            

                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                }
                log.Info("Update data to Product_Monitor_Properties Success.");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }

        }
    }
}
