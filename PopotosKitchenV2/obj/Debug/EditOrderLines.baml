   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	   %   PopotosKitchenV2.EditOrderLines   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Edit Order Items��5   	   $	��521��6"   $	��730��6/   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��2��61   $��16(�6E   ���	#FF595959 �� Padding$ 10q�6j   �� 6x   $�Edit Order Items:��6|   6�   �� 5   
   -   5         ��Name$ lblEditOrderLines_Recipes��5   -   $��2��6   $��0��6   $��Recipes:��6P   $��20q�6c   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$&  gridEditOrderLines_OrderLineList��5   0   $��2��6   $��1��6       SelectionMode$ Single=�6Z   	   SelectionUnit$	 FullRow=�6q   
   
IsReadOnly
 . $	��450��6�   $	��100��6�   $��0,1,1,0q�6�   $��1q�6�   � 5   
   $��2��6   $��2��6    5       �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    .+�5%      �� -   5         ��Name$  btnEditOrderLines_EditLine��5%   "   $��0��6   $��	Edit Line��6F   $��40��6Z   $	��100��6f   $��	10 0 10 0q�6r   6�   �� 5&      -   5        $" btnEditOrderLines_DeleteLine��5&   "   $��1��6   $��Delete Line��6H   $��40��6^   $	��100��6j   $��
10 20 10 0q�6v   6�   5'      �� 5)   
   -   5        $! btnEditOrderLines_AddRecipe��5)   .   $��3��6   $��1��6   $��Add New Recipe��6S   $	��275��6l   $��40��6x   $��88,22,88,20q�6�   6�   �� 5+   
   -   5        $&  lblEditOrderLines_DeletedRecipes��5+   -   $��4��6   $��0��6   $��Deleted Recipes:��6W   $��20q�6r     5,   
   -   5        $% gridEditOrderLines_DeletedLines��5,   0   $��4��6   $��1��6    $	��450��6Y   $	��100��6e   
 . $ Single=�6�   $	 FullRow=�6�   $��1q�6�   �� 5.   
   -   5        $$ btnEditOrderLines_UndeleteLine��5.   .   $��4��6   $��2��6   $��Re-add Line��6V   $��40��6l   $	��100��6x   $��0 60 0 0q�6�   6�   �� 50   
   -	   5        $&  btnEditOrderLines_ConfirmChanges��50   .   $��5��6   $��1��6   $��40��6X   $	��275��6d   $��OK��6p   $��0 20 0 0q�6}   6�   �� 51   
   -
   5        $% btnEditOrderLines_CancelChanges��51   .   $��6��6   $��1��6   $��40��6W   $	��275��6c   $��Cancel��6o   $��0 20 0 0q�6�   6�   52      53      