   M S B A M L   `   `   `  ����L  HWPFPluginTemplate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFPluginTemplateWPFPluginTemplate  5   	   a ]Tekla.Structures.Dialog, Version=2020.0.0.0, Culture=neutral, PublicKeyToken=2f04dbe497b71114xQclr-namespace:Tekla.Structures.Dialog.UIControls;assembly=Tekla.Structures.Dialog"Tekla.Structures.Dialog.UIControls 5   	   bFclr-namespace:Tekla.Structures.Dialog;assembly=Tekla.Structures.DialogTekla.Structures.Dialog 5	   	   "    WPFPluginTemplate.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPFPluginTemplate     5   	   h
UIControlsQclr-namespace:Tekla.Structures.Dialog.UIControls;assembly=Tekla.Structures.Dialog     5   	   VtsdFclr-namespace:Tekla.Structures.Dialog;assembly=Tekla.Structures.Dialog     5	   	   $	��376��5   -   $	��376��6:   $	��800��6J     � 
ResizeMode$  NoResize=�6Y    � Title 6	   *  $Tekla.Structures.Dialog.LocExtension  *albl_Title_Plugin+.��5      � $	��760��6   $	��1,0q�6    � RowDefinitions 5   
   �� 5      $��70 �6   $��70��6(   69   �� 5      6   �� 5      $��70 �6   $��70��6(   69   .+�5   
   G  ATekla.Structures.Dialog.UIControls.WpfOkApplyModifyGetOnOffCancel  -   5        $��2��5   4   $��
10,0,10,10q�6A   $��Bottom=�6�  4  .Tekla.Structures.Dialog.UIControls.WpfSaveLoad  5   
   $��0��6!   $��51��6.   $��	10,10,0,0q�6:   $	��Top=�6M   $	��740��6e   $��2��6q   �� 5   
   $��1��6   $
��Left=�6   $��23��6:   $��
410,67,0,0q�6F    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6�   $	��120��6�   ��6n   �� *H1+6�   �� 5   
   -   5         ��Name$ zazor��5      $��1��6!   $
��Left=�6.   $��23��6I   $��410,105,0,0q�6U   $
 Wrap=�6j   $	��Top=�6�   $	��120��6�   ��6~   �� *H2+6�   �� 5   
   $��1��6   $
��Left=�6   $��23��6:   $��
410,28,0,0q�6F   $
 Wrap=�6Z   $	��Top=�6�   $	��120��6�   ��6n   �� *A1+6�   �� 5   
   $��Притупление h1��6   $
��Left=�6)   $��
273,64,0,0q�6D   $��1��6X   $	��Top=�6e   $	��110��6}   �� 5   
   $��Зазор h2��6   $
��Left=�6#   $��273,102,0,0q�6>   $��1��6S   $	��Top=�6`   $	��110��6x   �� 5   
   $��Угол a1��6   $
��Left=�6"   $��
273,25,0,0q�6=   $��1��6Q   $	��Top=�6^   $	��110��6v   :  4Tekla.Structures.Dialog.UIControls.WpfFilterCheckBox  5   
      AttributeName$ 
parametrh1��6'   $�� ��6B   $
��Left=�6M   $��
388,67,0,0q�6h   $��1��6|   $	��Top=�6�   $��23��6�   $��17��6�     5   
   $ 
parametrh2��6'   $�� ��6B   $
��Left=�6M   $��388,105,0,0q�6h   $��1��6}   $	��Top=�6�   $��23��6�   $��17��6�     5   
   $ anglea1��6'   $�� ��6?   $
��Left=�6J   $��
388,25,0,0q�6e   $��1��6y   $	��Top=�6�   $��23��6�   $��17��6�     5   
   $ list1��6'   $�� ��6=   $
��Left=�6H   $��	81,62,0,0q�6c   $��1��6v   $	��Top=�6�   $��23��6�   $��17��6�   �� 5    
   -   5         ��Name$ faska��5       $
��Left=�6"   $��
103,62,0,0q�6=   $��1��6n   $	��Top=�6{   $��90��6�   $��80��6�    �� SelectedIndex 6Q   �� *L1+.@�5!      ��  �� 
IsSelected . .��5"      �� .+�5#      �� $��85��6   $��80��6'   $
��Left=�63   $	��Top=�6N   $��MHP.png��6f   5$      5%      �� 5&       . .��5'      �� .+�5(      �� $��85��6   $��80��6'   $
��Left=�63   $	��Top=�6N   $��RKZ.png��6f   5)      5*      �� 5+       . .��5,      �� .+�5-      �� $��85��6   $��80��6'   $
��Left=�63   $	��Top=�6N   $��
RT0.01.png��6f   5.      5/      50      �� 51   
   $��1��6   $
��Left=�6   $��23��6:   $��410,145,0,0q�6F   $
 Wrap=�6[   $	��Top=�6�   $	��120��6�   ��6o   �� *S1+6�   �� 52   
   $9��3Увеличение
длинны разделки��6   $
��Left=�6>   $��273,142,0,0q�6Y   $��1��6n   $	��Top=�6{   $	��110��6�     53   
   $ 
parametrs1��6'   $�� ��6B   $
��Left=�6M   $��388,145,0,0q�6h   $��1��6}   $	��Top=�6�   $��23��6�   $��17��6�   54      55      