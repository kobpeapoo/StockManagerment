   M S B A M L   `   `   `  ���� O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:InventoryManagerment.JobCardTracker#InventoryManagerment.JobCardTracker  8    2InventoryManagerment.JobCardTracker.JobCardWarning   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Clocal1clr-namespace:InventoryManagerment.JobCardTracker     -     � Title$0  *แจ้งเตือนใบงาน��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell   DataGridCellCenter��%p   '        &	  '     �� "  .���  � ��$ Center=��� "  .���  �@��TextAlignment$ Center=�.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgWarningList��   AutoGenerateColumns .  	   CanUserAddRows	 .  $��10q�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  -   Order_Detail_ID��,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Order_Detail_ID+  -   	RowNo��   Header$ ลำดับที่��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    	CellStyle# [   �� *RowNo+  -   
Warning_No��$- 'ครั้งที่เตือน�� . $
 Auto # [   �� *
Warning_No+  -   Warning_Date��$' !วันที่เตือน�� . $
 Auto # [   �� *Warning_Date+  -   Order_ID��$* $เลขที่ใบสั่ง�� . $
 Auto # [   �� *
Order_ID+  -   Order_Day_Count��$/ )อายุใบสั่ง(วัน)�� . $
 Auto # [   �� *Order_Day_Count+  -	   Order_to��$* $ผู้รับผิดชอบ�� . $
 Auto  �� *
Order_to+  -
   Product_Code��$= 7รหัสวัตถุดิบ/สินค้า�� . $
 Auto # [   �� *Product_Code+  -   Operation_Detail��$= 7ชื่อวัตถุดิบ/สินค้า�� . $
 Auto  �� *Operation_Detail+   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .�-   