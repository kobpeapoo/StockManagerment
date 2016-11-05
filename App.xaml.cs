using InventoryManagerment.Views;
using System.Configuration;
using System.Windows;

namespace InventoryManagerment {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void Application_Startup(object sender, StartupEventArgs e) {


            Utility.ConnectionDb.serverName = "SRMK1";
            Utility.ConnectionDb.userName = "sa";
            Utility.ConnectionDb.password = "@passw0rd";

            //Utility.ConnectionDb.serverName = "KOBPEAPOO";
            //Utility.ConnectionDb.userName = "sa";
            //Utility.ConnectionDb.password = "Admin2000";

            ////var MyReader = new AppSettingsReader();

            //Utility.ConnectionDb.serverName = MyReader.GetValue("serverName", typeof(string)).ToString();//ConfigurationManager.AppSettings.Get("serverName");
            //Utility.ConnectionDb.userName = ConfigurationManager.AppSettings.Get("userName");
            //Utility.ConnectionDb.password = ConfigurationManager.AppSettings.Get("password");
            Utility.ConnectionDb.connectString = "Data Source = " + Utility.ConnectionDb.serverName + "; Initial Catalog = PM; User Id = " + Utility.ConnectionDb.userName + "; Password = " + Utility.ConnectionDb.password + "; MultipleActiveResultSets = true; ";

            log.Info("Program Start.");
            //ProductsView ui = new ProductsView();

            //DateTime value = new DateTime(2016, 10, 29);
            //int day = (int)value.DayOfWeek;

            //PrintDocOrderReportForm ui = new PrintDocOrderReportForm();
            //MainWindow ui = new MainWindow();
            //FormPrint ui = new FormPrint();
            PortalWindow ui = new PortalWindow();
            ui.Show();
        }
    }
}
