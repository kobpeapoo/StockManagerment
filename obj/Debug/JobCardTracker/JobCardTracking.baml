   M S B A M L   `   `   `  ����O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:InventoryManagerment.JobCardTracker#InventoryManagerment.JobCardTracker  5   	   o<clr-namespace:InventoryManagerment.JobCardTracker.Controller.InventoryManagerment.JobCardTracker.Controller  5   	   9    3InventoryManagerment.JobCardTracker.JobCardTracking   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:InventoryManagerment.JobCardTracker     5   	   Jc<clr-namespace:InventoryManagerment.JobCardTracker.Controller     5   	     �Language$  th-TH�5   	   -   5         � Title$3 -ติดตามใบงานย่อย��5
   	   $
��1024��6!   $	��700��6.    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowState$ 	Maximized=�5   	    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value	 ��Name
 �� Path �� StringFormat �� RelativeSource �� AncestorType(  "System.Windows.Controls.DatePicker   styleCalendar&   System.Windows.Controls.Calendar5  /System.Windows.Controls.Primitives.CalendarItem  Name=  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell  DataGridCellCenter  DataGridCellRightD   >InventoryManagerment.JobCardTracker.Controller.ModTenConverter 
 ModTen��%3  '        &	  �     '  �    &	 1    &	 �    &	 �    �� 5   
   "  6   .�5      ��  �@��
IsReadOnly . 6+   �� 5       � �� 5      �� 5      .R�5      �� $	 PART_TextBox��6"   ��68   �� $
 SelectedDate�$ 
dd/MM/yyyy�� �� "  5      5      5      �� 5   
   "  6&   .�5      ��  � �� 5      �� 5      .R�5      (� .��5        $ PART_CalendarItem��6+   #��z��5    '   #��z��5!   '   #��z��5"   '   5#      5$      54      56      57      �� 58   
   "  6   .�59      ��  � ��$ Center=�6;   5:      �� 5;   
   "  6   .�5<      ��  �@��TextAlignment$ Center=�68   5=      �� 5>   
   "  6   .�5?      ��  �@��TextAlignment$ Right=�68   5@        5B   
   6   5D      .��5F      � .+�5G   
   �� ���	#FFF4F4F5$	��230��6%   $��
10,10,10,0q�62   
���   �$	��Top=�6U   �� 5H   
   -   5         ��Name$ groupBox��5H      $'��!ค้นหารายการ��6%   $
��Left=�6:   $��	32,23,0,0q�6U   $	��Top=�6h   $	��144��6�   $	��505��6�   �� 5I   
   -   5        $ groupBox_Copy��5I      $$��กรองข้อมูล��6*   $��
558,22,0,0q�6>   $	��Top=�6R   $	��145��6j   $
��Left=�6w   $	��392��6�   �� 5K   
   -   5         ��Name$ label1��5K      $=��7รหัสวัตถุดิบ/สินค้า��6    $
��Left=�6>   $��	52,56,0,0q�6Y   $	��Top=�6l   �� 5L   
   -   5        $	 txtProductId��5L      $
��Left=�6(   $��23��6C   $��
149,59,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5M   
   -   5        $ label2��5M      $=��7ชื่อวัตถุดิบ/สินค้า��6    $
��Left=�6>   $��	52,85,0,0q�6Y   $	��Top=�6l   �� 5N   
   -   5        $	 txtProductName��5N      $
��Left=�6*   $��23��6E   $��
149,88,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5P   
   -   5        $ label4��5P      $*��$ผู้รับผิดชอบ��6    $
��Left=�67   $��
291,56,0,0q�6R   $	��Top=�6f   �� 5Q   
   -	   5        $	 txtOwner��5Q      $
��Left=�6$   $��23��6?   $��
389,59,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5R   
   -
   5        $ label5��5R      $$��ชื่อผู้ขาย��6    $
��Left=�65   $��
291,85,0,0q�6P   $	��Top=�6d   �� 5S   
   -   5        $	 	txtVender��5S      $
��Left=�6%   $��23��6@   $��
389,88,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5T   
   -   5        $ label6��5T      $*��$เลขที่ใบสั่ง��6    $
��Left=�67   $��
51,114,0,0q�6R   $	��Top=�6f   �� 5U   
   -   5        $	 txtOrderNumber��5U      $
��Left=�6*   $��23��6E   $��149,117,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5W   
   -   5        $ label7��5W      $0��*สถานะใบสั่งงาน��6    $
��Left=�69   $��
578,56,0,0q�6T   $	��Top=�6h   	� 5X   
   -   5         	�Name$ rdoStatusAll��5X      $��ทั้งหมด��6,   $
��Left=�6>   $��
670,63,0,0q�6Y   $	��Top=�6m   	� 5Y   
   -   5        $ rdoStatusWait��5Y      $��รอปิดงาน��6-   $
��Left=�6@   $��
770,63,0,0q�6[   $	��Top=�6o    d� 	IsChecked$
 TrueY�6�   	� 5Z   
   -   5        $ rdoStatusClose��5Z      $��ปิดงาน��6.   $
��Left=�6?   $��
870,63,0,0q�6Z   $	��Top=�6n   �� 5[   
   -   5        $ label8��5[      $-��'วันที่สั่งงาน��6    $
��Left=�68   $��
578,85,0,0q�6S   $	��Top=�6g     5\   
   -   5          Name$ dpOrderFrom��5\         CalendarStyle# [  6*   $
��Left=�6Y   $��23��6t   $��
647,88,0,0q�6�   $	��Top=�6�   $	��120��6�   �� 5]   
   -   5        $ label9��5]      $*��$วันที่ปิดงาน��6    $
��Left=�67   $��578,114,0,0q�6R   $	��Top=�6g     5^   
   -   5        $ dpOrderCloseFrom��5^      # [  6/   $
��Left=�6^   $��23��6y   $��647,117,0,0q�6�   $	��Top=�6�   $	��120��6�   �� 5`   
   -   5        $ label10��5`      $��	ถึง��6!   $
��Left=�6/   $��
772,85,0,0q�6J   $	��Top=�6^     5a   
   -   5        $ 	dpOrderTo��5a      # [  6(   $
��Left=�6W   $��23��6r   $��
801,88,0,0q�6~   $	��Top=�6�   $	��120��6�   �� 5b   
   -   5        $ label11��5b      $��	ถึง��6!   $
��Left=�6/   $��772,114,0,0q�6J   $	��Top=�6_     5c   
   -   5        $ dpOrderCloseTo��5c      # [  6-   $
��Left=�6\   $��23��6w   $��801,117,0,0q�6�   $	��Top=�6�   $	��120��6�   �� 5e   
   -   5         ��Name$ 	btnSearch��5e      $'��!ค้นหาข้อมูล��6$   $
��Left=�6:   $��377,184,0,0q�6U   $	��Top=�6j   $	��108��6�   $��36��6�   6�   �� 5f   
   -   5        $ btnClear��5f      $��เครียร์��6#   $
��Left=�65   $��508,184,0,0q�6P   $	��Top=�6e   $	��108��6}   $��36��6�   6�   &   System.Windows.Controls.DataGrid  5h   
   -   5          Name$ dgMainContent��5h      $��10,254,10,0q�6*   $	��Top=�6?   $	��186��6W      AutoGenerateColumns .     CanUserAddRows .     Columns 5j      0	  *System.Windows.Controls.DataGridTextColumn	  5k      -   5        Order_Detail_ID��,
  &System.Windows.Controls.DataGridColumn 
  
Visibility$ Hidden=�5k   b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Order_Detail_ID+6b   	  5l      -   5        	RowNo�� 
  Header$ ลำดับ��5l   4    
  
IsReadOnly .  
  Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6o     
  	CellStyle#  [ 6|    6C   �� *RowNo+6|   	  5m      -   5        
CreateDate��$ วันที่��5m   9    . $
 Auto 6z   #  [ 6�    6I   �� *
CreateDate+6�   	  5n      -    5        Order_ID��$* $เลขที่ใบสั่ง��5n   7    . $
 Auto 6|   #  [ 6�    6M   �� *
Order_ID+6�   	  5o      -!   5        OrderDayCount��$. (อายุใบสั่ง/วัน��5o   <    . $
 Auto 6�   #  [ 6�    6T   �� *OrderDayCount+6�   	  5p      -"   5        Order_to��$* $ผู้รับผิดชอบ��5p   7    . $
 Auto 6|    6M   �� *
Order_to+6|   	  5q      -#   5        Product_Code��$= 7รหัสวัตถุดิบ/สินค้า��5q   ;    . $
 Auto 6�    6X   �� *Product_Code+6�   	  5r      -$   5        Operation_Detail��$= 7ชื่อวัตถุดิบ/สินค้า��5r   ?    . $
 Auto 6�    6\   �� *Operation_Detail+6�   	  5s      -%   5        
Vendor��$$ ชื่อผู้ขาย��5s   5    . $
 Auto 6v    6I   �� *Vendor+6v   	  5t      -&   5        Suggest_Order��$! จำนวนสั่ง��5t   <    . $
 Auto 6�   #  [ 6�    6O   �� *Suggest_Order+6�   	  5u      -'   5        	Min_Stock��$	 Min��5u   8    . $
 Auto 6u   #  [ 6�    6E   �� *	Min_Stock+6�   	  5v      -(   5        
TD_QTY��$ เหลือ TD��5v   5    . $
 Auto 6t   #  [ 6�    6G   �� *TD_QTY+6�   	  5w      -)   5        
LP_QTY��$ เหลือ LP��5w   5    . $
 Auto 6t   #  [ 6�    6G   �� *LP_QTY+6�   	  5x      -*   5        	TOTAL_QTY��$ เหลือรวม��5x   8    . $
 Auto 6z   #  [ 6�    6J   �� *	TOTAL_QTY+6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5y      -+   5        Order_Status��$( "สถานะ (รอ/ปิด)��5y   ?   $
 Auto 6�   #  [ 6�    6W   �� *Order_Status+! �� UpdateSourceTrigger$! PropertyChanged=�6�   	  5z      -,   5        
Note_Close��$ Note ปิด��5z   9    .  $
 Auto 6�    6K   �� *
Note_Close+$! PropertyChanged=�6�   	  5{      --   5        	closeDate��$! วันที่ปิด��5{   8    . $
 Auto 6{   #  [ 6�    6K   �� *	closeDate+6�   5�      �� 5�   
   -.   5        $ label1_Copy��5�      $6��0ประวัติการติดตาม��6%   $��
10,450,0,0q�6@   $
��Bold"�6T   
���   �" J� OpacityMask" �	#FFD31616���	#FFF9ED73$
��Left=�6�   $	��100��6�   $��26��6�   $	��Top=�6�     5�   
   -/   5        $ dgFollowCard��5�      $
��Left=�6)   $��10,476,0,20q�6D   $	��475��6Y   # J� RenderTransformOrigin$# -0.43,0.202&�6e    .   .   5�      	  5�      -0   5        FollowNo��$- 'ครั้งที่เตือน��5�   7    . $
 Auto 6   #  [ 6�    6N   �� *
Warning_No+6�   	  5�      -1   5        WarningDate��$' !วันที่เตือน��5�   :    . $
 Auto 6�   #  [ 6�    6O   �� *Warning_Date+6�   	  5�      -2   5        	NotedDate��$- 'วันที่รับทราบ��5�   8    . $
 Auto 6�   #  [ 6�    6O   �� *Warning_Noted_Date+6�   	  5�      -3   5        
Reason��$ เหตุผล��5�   5    . $ * 6r    6E   �� *Reason+6r   5�      5�      5�      