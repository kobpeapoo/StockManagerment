using InventoryManagerment.JobCardTracker;
using InventoryManagerment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryManagerment {
    /// <summary>
    /// Interaction logic for PortalWindow.xaml
    /// </summary>
    public partial class PortalWindow : Window {
        public PortalWindow() {
            InitializeComponent();
        }

        private void btnCheckHistoryOrder_Click(object sender, RoutedEventArgs e) {
            JobCardTracking ui = new JobCardTracking();
            ui.Show();
        }

        private void StockMonitor_Click(object sender, RoutedEventArgs e) {
            ProductsView ui = new ProductsView();
            ui.Show();
        }
    }
}
