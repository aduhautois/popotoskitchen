   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	   "   PopotosKitchenV2.SendMessage   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Message��5
   	   $��470.956��6   $��479.485��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ lblMessageSubject��5   -   $��0��6   $��0��6   $��Subject:��6H   $��20q�6[   �� 5   
   -   5         ��Name$ txtMessageSubject��5   /   $��0��6   $��1��6   $��40��6J   $	��300��6V   �� 5   
   -   5        $ lblMessageText��5   -   $��1��6   $��0��6   $��Message:��6E   $��20q�6X   �� 5   
   -   5        $ txtMessageText��5   /   $��1��6   $��1��6   $	��300��6G   $	��300��6T    �� TextWrapping$
 Wrap=�6`    �� AcceptsReturn . 6t   �� 5   
   -   5         ��Name$ btnSendMessage��5   B   $��2��6   $��0��6   $��2��6.   $��OK��6Z   $��40��6g   $	��141��6s   $��Center=�6   $��	80 20 0 0q�6�   6�   5      5      