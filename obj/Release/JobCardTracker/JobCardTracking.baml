   M S B A M L   `   `   `  ���� O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:InventoryManagerment.JobCardTracker#InventoryManagerment.JobCardTracker  o<clr-namespace:InventoryManagerment.JobCardTracker.Controller.InventoryManagerment.JobCardTracker.Controller  9    3InventoryManagerment.JobCardTracker.JobCardTracking   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Clocal1clr-namespace:InventoryManagerment.JobCardTracker     Jc<clr-namespace:InventoryManagerment.JobCardTracker.Controller       �Language$  th-TH�-    � Title$3 -ติดตามใบงานย่อย��$
��1024��$	��700�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � 	Resources :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value	 ��Name
 �� Path �� StringFormat �� RelativeSource �� AncestorType(  "System.Windows.Controls.DatePicker   styleCalendar&   System.Windows.Controls.Calendar5  /System.Windows.Controls.Primitives.CalendarItem  Name=  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell  DataGridCellCenter  DataGridCellRightD   >InventoryManagerment.JobCardTracker.Controller.ModTenConverter 
 ModTen��%�  '        &	  �     '  �     &	     &	 T    &	 �    �� "  .���  �@��
IsReadOnly . ��  � �� �� .R��� $	 PART_TextBox������ $
 SelectedDate�$ 
dd/MM/yyyy�� �� "  �� "  .���  � �� �� .R�(� .��  $ PART_CalendarItem��#��z��#��z��#��z���� "  .���  � ��$ Center=��� "  .���  �@��TextAlignment$ Center=��� "  .���  �@��TextAlignment$ Right=�  .��� .+��� ���	#FFF4F4F5$	��230��$��
10,10,10,0q�
���   �$	��Top=��� -    ��Name$ groupBox��$'��!ค้นหารายการ��$
��Left=�$��	32,23,0,0q�$	��Top=�$	��144��$	��505���� -   $ groupBox_Copy��$$��กรองข้อมูล��$��
558,22,0,0q�$	��Top=�$	��145��$
��Left=�$	��392���� -    ��Name$ label1��$=��7รหัสวัตถุดิบ/สินค้า��$
��Left=�$��	52,56,0,0q�$	��Top=��� -   $	 txtProductId��$
��Left=�$��23��$��
149,59,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��120���� -   $ label2��$=��7ชื่อวัตถุดิบ/สินค้า��$
��Left=�$��	52,85,0,0q�$	��Top=��� -   $	 txtProductName��$
��Left=�$��23��$��
149,88,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -   $ label4��$*��$ผู้รับผิดชอบ��$
��Left=�$��
291,56,0,0q�$	��Top=��� -	   $	 txtOwner��$
��Left=�$��23��$��
389,59,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -
   $ label5��$$��ชื่อผู้ขาย��$
��Left=�$��
291,85,0,0q�$	��Top=��� -   $	 	txtVender��$
��Left=�$��23��$��
389,88,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -   $ label6��$*��$เลขที่ใบสั่ง��$
��Left=�$��
51,114,0,0q�$	��Top=��� -   $	 txtOrderNumber��$
��Left=�$��23��$��149,117,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -   $ label7��$0��*สถานะใบสั่งงาน��$
��Left=�$��
578,56,0,0q�$	��Top=�	� -    	�Name$ rdoStatusAll��$��ทั้งหมด��$
��Left=�$��
670,63,0,0q�$	��Top=�	� -   $ rdoStatusWait��$��รอปิดงาน��$
��Left=�$��
770,63,0,0q�$	��Top=� d� 	IsChecked$
 TrueY�	� -   $ rdoStatusClose��$��ปิดงาน��$
��Left=�$��
870,63,0,0q�$	��Top=��� -   $ label8��$-��'วันที่สั่งงาน��$
��Left=�$��
578,85,0,0q�$	��Top=�  -     Name$ dpOrderFrom��   CalendarStyle# [  $
��Left=�$��23��$��
647,88,0,0q�$	��Top=�$	��120���� -   $ label9��$*��$วันที่ปิดงาน��$
��Left=�$��578,114,0,0q�$	��Top=�  -   $ dpOrderCloseFrom��# [  $
��Left=�$��23��$��647,117,0,0q�$	��Top=�$	��120���� -   $ label10��$��	ถึง��$
��Left=�$��
772,85,0,0q�$	��Top=�  -   $ 	dpOrderTo��# [  $
��Left=�$��23��$��
801,88,0,0q�$	��Top=�$	��120���� -   $ label11��$��	ถึง��$
��Left=�$��772,114,0,0q�$	��Top=�  -   $ dpOrderCloseTo��# [  $
��Left=�$��23��$��801,117,0,0q�$	��Top=�$	��120���� -    ��Name$ 	btnSearch��$'��!ค้นหาข้อมูล��$
��Left=�$��377,184,0,0q�$	��Top=�$	��108��$��36���� -   $ btnClear��$��เครียร์��$
��Left=�$��508,184,0,0q�$	��Top=�$	��108��$��36��&   System.Windows.Controls.DataGrid  -     Name$ dgMainContent��$��10,254,10,0q�$	��Top=�$	��186��   AutoGenerateColumns .     CanUserAddRows .     Columns 0	  *System.Windows.Controls.DataGridTextColumn	  -   Order_Detail_ID��,
  &System.Windows.Controls.DataGridColumn 
  
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Order_Detail_ID+	  -   	RowNo�� 
  Header$ ลำดับ�� 
  
IsReadOnly .  
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto   
  	CellStyle#  [  �� *RowNo+	  -   
CreateDate��$ วันที่�� . $
 Auto #  [  �� *
CreateDate+	  -    Order_ID��$* $เลขที่ใบสั่ง�� . $
 Auto #  [  �� *
Order_ID+	  -!   OrderDayCount��$. (อายุใบสั่ง/วัน�� . $
 Auto #  [  �� *OrderDayCount+	  -"   Order_to��$* $ผู้รับผิดชอบ�� . $
 Auto  �� *
Order_to+	  -#   Product_Code��$= 7รหัสวัตถุดิบ/สินค้า�� . $
 Auto  �� *Product_Code+	  -$   Operation_Detail��$= 7ชื่อวัตถุดิบ/สินค้า�� . $
 Auto  �� *Operation_Detail+	  -%   
Vendor��$$ ชื่อผู้ขาย�� . $
 Auto  �� *Vendor+	  -&   Suggest_Order��$! จำนวนสั่ง�� . $
 Auto #  [  �� *Suggest_Order+	  -'   	Min_Stock��$	 Min�� . $
 Auto #  [  �� *	Min_Stock+	  -(   
TD_QTY��$ เหลือ TD�� . $
 Auto #  [  �� *TD_QTY+	  -)   
LP_QTY��$ เหลือ LP�� . $
 Auto #  [  �� *LP_QTY+	  -*   	TOTAL_QTY��$ เหลือรวม�� . $
 Auto #  [  �� *	TOTAL_QTY+4  .System.Windows.Controls.DataGridCheckBoxColumn  -+   Order_Status��$( "สถานะ (รอ/ปิด)��$
 Auto #  [  �� *Order_Status+! �� UpdateSourceTrigger$! PropertyChanged=�	  -,   
Note_Close��$ Note ปิด�� .  $
 Auto  �� *
Note_Close+$! PropertyChanged=�	  --   	closeDate��$! วันที่ปิด�� . $
 Auto #  [  �� *	closeDate+�� -.   $ label1_Copy��$6��0ประวัติการติดตาม��$��
10,450,0,0q�$
��Bold"�
���   �" J� OpacityMask" �	#FFD31616���	#FFF9ED73$
��Left=�$	��100��$��26��$	��Top=�  -/   $ dgFollowCard��$
��Left=�$��10,476,0,20q�$	��475��# J� RenderTransformOrigin$# -0.43,0.202&� .   .   	  -0   FollowNo��$- 'ครั้งที่เตือน�� . $
 Auto #  [  �� *
Warning_No+	  -1   WarningDate��$' !วันที่เตือน�� . $
 Auto #  [  �� *Warning_Date+	  -2   	NotedDate��$- 'วันที่รับทราบ�� . $
 Auto #  [  �� *Warning_Noted_Date+	  -3   
Reason��$ เหตุผล�� . $ *  �� *Reason+