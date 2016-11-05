using InventoryManagerment.Model;
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

namespace InventoryManagerment.Views {
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListView : Window {
        public OrderListView() {
            InitializeComponent();
        }

        private List<OrderListModel> lsOrder = new List<OrderListModel>(); 
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (lsOrder!=null) {
                datagridOrder.ItemsSource = lsOrder;
            }

            DateTime now = DateTime.Now;
            txtDate.Text = now.ToString("dd/MM/yyyy HH:mm:ss");
            

        }
        public void addOrderList(List<OrderListModel> parmLsOrder) {
            lsOrder = parmLsOrder;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        

        private void datagridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (datagridOrder.SelectedItem != null)
            {
                if (datagridOrder.SelectedItem is OrderListModel)
                {
                    var row = (OrderListModel)datagridOrder.SelectedItem;
                    if (row != null)
                    {
                        txtDetailSelect.Text = row.Product_Name;
                    }
                }
            }
        }
    }
}
