   M S B A M L   `   `   `  ���� O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:InventoryManagerment.ViewsInventoryManagerment.Views  .    (InventoryManagerment.Views.OrderListView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:InventoryManagerment.Views     Mdxre<http://schemas.devexpress.com/winfx/2008/xaml/reportdesigner     -     � Title$  OrderListView��$	��700��$
��1100�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $	��100 ��� $	��450 ��� $	��150 �.+��� ���	#FFF4FBFB$��10q� �� RadiusY$ 5�� �� RadiusX$ 5��
���   �&   System.Windows.Controls.DataGrid  -     Name$ datagridOrder��   CanUserAddRows .  $
��Left=�$��	10,10,0,0q�$��1��$	��Top=�$	��480��$
��1072��   AutoGenerateColumns .  ���� *	lsOrder+   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   
rowNum��,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 
   Header$
 ลำดับ��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *RowNum+   ClipboardContentBinding Z�   -   running��$	 90 $-
 'รหัสใบสั่งงาน�� �� *OrderNumber+ Z�   -   productCode��$	 80 $

 Code�� �� *Product_code+ Z�   -   productName��$		 300 $
 Product Name�� �� *Product_Name+ Z�   -   use��$		 200 $	
 Use�� �� *Use+ Z�   -   	topic��$		 100 $
 เรื่อง�� �� *Topic+ Z�   -	   remainTD��$		 100 $
 คงเหลือ TD�� �� *
ReaminTD+ Z�   -
   remainLD��$		 100 $
 คงเหลือ LP�� �� *
RemainLP+ Z�   -   	remainAll��$		 150 $$
 คงเหลือรวม�� �� *	RemainAll+ Z�   -   suggest_Order��$		 100 $!
 จำนวนสั่ง�� �� *Suggest_Order+ Z�   -   minimumStock��$		 100 $*
 $คงเหลือตำสุด�� �� *MinumunStock+ Z�   -   toOwner��$		 100 $
 	ถึง�� �� *	ToOwner+ Z� �� -    ��Name$ create��$<��6สร้างใบสั่งงานย่อย��$��810,64,150,41q�$��2��$��14.667(��� -   $ btnClose��$!��ปิดหน้าจอ��$��964,64,10,41q�$��2��$��14.667(��� -    ��Name$ label1��$,��&เลขที่เอกสาร :��$
��Left=�$��
442,24,0,0q�$	��Top=� J� RenderTransformOrigin$ -0.513,0.442&�$	��105��$��16(��� -    ��Name$ txtDate��$
��Left=�$��23��$��
196,27,0,0q� �� TextWrapping$
 Wrap=�$�� �� �� 
IsReadOnly . $	��Top=�$	��172��$��16(��� -   $ txtDocNumber��$
��Left=�$��23��$��
572,28,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��172��$��16(��� -   $ label��$��วันที่ : ��$��85,25,925,45q�$ 0.5,0.5&�$��16(�z�V� .~��� �� ��  �� Angle$ -0.744Q�T� �� ���	#FFF4FBFB$
��Left=�$��
10,10,0,41q�$ 5��$��2��$ 5��
���   �$	��766���� -   $ label2��$'��!รายละเอียด : ��$
��Left=�$��	32,27,0,0q�$��2��$	��Top=�$ 0.158,0.115&�$��88��$��36��$��14.667(��� -   $ txtDetailSelect��$
��Left=�$��59��$��
143,27,0,0q�$��2��$
 Wrap=�$�� ��$	��Top=�$	��601��