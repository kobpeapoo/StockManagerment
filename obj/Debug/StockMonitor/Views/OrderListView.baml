   M S B A M L   `   `   `  ����O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:InventoryManagerment.ViewsInventoryManagerment.Views  5   	   .    (InventoryManagerment.Views.OrderListView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:InventoryManagerment.Views     5   	   Mdxre<http://schemas.devexpress.com/winfx/2008/xaml/reportdesigner     5   	   -   5          � Title$  OrderListView��5	   	   $	��700��6   $
��1100��6,    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��450 �6   �� 5      $	��150 �6   .+�5   
   �� ���	#FFF4FBFB$��10q�6%    �� RadiusY$ 5��61    �� RadiusX$ 5��6=   
���   �6I   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagridOrder��5         CanUserAddRows .  $
��Left=�6a   $��	10,10,0,0q�6|   $��1��6�   $	��Top=�6�   $	��480��6�   $
��1072��6�      AutoGenerateColumns .  ��6A   �� *	lsOrder+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
rowNum��,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 5   5   
   Header$
 ลำดับ��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *RowNum+   ClipboardContentBinding 6j   Z�   5      -   5        running��$	 90 5   6   $-
 'รหัสใบสั่งงาน��6A    6X   �� *OrderNumber+ 6x   Z�   5      -   5        productCode��$	 80 5   :   $

 Code��6E    6S   �� *Product_code+ 6t   Z�   5      -   5        productName��$		 300 5   :   $
 Product Name��6F    6\   �� *Product_Name+ 6}   Z�   5      -   5        use��$		 200 5   3   $	
 Use��6?    6L   �� *Use+ 6d   Z�   5      -   5        	topic��$		 100 5   4   $
 เรื่อง��6@    6P   �� *Topic+ 6j   Z�   5      -	   5        remainTD��$		 100 5   7   $
 คงเหลือ TD��6C    6W   �� *
ReaminTD+ 6t   Z�   5      -
   5        remainLD��$		 100 5   7   $
 คงเหลือ LP��6C    6W   �� *
RemainLP+ 6t   Z�   5      -   5        	remainAll��$		 150 5   8   $$
 คงเหลือรวม��6D    6X   �� *	RemainAll+ 6v   Z�   5       -   5        suggest_Order��$		 100 5    <   $!
 จำนวนสั่ง��6H    6[   �� *Suggest_Order+ 6}   Z�   5!      -   5        minimumStock��$		 100 5!   ;   $*
 $คงเหลือตำสุด��6G    6]   �� *MinumunStock+ 6~   Z�   5"      -   5        toOwner��$		 100 5"   6   $
 	ถึง��6B    6O   �� *	ToOwner+ 6k   Z� 5$      �� 5%   
   -   5         ��Name$ create��5%      $<��6สร้างใบสั่งงานย่อย��6!   $��810,64,150,41q�6>   $��2��6U   $��14.667(�6b   �� 5&   
   -   5        $ btnClose��5&      $!��ปิดหน้าจอ��6#   $��964,64,10,41q�67   $��2��6M   $��14.667(�6Z   6l   �� 5'   
   -   5         ��Name$ label1��5'      $,��&เลขที่เอกสาร :��6    $
��Left=�69   $��
442,24,0,0q�6T   $	��Top=�6h    J� RenderTransformOrigin$ -0.513,0.442&�6�   $	��105��6�   $��16(�6�   �� 5(   
   -   5         ��Name$ txtDate��5(      $
��Left=�6#   $��23��6>   $��
196,27,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r    �� 
IsReadOnly . $	��Top=�6�   $	��172��6�   $��16(�6�   �� 5)   
   -   5        $ txtDocNumber��5)      $
��Left=�6(   $��23��6C   $��
572,28,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6�   $	��172��6�   $��16(�6�   �� 5*   
   -   5        $ label��5*      $��วันที่ : ��6   $��85,25,925,45q�63   $ 0.5,0.5&�6I   $��16(�6i   z�5+      V� 5,      .~�5-      �� �� 5.      �� 5/       �� Angle$ -0.744Q�6&   T� 50      51      53      �� 54   
   ���	#FFF4FBFB$
��Left=�6%   $��
10,10,0,41q�6@   $ 5��6T   $��2��6`   $ 5��6m   
���   �$	��766��6�   �� 55   
   -   5        $ label2��55      $'��!รายละเอียด : ��6    $
��Left=�68   $��	32,27,0,0q�6S   $��2��6f   $	��Top=�6s   $ 0.158,0.115&�6�   $��88��6�   $��36��6�   $��14.667(�6�   �� 56   
   -   5        $ txtDetailSelect��56      $
��Left=�6+   $��59��6F   $��
143,27,0,0q�6R   $��2��6f   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��601��6�   58      59      