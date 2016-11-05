using InventoryManagerment.JobCardTracker.Controller;
using InventoryManagerment.JobCardTracker.Model;
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

namespace InventoryManagerment.JobCardTracker
{
    /// <summary>
    /// Interaction logic for JobCardWarning.xaml
    /// </summary>
    public partial class JobCardWarning : Window
    {
        // define Controller
        private JobCardTrackingController jctc = new JobCardTrackingController();

        public JobCardWarning()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgWarningList.ItemsSource = jctc.GetProductOrderReportWaring();
        }

        private void dgWarningList_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow dataGridRow = sender as DataGridRow;

            if (dataGridRow.Item is ProductOrderReportWarningModel)
            {
                var row = dataGridRow.Item as ProductOrderReportWarningModel;

                string responseText = PromptDialog.Prompt("กรุณากรอกข้อความ", "บันทึกการเตือน", inputType: PromptDialog.InputType.Text);

                if (responseText != null)
                {
                    bool response = jctc.UpdateWarningNoted(row.Order_Detail_ID, responseText, row.Warning_No);

                    if (response)
                    {
                        MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว");
                    }
                    else
                    {
                        MessageBox.Show("บันทึกข้อมูล ไม่สำเร็จ");
                    }

                    dgWarningList.ItemsSource = jctc.GetProductOrderReportWaring();
                }
            }
        }
    }
}
