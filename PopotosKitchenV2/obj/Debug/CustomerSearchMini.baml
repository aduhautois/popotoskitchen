   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	   )   #PopotosKitchenV2.CustomerSearchMini   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Customer Search��5   	   $	��450��6!   $	��810��6.   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   $�� ��6-   $��5q�69   �� 5   
   -   5         ��Name$, &lblCustomerSearchWindow_SearchCriteria��5   -   $��1��6   $��0��6   $��Search:��6]   $��50 20 20 20q�6o   �� 5   
   -   5         ��Name$, &txtCustomerSearchWindow_SearchCriteria��5      $��1��6   $��0q�6O   $��40��6[   $	��310��6g   $��2��6s   $��
189,9,5,10q�6�   �� 5   
   -   5        $. (lblCustomerCustomerSearchWindow_SearchBy��5   -   $��2��6   $��0��6   $��
Search by:��6_   $��	50 20 0 0q�6t   � 5   
   $��2��6   $��1��6    5       �� 5!      $
��Auto �6#   �� 5"      $
��Auto �6#   .+�5$      �� -   5        $'��!cmbxCustomerSearchWindow_SearchBy��5$      $��0��6@   $	��175��6P   $��40��6\   .@�5%      �� -   5         ��Name$% cmbxitmCustomerSearchWindow_All��5%      $	��All��6H    �� 
IsSelected . 6V   �� 5&      -   5        $, &cmbxitmCustomerSearchWindow_CustomerID��5&      $��Customer ID��6O   �� 5'      -   5        $&  cmbxitmCustomerSearchWindow_Name��5'      $
��Name��6I   �� 5(      -   5        $- 'cmbxitmCustomerSearchWindow_FreeCompany��5(      $��Free Company��6P   5)      5*      �� 5+   
   -	   5        	 ��Name$,	 &btnCustmerSearchWindow_SearchCustomers��5+      $��1��6A   $��4��6N   $��40��6^   $��Search!��6j   $	��200��6|   $��	50,0,50,0q�6�   6�   �� 5-   
   -
   5        $.	 (btnCustomerSearchWindow_ViewAllCustomers��5-      $��2��6C   $��4��6P   $��40��6`   $��View All��6l   $��	50,8,50,0q�6   6�   &   System.Windows.Controls.DataGrid  5/   
   -   5        $4��.gridCustomerSearchWindow_CustomerSearchResults��5/   W   $��3��6   $��0��6    $��5��60   
   
IsReadOnly
 . $��50,30,50,30q�6�   $	��150��6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   $��1q�6�   ���	#7FFFFFFF6	  �� 51   
   -   5        $,	 &btnCustomerSearchWindow_SelectCustomer��51   .   $��4��6   $��0��6   $��Select Customer��6^   $
��Left=�6x   $��40��6�   $��50,0,0,0q�6�   $	��141��6�   6�   �� 52   
   -   5        $$	 btnCustomerSearchWindow_Cancel��52   .   $��4��6   $��1��6   $��Cancel��6V   $
��Left=�6g   $��	30,0,30,0q�6�   $��40��6�   $	��141��6�   6�   53      54      