   M S B A M L   `   `   `  ����M  IUporabiskiVmesniki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:UporabiskiVmesnikiUporabiskiVmesniki  5   	   #    UporabiskiVmesniki.nastavitve   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:UporabiskiVmesniki     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
nastavitve��5	   	   $	��456��6   $	��800��6)   .��5
      � .+�5   
   �� $
��Left=�6   $	��419��60   $	��Top=�6=   $	��792��6U   $��0��6a   .@�5      �� $��DodajanjeFilmskihŽanrov��6   .��5      � ���	#FFE5E5E5$��0,0,0,-2q�6.    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��1* �6+   .+�5      � -   5         �Name$ wp��5       $��0��6,   $��Center=�69    � Orientation$ 
Horizontal=�6V   .+�5      �� $��2q�6    $��Dodajanje Žanra��64   $
��Left=�6N   $	��Top=�6i    J� RenderTransformOrigin$ -0.58,0&�6�   $	��322��6�   $��65��6�   �� 5      -   5         ��Name$ 	Dodajanje��5   =   $
��Left=�6"   $��23��6P    �� TextWrapping$
 Wrap=�6\   $��VpišiŽanrTukaj��6p   $	��Top=�6�   $	��185��6�   �� 5      -   5        $��
DodajŽanr��5   !   $��Right=�65   $��Bottom=�6Q   $��99��6l   $��23��6�   �� 5      $��2q�6    $#��Spreminjanje izbranega žanra��64   $
��Left=�6[   $	��Top=�6w   $��53��6�   $	��323��6�   �� 5      -   5        $ Spreminjanje��5   =   $
��Left=�6"   $��23��6S   $
 Wrap=�6`   $��SpremembaŽanra��6t   $	��Top=�6�   $	��185��6�   �� 5      -   5        $��SpremeniŽanr��5   !   $
��Left=�68   $	��Top=�6T   $��99��6l   $��23��6�   �� 5      $��2q�6    $��Brisanje izbranega žanra��64   $
��Left=�6W   $	��Top=�6s   $	��323��6�   $��50��6�   �� 5      -   5        $��OdstraniŽanr��5   !   $��Center=�68   $	��Top=�6V   $��75��6n   6y   5      �� 5      -   5        $��Žanre��5   <   $��Center=�6   $	��371��6I   $��Center=�6X   $	��271��6s   $��1��6   5      �� 5       $��1��6#   $
��Left=�63   
���iii�$	��373��6c   $��0,10,0,0q�6p   $	��Top=�6�   $��5��6�   5!      5"      �� 5#      $��AvtomatskoDodajanje��6   .��5$      � ���	#FFE5E5E5.+�5%      �� $��Shranjevanje��6   $
��Left=�63   $	��Top=�6N   $��	10,10,0,0q�6f   $��37��6y   $	��342��6�   �� 5&      -   5        $��Posodobi��5&      $
��Left=�62   $	��Top=�6M   $��191,180,0,0q�6e   6�   �� 5'      -	   5        $	��cas��5'   a   $
��Left=�6   $��76��69   $
 Wrap=�6E   $�� ��6Y   $	��Top=�6l   $	��342��6�   $��	10,47,0,0q�6�   �� 5(      $��Avtomatsko posodabljanje��6   $
��Left=�6?   $��
10,174,0,0q�6Z   $	��Top=�6n   $	��152��6�   5)      5*      5+      5-      5.      