   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	   #   PopotosKitchenV2.EditCustomer   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
Edit Order��5   	   $��512.612��6   $��726.78��6-   $��0q�6<   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��2��61   $��16(�6E   ���	#FF595959 �� Padding$ 10q�6j   �� 6x   $ �Edit Customer Information:��6|   6�   �� 5    
   -   5         ��Name$  lblEditCustomer_CustomerID��5    -   $��1��6   $��0��6   $��Customer ID:��6Q   $��20q�6h   �� 5!   
   -   5        $% lblEditCustomer_CustomerIDField��5!   -   $��1��6   $��1��6   $	��200��6V   $��40��6b   �� 5#   
   -   5        $ lblEditCustomer_FirstName��5#   -   $��2��6   $��0��6   $��First Name:��6P   $��20q�6f   �� 5$   
   -   5         ��Name$ txtEditCustomer_FirstName��5$   /   $��2��6   $��1��6   $	��200��6R   $��40��6^   �� 5%   
   -   5        $ lblEditCustomer_LastName��5%   -   $��2��6   $��2��6   $��
Last Name:��6O   $��20q�6d   �� 5&   
   -   5        $ txtEditCustomer_LastName��5&   /   $��2��6   $��3��6   $��40��6Q   $	��200��6]   �� 5(   
   -   5        $  lblEditCustomer_LocalPhone��5(   -   $��3��6   $��0��6   $��Local Phone:��6Q   $��20q�6h   �� 5)   
   -	   5        $  txtEditCustomer_LocalPhone��5)   /   $��3��6   $��1��6   $��40��6S   $	��200��6_   �� 5+   
   -
   5        $" lblEditCustomer_EmailAddress��5+   -   $��4��6   $��0��6   $��20q�6S   $��Email Address:��6`   �� 5,   
   -   5        $" txtEditCustomer_EmailAddress��5,   /   $��4��6   $��1��6   $��40��6U   $	��200��6a   �� 5.   
   -   5        $! lblEditCustomer_FreeCompany��5.   -   $��5��6   $��0��6   $��20q�6R   $��Free Company:��6_   �� 5/   
   -   5        $! txtEditCustomer_FreeCompany��5/   /   $��5��6   $��1��6   $	��200��6T   $��40��6`   �� 51   
   -   5         ��Name$$ btnEditCustomer_ConfirmChanges��51   .   $��6��6   $��1��6   $��40��6V   $��Confirm changes��6b   $��0 30 0 0q�6|   6�   �� 52   
   -   5        $# btnEditCustomer_CancelChanges��52   .   $��6��6   $��3��6   $��40��6U   $��Cancel��6a   $��0 30 0 0q�6r   6�   53      54      