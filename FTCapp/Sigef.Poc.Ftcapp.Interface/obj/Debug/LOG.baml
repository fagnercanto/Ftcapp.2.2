   M S B A M L   `   `   `  ����  Sigef.Poc.Ftcapp.Interface$    Sigef.Poc.Ftcapp.Interface.LOG   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5
      �� .+�5   
   ��    NormalButton#���   6   �� 5   
     	AddButton#���  6   �� 5   
     	DelButton#���  6   �� 5   
   $	��0,2q�5        AccentBaseColorBrush#��[ 5      $��Bottom=�5      ._�5      �� $��Center=�5      $
��Bold"�5        IdealForegroundColorBrush#��[ 5      $	��LOG��5      5      �� 5   
   -   5          ��Name$  ListBoxCasos��5      ��5      ��   MVBaseViewModel �� Source# [  �� Path$ VM.SelectedCaso.Comandos� �� Mode$ TwoWay=� �� SelectedItem 5      �� # [ $% VM.SelectedCaso.SelectedComando�$ TwoWay=���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 0q�60   �� 5       � ��$ 2q�6/   5       ��5"      �� 5#      .R�5%      �� $��3q�6K   ��6   �� $	 Cor�$ TwoWay=�._�5&      � $	��0,0q�6    � RowDefinitions 5'      �� 5)   "   $��* �60   	 � ColumnDefinitions	 5,      �� 5-   "   �� 5.   "   $��25 �63   .+�50      �� $��stnome��51   !   $��0��52   !   $��Center=�53   !   
 �� Orientation$
 
Horizontal=�54   !   .+�55   "   �� $	��2,0q�6,   ��69   �� $ Id�$ TwoWay=��� 56   "   $	��2,0q�6,   ��69   �� $ Elemento.Nome�$ TwoWay=��� 57   "   $	��2,0q�6,   ��69   �� $ TipoControle�$ TwoWay=�58      �� 5:      $��2��5;   !   $��Center=�5<   !   $
 
Horizontal=�5=   !   .+�5?   "   �� #��[ 5B   %   ��5@   %   �� # [ $ ADD_CASO���5A   %   �� 5B   %   5D      5F      5G      5M      ��5O      �� 5Q      .R�5S      � $
��wrap��5T      $��Center=�5U       � Orientation$ Vertical=�5V      5X      5\      5]      5^      