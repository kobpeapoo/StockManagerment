   M S B A M L   `   `   `  ����O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:InventoryManagerment.JobCardTracker#InventoryManagerment.JobCardTracker  5   	   8    2InventoryManagerment.JobCardTracker.JobCardWarning   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:InventoryManagerment.JobCardTracker     5   	   -   5          � Title$0  *แจ้งเตือนใบงาน��5   	   $	��600��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$ 
ToolWindow=�6.    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell   DataGridCellCenter��%�   '        &	  L     �� 5   
   "  6   .�5      ��  � ��$ Center=�6;   5      �� 5   
   "  6   .�5      ��  �@��TextAlignment$ Center=�68   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgWarningList��5         AutoGenerateColumns .  	   CanUserAddRows	 .  $��10q�6]   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Order_Detail_ID��,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�5   b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Order_Detail_ID+6b     5      -   5        	RowNo��   Header$ ลำดับที่��5   4      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6r      	CellStyle# [  6    6F   �� *RowNo+6     5      -   5        
Warning_No��$- 'ครั้งที่เตือน��5   9    . $
 Auto 6�   # [  6�    6P   �� *
Warning_No+6�     5      -   5        Warning_Date��$' !วันที่เตือน��5   ;    . $
 Auto 6�   # [  6�    6P   �� *Warning_Date+6�     5      -   5        Order_ID��$* $เลขที่ใบสั่ง��5   7    . $
 Auto 6|   # [  6�    6M   �� *
Order_ID+6�     5      -   5        Order_Day_Count��$/ )อายุใบสั่ง(วัน)��5   >    . $
 Auto 6�   # [  6�    6W   �� *Order_Day_Count+6�     5      -	   5        Order_to��$* $ผู้รับผิดชอบ��5   7    . $
 Auto 6|    6M   �� *
Order_to+6|     5      -
   5        Product_Code��$= 7รหัสวัตถุดิบ/สินค้า��5   ;    . $
 Auto 6�   # [  6�    6X   �� *Product_Code+6�     5      -   5        Operation_Detail��$= 7ชื่อวัตถุดิบ/สินค้า��5   ?    . $
 Auto 6�    6\   �� *Operation_Detail+6�      RowStyle 5!      �� 5"      )  #System.Windows.Controls.DataGridRow"  6   .�5#      -   5        5$      5&      5'      5(      