   M S B A M L   `   `   `  ���� O  KInventoryManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:InventoryManagermentInventoryManagerment  '    !InventoryManagerment.PortalWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:InventoryManagerment       � Title$N  Hระบบบริหารจัดการวัตถุดิบ��$	��600��$	��800�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� $��0,0,2,0q����	#FFBBBBBB.+��� -    ��Name$ 
tabControl��$��0,0,0,78q�.@��� $ ��ระบบ Stock Monitor������  �� EndPoint$	 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFF0F0F0�� � Offset$ 0Q�� $ 	#FF44ABF1��$ 1Q�.��� ���	#FFEDF8FB$��
0,4,-2,-11q�$��Right=�$	��788�� � ColumnDefinitions �� $
��138* ��� $
��138* ��� $
��239* ��� $
��135* ��� $
��138* �	 � RowDefinitions	 �� $
��135* ��� $
��147* ��� $
��142* �.+��� -   
 ��Name$
 StockMonitor��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��119��$��99��$��RightToLeft=�.���� $��97��$	��119��._�� 	 �� $	��49* ��� $	��48* �.+��� -    ��Name$ image��$��Img/evaluasi.png��$��
21,0,16,27q�$��2���� -    ��Name$ label��$3��-ตรวจสอบวัตถุดิบ��$
��Left=�$��3,15,0,0q�$	��112��$��Center=�$��16(�$��Arial Narrow)�$��	Condensed&�$
��Bold"����	#FF042EEA$��1��� $��1��$��10,96,10,11q��� -   $
 btnCheckHistoryOrder��$��1��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��118��$��97��.���  �� �� $��0* �	 �� $��0* ��� .+��� -   $ image2��$��Img/audit1.png��$��-10,-29,-17,-13q�$��1�� J� RenderTransformOrigin$ 1.515,-0.172&�$
��Left=�$	��100��$��2���� $<��6ประวัติการสั่งซื้อ��$��-18,42,-17,-21q�$��1��$��2�����	#FF0E18F5$
��Left=�$	��108��$
��Bold"�$��14(��� $9��3ระบบวางแผนการผลิต�����	#FF52BBEC���� $	 0,1&�$	 0,0&�.��� $ 	#FFF0F0F0��$ 0Q�� $ 	#FF44ABF1��$ 1Q�.��� ���	#FFF9F7F7$��0,0,4,0q� �� $	��34* ��� $
��347* ��� $��	0,498,0,0q�$��73��$	��Top=���
� .��� $ 	#FF22E4F7��� $ 	#FF0A5A87��$ 1Q�� $ 	#FF0A5A87��$ 1Q��� -   $ label1��$����บริษัท ชาร์จแอนด์เวลด์ อินเตอร์เนชั่นแนล จำกัด��$
��Left=�$��
10,499,0,0q�$	��Top=�$	��346��$��33�����	#FFFBFBFB$��16(�$
��Bold"� J� OpacityMask �� $ 0.5,1&�$ 0.5,0&�.��� $ Black��$ 0Q�� $ 	#FFEA2F2F��$ 1Q��� -   $ label3��$����33,37ซอยบุญอุดม(ลาดพร้าว106แยก1)ถนนลาดพร้าว แขวงวังทองหลาง เขตวังทองหลาง กรุงเทพฯ 10310  Tel. (662) 538-9171-2,931-9295 Fax. (662) 514-3380��$
��Left=�$��10,523,0,10q�$	��772�����	#FFFFFDFD