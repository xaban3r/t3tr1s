   M S B A M L   `   `   `  ����A  =t3tr1s, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:t3tr1st3tr1s  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5   	       t3tr1s.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:t3tr1s     5   	   Efa6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	   -   5          � Title$  TETRIS��5	   	   $	��720��6   $	��800��6%    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5       �� 
TargetType   RoundButton �� 	Resources �� Property �� Value  RightSideButton��%J  &	        &	 �     �� 5   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$	 360��65   5      5      5      �� 5   
   " ��6    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 5��65   5      5      5      5       ��5!      �� 5#   
    �� ImageSource$ spaceBackground rv.jpg��6   .��5'      �  5(   
   ��%    5)       � ColumnDefinitions 5*   
   �� 5+      $��0,200* �6    �� 5,      $��0,350* �6   �� 5-      $��0,200* �6   .+�50   
   ]� $��1��6   $��Stretch=�6$   $��Stretch=�6@   
�������	 J� Opacity$
	 0.75Q�6p   .+�51      �� $��0,2,2,2q�6   $	��Top=�6*   
 �� Orientation$
 
Horizontal=�6?   52      ]� 53      $��Bottom=�6   $��Stretch=�60   $��Stretch=�6N   .+�54      � -   5        $��mainGrid��54   g   $	��Top=�6   $��Stretch=�6-   $��Stretch=�6I    � ShowGridLines .  
���   �56      57      58      � 59   
   $��0��6   $��2q�6    � RowDefinitions 5:      �� 5;      $��0,100* �6    �� 5<      $��0,100* �6    �� 5=      $��0,50* �6    �� 5>      $��0,400* �6    �� 5?      $��0,125* �6    .+�5A      �� $��0��6   $��Score��6%   
�������$��MS UI Gothic)�6E   $��Center=�6_   $��20(�6|   �� 5B      -   5         ��Name$ score��5B   8   $��0��6   
�������$��MS UI Gothic)�6G   $��30(�6a   $��Center=�6o   $��Center=�6�   �� 5C      $��1��6   
�������$��Level��68   $��MS UI Gothic)�6E   $��Center=�6_   $��20(�6|   �� 5D      -   5        $ level��5D   8   $��1��6   
�������$��MS UI Gothic)�6G   $��30(�6a   $��Center=�6o   $��Center=�6�   �� 5E      $��2��6   
�������$��MS UI Gothic)�68   $��
Last Games��6R   $��Center=�6d   $��20(�6�   �� 5F      -   5        $ results��5F   8   $��3��6   
�������$	��180��6I   $��	10,0,10,0q�6U   $��12(�6h   $��Center=�6v   $	��Top=�6�   $��MS UI Gothic)�6�   $
��Bold"�6�   �� 5H      $��4��6   .+�5I      �� $
 
Horizontal=�6   $��5��66   $��Center=�6C   .+�5J      �� -   5         ��Name$ vkButton��5J      #���   6/   
������ 
������ $��0q�6�   $��50��6�   $��50��6�   $��0,0,10,0q�6�   .��5K      "  FontAwesome.WPF.ImageAwesome     Icon$ Vk=�6*   $��45��65   $��45��6@      
Foreground
 ��  �$��0,0,0,0q�6_   5M      �� 5O      -   5        $ gitHubButton��5O      #���   63   
������ 
������ $��0q�6�   $��50��6�   $��50��6�   $��0,0,0,0q�6�   .��5P        $ Github=�6&   $��45��66   $��45��6A   
 �����$��0,0,0,0q�6`   5Q      5S      �� 5T      $
 Vertical=�6   $��5��64   $��Center=�6A   .+�5U      �� -   5        $ tgButton��5U      #���   6/   
������ 
������ $��0q�6�   $��50��6�   $��50��6�   .��5V        $ Telegram=�6*   $��45��6:   $��45��6E   
 ��  �$��0,0,0,0q�6d   5W      5X      5Y      5Z      � 5[   
   -	   5         �Name$ nextGrid��5[   *   $��2��6   $��2q�6    5\      �� 5]      $��0,675* �6    �� 5^      $��0,125* �6    �� 5_      $��0,125* �6    .+�5b      �� .+�5c      �� $
��NEXT��6   
�������$��MS UI Gothic)�6<   $��20(�6W   $��Center=�6e   � 5d      -
   5        $ gridNext��5d   �   $	��150��6   $	��150��6#   $��Stretch=�60   $��Stretch=�6L    .  
���   �$
	 0.75Q�6�    5e      �� 5f      �� 5g      �� 5h      �� 5i       5k      �� 5l      �� 5m      �� 5n      �� 5o      5q      �� 5t      $��Timer��6   $��MS UI Gothic)�6*   $��25(�6D   
�������$��Center=�6e   6�   �� 5u      -   5        $ timer��5u      
�������$��MS UI Gothic)�6@   $��Center=�6Z   $��25(�6w   $��Center=�6�   5x      �� 5|      -   5        $��buttonPause��5|   Q   #���  6   |�.  $��MS UI Gothic)�6d   $��20(�6~   $��Pause��6�   $��2��6�   6�   �� 5~      -   5        $��buttonStartGame��5~   L   #���  6   $��1��6?   $��MS UI Gothic)�6c   $
��Bold"�6�   $��20(�6�   |�.  $��Start the Game��6�   6�   5�      5�      5�      