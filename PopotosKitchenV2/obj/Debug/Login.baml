   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	      PopotosKitchenV2.Login   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ Login��5   	   $��251.059��6   $��340.678��6(   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��2��61    �� Padding$ 	20 15 0 0q�6E   $��16(�6Y   ���	#FF6A6A6A�� 6   $�Please log in:��6�   6�   �� 5   
   -   5         ��Name$ lblLoginUsername��5   -   $��1��6   $��0��6   $��	Username:��6G   $��	30 5 20 5q�6[   �� 5   
   -   5         ��Name$ txtLoginUsername��5   /   $��1��6   $��1��6   $��	0 0 30 10q�6I   �� 5   
   -   5        $ lblLoginPassword��5   -   $��2��6   $��0��6   $��	Password:��6G   $��	30 5 20 5q�6[   G� 5   
   -   5         G�Name$ txtLoginPassword��5   3   $��2��6   $��1��6#   $��	0 0 30 10q�6M   �� 5   
   -   5        $ lblLoginConfirmPassword��5   -   $��3��6   $��0��6   $��Confirm Password:��6N   $��	30 5 20 5q�6j   G� 5   
   -   5        $ txtLoginConfirmPassword��5   3   $��3��6   $��1��6#   $��	0 0 30 10q�6T   �� 5   
   -   5        	 ��Name$	 
chkNewUser��5   D   $��4��6   $��0��6    $��2��60   $��  New user?��6X   $��	2 10 0 10q�6n   $��30 0 0 0q�6�   6�   � 5    
   $��4��6   $��1��6    5!      �� 5"      $
��Auto �6#   �� 5#      $
��Auto �6#   .+�5%      �� -	   5        
 ��Name$
 btnLoginCancel��5%   %   $��0��6   $��Cancel��6=   $��74��6N   6Y   �� 5&      -
   5        $
 btnLoginYes��5&   %   $��1��6   $��Login��6:   $��74��6J   $��6 0 0 0q�6U   6f   5'      5(      5)      