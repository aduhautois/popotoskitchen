   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	       PopotosKitchenV2.EditOrder   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
Edit Order��5   	   $��333.564��6   $��661.569��6-   $��0q�6=   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��2��61   $��16(�6E   ���	#FF595959 �� Padding$ 10q�6j   �� 6x   $�Edit Order Information:��6|   6�   �� 5   
   -   5         ��Name$ lblEditOrder_OrderID��5   -   $��1��6   $��0��6   $��	Order ID:��6K   $��20q�6_   �� 5   
   -   5         ��Name$ txtEditOrder_OrderID��5   /   $��1��6   $��1��6   $��40��6M   $	��200��6Y    �� 
IsReadOnly . 6e   �� 5   
   -   5        $ lblEditOrder_Completed��5   -   $��1��6   $��2��6   $��
Completed:��6M   $��20q�6b   �� 5   
   -   5        	 ��Name$	 pnlEditOrder_Completed��5   2   $��1��6   $��3��6"   
 �� Orientation$
 
Horizontal=�6R   .+�5       	� -   5         	�Name$ radCompleted_Yes��5       $	��Yes��64   	� 5!      -   5        $ radCompleted_No��5!      $��No��63   $��40 0 0 0q�6@   5"      �� 5$   
   -   5        $ lblEditOrder_CustomerID��5$   -   $��2��6   $��0��6   $��Customer ID:��6N   $��20q�6e   �� 5%   
   -	   5        $ txtEditOrder_CustomerID��5%   /   $��2��6   $��1��6   $	��200��6P   $��40��6\   �� 5'   
   -
   5        $ lblEditOrder_Date��5'   -   $��3��6   $��0��6   $��Date:��6H   $��20q�6X   (  "System.Windows.Controls.DatePicker  5(   
   -   5          Name$ dateEditOrder_Date��5(   2   $��3��6   $��1��6"   $	��200��6N   $��40��6Z   �� 5)   
   -   5        $ lblEditOrder_Paid��5)   -   $��2��6   $��2��6   $��Paid:��6H   $��20q�6X   �� 5*   
   -   5        $!	 pnlEditOrder_PaidRadButtons��5*   2   $��2��6   $��3��6"   $��20��6W   $	��200��6c   $
 
Horizontal=�6o   .+�5+      	� -   5        $ radEditOrder_PaidYes��5+      $	��Yes��68   	� 5,      -   5        $ radEditOrder_PaidNo��5,      $��No��67   $��40 0 0 0q�6D   5-      �� 5/   
   -   5        $ lblEditOrder_Traded��5/   -   $��3��6   $��2��6   $��Traded:��6J   $��20q�6\   �� 50   
   -   5        $#	 pnlEditOrder_TradedRadButtons��50   2   $��3��6   $��3��6"   $��20��6Y   $	��200��6e   $
 
Horizontal=�6q   .+�51      	� -   5        $ radEditOrder_TradedYes��51      $	��Yes��6:   	� 52      -   5        $ radEditOrder_TradedNo��52      $��No��69   $��40 0 0 0q�6F   53      �� 55   
   -   5         ��Name$! btnEditOrder_ConfirmChanges��55   .   $��4��6   $��1��6   $��40��6S   $��Confirm changes��6_   $��0 20 0 0q�6y   6�   �� 56   
   -   5        $  btnEditOrder_CancelChanges��56   .   $��4��6   $��3��6   $��40��6R   $��Cancel��6^   $��0 20 0 0q�6o   6�   57      58      