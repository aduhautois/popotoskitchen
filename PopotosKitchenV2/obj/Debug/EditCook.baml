   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	      PopotosKitchenV2.EditCook   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ EditCook��5   	   $��276.398��6   $��666.63��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��2��61   $��16(�6E   ���	#FF595959 �� Padding$ 10q�6j   �� 6x   $�Edit Cook Information:��6|   6�   �� 5   
   -   5         ��Name$ lblEditCook_FirstName��5   -   $��1��6   $��0��6   $��First Name:��6L   $��20q�6b   �� 5   
   -   5         ��Name$ txtEditCook_FirstName��5   /   $��1��6   $��1��6   $��40��6N   $	��200��6Z   �� 5   
   -   5        $ lblEditCook_LastName��5   -   $��1��6   $��2��6   $��
Last Name:��6K   $��20q�6`   �� 5   
   -   5        $ txtEditCook_LastName��5   /   $��1��6   $��3��6   $��40��6M   $	��200��6Y   �� 5   
   -   5        $ lblEditCook_LocalPhone��5   -   $��2��6   $��0��6   $��Local Phone:��6M   $��20q�6d   �� 5    
   -   5        $ txtEditCook_LocalPhone��5    /   $��2��6   $��1��6   $��40��6O   $	��200��6[   �� 5!   
   -   5        $ lblEditCook_EmailAddress��5!   -   $��2��6   $��2��6   $��Email Address:��6O   $��20q�6h   �� 5"   
   -   5        $ txtEditCook_EmailAddress��5"   /   $��2��6   $��3��6   $��40��6Q   $	��200��6]   �� 5$   
   -	   5         ��Name$ btnEditCook_Confirm��5$   .   $��3��6   $��1��6   $��40��6K   $	��125��6W   $��Save Changes��6c   $��	30 20 0 0q�6z   6�   �� 5%   
   -
   5        $ btnEditCook_Cancel��5%   B   $��3��6   $��2��6   $��2��6.   $��40��6^   $	��125��6j   $��Cancel��6v   $��
-80 20 0 0q�6�   6�   5&      5'      