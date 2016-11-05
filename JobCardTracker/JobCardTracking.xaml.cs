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
using System.Data.SqlClient;
using InventoryManagerment.JobCardTracker.SqlQuery;
using InventoryManagerment.JobCardTracker.Model;
using InventoryManagerment.JobCardTracker.Controller;
using System.Globalization;

namespace InventoryManagerment.JobCardTracker
{
    /// <summary>
    /// Interaction logic for JobCardTracking.xaml
    /// </summary>
    public partial class JobCardTracking : Window
    {
        // define controller
        private JobCardTrackingController jctc = new JobCardTrackingController();

        public JobCardTracking()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var warningList = jctc.GetProductOrderReportWaring();
            if(warningList.Count > 0)
            {
                JobCardWarning jcw = new JobCardWarning();
                jcw.ShowDialog();
            }

            ProductOrderReportDetailsSearchModel search = new ProductOrderReportDetailsSearchModel();
            search.OrderStatus = "0";
            dgMainContent.ItemsSource = jctc.GetProductOrderReportDetails(search);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtOwner.Text = "";
            txtVender.Text = "";
            txtOrderNumber.Text = "";
            rdoStatusWait.IsChecked = true;
            dpOrderFrom.Text = "";
            dpOrderCloseFrom.Text = "";
            dpOrderTo.Text = "";
            dpOrderCloseTo.Text = "";

            dgFollowCard.ItemsSource = null;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            GetMainDataGridContent();
        }

        private String ChangeToThaiCulture(DateTime? datetime)
        {
            return datetime != null ? datetime.Value.ToString("dd/MM/yyyy", new CultureInfo("th-TH")) : "";
        }

        private void dgMainContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMainContent.SelectedItem != null)
            {
                if (dgMainContent.SelectedItem is ProductOrderReportDetailsModel)
                {
                    var row = (ProductOrderReportDetailsModel)dgMainContent.SelectedItem;
                    if (row != null)
                    {
                        dgFollowCard.ItemsSource = jctc.GetProductOrderReportWaring(row.Order_Detail_ID.ToString().Trim());
                    }
                }
            }
        }

        //private void DGMain_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    DataGridRow dataGridRow = sender as DataGridRow;

        //    if(dataGridRow.Background == Brushes.Red)
        //    {
        //        if (dataGridRow.Item is ProductOrderReportDetailsModel)
        //        {
        //            var row = dataGridRow.Item as ProductOrderReportDetailsModel;

        //            string responseText = PromptDialog.Prompt("บันทึกการเตือน", "โปรดกรอกข้อความ", inputType: PromptDialog.InputType.Text);

        //            if(responseText != null)
        //            {
        //                bool response = jctc.UpdateWarningNoted(row.Order_Detail_ID, responseText);

        //                if(response)
        //                {
        //                    MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว");
        //                }
        //                else
        //                {
        //                    MessageBox.Show("บันทึกข้อมูล ไม่สำเร็จ");
        //                }

        //                dgFollowCard.ItemsSource = jctc.GetProductOrderReportWaring(row.Order_Detail_ID.ToString().Trim());
        //            }
        //        }
        //    }
        //}

        private void dgMainContent_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var obj = e.Row.Item as ProductOrderReportDetailsModel;

                if(obj != null)
                {
                    bool updateResult = jctc.UpdateOrderStatus(obj.Order_Status ? 1 : 0, obj.Note_Close, obj.Order_Detail_ID);

                    if (updateResult)
                    {
                        MessageBox.Show("บันทึกข้อมูล เรียบร้อยแล้ว");
                    }
                    else
                    {
                        MessageBox.Show("บันทึกข้อมูล ไม่สำเร็จ");
                    }

                    GetMainDataGridContent();
                }
            }
        }

        private void GetMainDataGridContent()
        {
            ProductOrderReportDetailsSearchModel search = new ProductOrderReportDetailsSearchModel();
            search.Product_Code = txtProductId.Text;
            search.Operation_Detail = txtProductName.Text;
            search.Order_ID = txtOrderNumber.Text;
            search.Order_to = txtOwner.Text;
            search.Vendor = txtVender.Text;
            search.OrderDateFrom = ChangeToThaiCulture(dpOrderFrom.SelectedDate);
            search.OrderDateTo = ChangeToThaiCulture(dpOrderTo.SelectedDate);
            search.OrderCloseDateFrom = ChangeToThaiCulture(dpOrderCloseFrom.SelectedDate);
            search.OrderCloseDateTo = ChangeToThaiCulture(dpOrderCloseTo.SelectedDate);

            if (rdoStatusAll.IsChecked == true)
            {
                search.OrderStatus = "";
            }
            if (rdoStatusWait.IsChecked == true)
            {
                search.OrderStatus = "0";
            }
            if (rdoStatusClose.IsChecked == true)
            {
                search.OrderStatus = "1";
            }

            dgFollowCard.ItemsSource = null;
            dgMainContent.ItemsSource = jctc.GetProductOrderReportDetails(search);
        }
    }
}
