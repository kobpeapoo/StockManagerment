   M S B A M L   `   `   `  ���� O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:InventoryManagerment.ViewsInventoryManagerment.Views  -    'InventoryManagerment.Views.ProductsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:InventoryManagerment.Views     -     � Title$  Stock Monitor��$	��740��$
��1200�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � 	Resources    RightGridHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  	RightCell��%n   &	        &	 &     �� "  .���  � ��$ Right=��� " ��.���  �@��TextAlignment$ Right=�.��� $��10,0,0,0q� � RowDefinitions �� $	��221 ��� $	��233 ��� $	��255 �.+��� -    ��Name$ 
searchZone�����	#FFE4E8E8$��0,0,5,5q�
���   �	 �� RadiusX$	 5��
 �� RadiusY$
 5���� ���	#FFE8EAEA$
��Left=�$	��119��$��	59,53,0,0q�$
 5��$	 5�����	#FF06A806$	��Top=�$	��584��&   System.Windows.Controls.DataGrid  -     Name$ DataGridPrducts��   CanUserResizeColumns . ��. $��Visible=�   AutoGenerateColumns .     CanUserAddRows .  $��	0,216,5,0q�$	��232��$	��Top=�$��2������ *listProduct+ �� SelectedItem �� *Select_Product+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   RowStyle �� )  #System.Windows.Controls.DataGridRow"   �� Triggers ��  �� Binding �� *
HaveToOder+ �� Value 1.a���  � ��
 ��·�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header �� -    ��Name$ CheckALL��   CellTemplate �� .R��� $ 	chkSelect�� d� 	IsChecked �� *Select_Product+$ TwoWay=�$ PropertyChanged=�0  *System.Windows.Controls.DataGridTextColumn  -   
rowNum��$ ลำดับ��   
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *RowNum+  -   Product_Code��$= 7รหัสวัตถุดิบ/สินค้า��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100  .  �� *Product_Code+  -   Product_Name��$= 7ชื่อวัตถุดิบ/สินค้า��$	 350  .  �� *Product_Name+  -   Use��$! การใช้งาน��$ 80  �� *Use+$ PropertyChanged=�  $	 Min��-	   min��$ 50    HeaderStyle# [     ElementStyle# [  .  �� *	Min_Stock+  -
   Order_To��$ สั่งใคร��$ 50  �� *
Order_to+$ PropertyChanged=�  -   checkTD��$ TD เช็ค จน.��$ 50  �� *
Check_TD+$ PropertyChanged=�  -   checkLP��$ LP เช็ค จน.��$ 50  �� *
Check_LP+$ PropertyChanged=�  -   remainTD��$ คงคลัง TD��$ 60 # [  # [  .  �� *TD_QTY+  -   	reamainLP��$ คงคลัง LP��$ 60 # [  # [  .  �� *LP_QTY+  -   	sumRemain��$ 	รวม��$ 60 # [  # [  .  �� *	TOTAL_QTY+  -   	stockUnit��$ หน่วย��$ 40  .  �� *
SUnit_Name+  -   
convertSum��$ 40 $* $แปลงหน่วยรวม��# [  # [  .  �� *Total_ConvertQTY+  -   convertUnit��$ 40 $! แปลงหน่วย�� .  �� *
SUnit_Name+  -   convertMulti��$ 40 $ ตัวคุณ��# [  # [  .  �� *Factor+  -   convertNote��$ 40 $&  แปลงหน่วย Note�� �� *Note_Unit_Convert+$ PropertyChanged=�  -   Suggest_Order��$0 *ปริมาณสั่งซึ้อ��$ 80 # [  # [  .  �� *Suggest_Order+  -   Suggest_Order_unit��$- 'หน่วยสั่งซื้อ��$ 80  .  �� *
PUnit_Name+  -   SuggestNote��$# สั่งซึ้อ Note��$	 100  �� *Note_Purchase+$ PropertyChanged=�  -   costAvg��$* $ต้นทุนเฉลี่ย��$ 80  �� *	CostAvg+$ PropertyChanged=�  -   costNote��$ ต้นทุนNote��$ 80  �� *
CostNote+$ PropertyChanged=�  -   	empty��$ 	หมด��$ 30  �� *Empty+$ PropertyChanged=�  -   changeTD��$' !เคลื่อนไหว TD��$ 80  .  �� *Chang_Stock_TD+  -   changeLP��$' !เคลื่อนไหว LP��$ 80  .  �� *Chang_Stock_TD+  -   
vendorName��$$ ผู้ขายชื่อ��$	 150  �� *Vendor+$ PropertyChanged=�  -   
vendorNote��$ ผู้ขายNote��$	 100  �� *Note_Vendor+$ PropertyChanged=�  -   	nameOrder��$* $ชื่อสั่งซื้อ��$	 100  �� *Vendor_to_Purchase+$ PropertyChanged=�  -    P0��$ ราคาตั้ง��$ 50 # [  # [  �� *P0+$ PropertyChanged=�  -!   P1��$ 
ลด 1 %��$ 50 # [  # [  �� *P1+$ PropertyChanged=�  -"   P2��$ 
ลด 2 %��$ 50 # [  # [  �� *P2+$ PropertyChanged=�  -#   P3��$ 
ลด 3 %��$ 50 # [  # [  �� *P3+$ PropertyChanged=�  -$   
P_Note��$
 Note��$	 100  �� *P_Note+$ PropertyChanged=�  -%   VAT��$	 VAT��$ 50  �� *VAT+$ PropertyChanged=�  -&   S0��$' !ราคาขายปลีก��$ 50 # [  # [  �� *S0+$ PropertyChanged=�  -'   S1��$&  ราคาขายส่ง 1��$ 50 # [  # [  �� *S1+$ PropertyChanged=�  -(   S2��$&  ราคาขายส่ง 2��$ 50 # [  # [  �� *S2+$ PropertyChanged=�  -)   S3��$1 +ราคาขายส.ศิริ ศ93��# [  # [ $ 50  �� *S3+$ PropertyChanged=�  -*   
S_Note��$
 Note��$ 80  �� *S_Note+$ PropertyChanged=�  -+   QC_Form��$ QC Form��$ 60  �� *	QC_Form+$ PropertyChanged=��� -,     ��Name$  BtnExit��$-��'ออกจากโปรแกรม��$��1025,0,0,28q�$��2��! J� RenderTransformOrigin$! -0.109,0.45&�$��16(�$
��Bold"�$
��Left=�$	��147��$��39��$��Bottom=��� --   " ��Name$" datail��$>��8ชื่อวัตถุดิบ/สินค้า ��$��632,0,449,195q�$��2��$��12(�$��33��$��Bottom=��� -.   $" LbProduct_code��$=��7รหัสวัตถุดิบ/สินค้า��$
��Left=�$��	68,73,0,0q�$	��Top=�$��26��$��99���� -/   # ��Name$# TbProduct_code��$
��Left=�$��23��$��
175,70,0,0q�$ �� TextWrapping$
$ Wrap=�$�� ��$	��Top=�$	��164���� -0   $" LbProduct_Name��$=��7ชื่อวัตถุดิบ/สินค้า��$
��Left=�$��
72,102,0,0q�$	��Top=�$��92��$��26���� -1   $# TbProduct_Name��$
��Left=�$��23��$��175,102,0,0q�$
$ Wrap=�$�� ��$	��Top=�$	��164���� -2   $  	btnSearch��$'��!ค้นหาข้อมูล��$
��Left=�$��532,184,0,0q�$��74��$! 
0.723,1.65&�$��20��$	��Top=��� -3   $  btnClear��$-��'เคลียร์ข้อมูล��$
��Left=�$��632,184,0,0q�$	��Top=�$��75��$��20���� -4   $# txtDatailSelect��$��
739,34,0,0q�$��2��$
$ Wrap=�$�� ��% �� 
IsReadOnly% . $��60��$	��Top=�$
��Left=�$	��433���� -5   $# textCurentDate��$
��Left=�$��23��$��
150,12,0,0q�$
$ Wrap=�$�� ��$	��Top=�$	��120��% . �� -6   $" label��$*��$วันที่ใช้งาน��$
��Left=�$	��Top=�$��58,9,0,0q�$��77��$
��Bold"�$��26���� -7   $" labUse��$!��การใช้งาน��$
��Left=�$��102,133,0,0q�$	��Top=�$��62��$��26���� -8   $# textUse��$
��Left=�$��23��$��175,138,0,0q�$
$ Wrap=�$�� ��$	��Top=�$	��164���� -9   $# textOrderTO��$
��Left=�$��23��$��
450,70,0,0q�$
$ Wrap=�$�� ��$	��Top=�$	��165���� -:   $" labVendorName��$$��ชื่อผู้ขาย��$
��Left=�$��
379,99,0,0q�$	��Top=�$��63��$��26���� -;   $# textVendorName��$
��Left=�$��23��$��450,102,0,0q�$
$ Wrap=�$�� ��$	��Top=�$	��165���� -<   $  btnPrint��$6��0ออกใบสั่งงานย่อย��$
��Left=�$��
866,0,0,28q�$��2��$	��133��$��16(�$
��Bold"�$��39��$��Bottom=��� -=   $" lbUse��$!��การใช้งาน��$
��Left=�$��
663,96,0,0q�$��2��$	��Top=�$! -0.237,0.231&�$��26��$��70���� ->   $# txtUseDetail��% . $��62��$��
739,99,0,0q�$��2��$
$ Wrap=�$�� ��$	��Top=�$
��Left=�$	��433���� -?   $" label1��$<��6ประวัติการสั่งซื้อ��$��0,120,0,109q�$��2��$
��Bold"�
���   �& J� OpacityMask& �	#FFD31616���	#FFF9ED73$
��Left=�$	��100��  -@   $ dataGridPurHis�� .   .  $��	0,147,0,0q�$��2��$��98��$	��Top=�$
��Left=�$	��606������ *lsPurchaseHis+   $ ลำดับ��$ 40  �� *RowNum+  $$ วันที่ซื้อ��$ 80  �� *PURCHASE_DATE+  $$ รหัสผู้ขาย��$ 80  �� *VENDOR_CODE+  $$ ชื่อผู้ขาย��$	 120  �� *VENDOR_NAME+  # [  # [ $ จำนวน��$ 80  �� *QTY+  # [  # [ $ ราคา��$ 80  �� *PRICE+  $ ส่วนลด��$ 60  �� *DISCOUNT_STR+  # [  # [ $ % VAT��$ 60  �� *
VAT_RATE+�� -A   $" label2��$)��#  ค้นหารายการ��$
��Left=�$��	70,40,0,0q�$	��Top=�$��86��&	   System.Windows.Media.TextOptions' 	  TextFormattingMode$' Display=����	#FFE4E8E8���	#FF047021$��25���� ���	#FFE4E8E8$	��119��$��
726,53,0,0q�$
 5��$	 5�����	#FF019B2B$	��Top=�$
��Left=�$	��412���� -B   $" label2_Copy��$&��   กรองข้อมูล��$
��Left=�$��
747,40,0,0q�$	��Top=�$��86��$' Display=����	#FFE4E8E8���	#FF047021$��25���� -C   $" 	labRemain��$.��(แสดง Stock คงเหลือ��$
��Left=�$��
747,67,0,0q�$	��Top=�$��26��$	��113��$! -0.039,-0.462&�	� -D   ( 	�Name$( radBtn1��) 	� 	GroupName$) reamin��$��ทั้งหมด��$
��Left=�$��
776,98,0,0q�$	��Top=�$��15��$��51��$! 	6.882,6.4&�	� -E   $( radBtn2��$) reamin��$B��<น้อยกว่า/เท่ากับ Minimum (10%)��$
��Left=�$��776,121,0,0q�$	��Top=�$��15��$	��209��	� -F   $( radBtn3��$) reamin��$H��Bเฉพาะรายการที่ต้องสั่ง��$
��Left=�$��776,144,0,0q�$
 TrueY�$	��Top=�$��15��$	��144���� -G   $" label1_Copy��$H��Bประวัติการออกใบงานย่อย��$��	0,3,0,227q�$��2��$
��Bold"�
���   �& �	#FFD31616���	#FFF9ED73$
��Left=�$	��142��  -H   $ dataGridHistoryOrder�� .   .  $
��Left=�$��0,29,0,0q�$��2��$	��Top=�$! -1.417,-0.231&�$	��606��$��90������ *lsOrderHisStock+ �� "   ��  �� *orderStatus+ รอปิดงาน.a���  � ��
 �  ��   $* $วันที่เอกสาร��$ 90  .  �� *	docDate+  $* $เลขที่เอกสาร��$ 90  .  �� *list_Num_Order+  $7 1เรื่อง/รายละเอียด��$	 250  .  �� *topic+  $! จำนวนสั่ง��$ 80 # [  # [  .  �� *suggestOrder+  $ สถานะ��$ 90  .  �� *orderStatus+�� -I   $" Order_to��$��สั่งใคร��$
��Left=�$��
379,70,0,0q�$	��Top=�$��63��$��26��