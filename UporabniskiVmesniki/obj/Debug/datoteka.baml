   M S B A M L   `   `   `  ����M  IUporabiskiVmesniki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:UporabiskiVmesnikiUporabiskiVmesniki  5   	   !    UporabiskiVmesniki.datoteka   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:UporabiskiVmesniki     5   	     � Title$  datoteka��5   	   $��207.787��6   $��281.148��6+   ��5	      �� 5
   
   -   5        ozad�� �� Color$ White��5
   (    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      �� 	 �� To$ YellowX�6%    g� Duration$ 0:00:04D�61    g� AutoReverse .  g� RepeatBehavior$ Forever��6W    �� 
TargetName$
 ozad��6p   	 �� TargetProperty$	 Color�6�   5      5      5      .��5      � .+�5   
   �� $��Naslov filma��6      labelDva#��[  6'   $
��Left=�6I   $��	10,10,0,0q�6d   $	��Top=�6w   $��24��6�   $��93��6�   �� 5   
   -   5        $��naslov��5      $�� ��6   #��[  6)   $
��Left=�6K   $��	108,8,0,0q�6f   $	��Top=�6y   $	��142��6�   �� 5   
   -   5        $��aa��5   +   $
��Left=�6   $	��100��65   $��	10,60,0,0q�6B   $	��Top=�6U   $	��100��6m   �� 5   
   -   5        $��ocena��5      $�� ��6   #��[  6(   $
��Left=�6J   $��
124,60,0,0q�6e   $	��Top=�6y   $��32��6�   $	��139��6�   �� 5   
   -   5        $��igral��5      $�� ��6   #��[  6(   $
��Left=�6J   $��
124,92,0,0q�6e   $	��Top=�6y   $	��139��6�   $��32��6�   �� 5   
   -   5        $	��dir��5      $�� ��6   #��[  6&   $
��Left=�6H   $��124,129,0,0q�6c   $	��Top=�6x   $	��139��6�   $��31��6�   �� 5   
   -   5        $��opacityAnimatedButton��5      $��124,60,5,17q�6.   .��6C   Pokazi o filmu 5      :� 5      $ Button.Click��6   .[�5       �� .��5!      �� .��5"      W� $ opacityAnimatedButton��5#      $	 (Button.Opacity)�5$      
 W� From$
 1X�5%      	 W� To$ 0X�6   $ 0:0:5D�6!    . 62   5&      5'      5(      5*      5.      5/      