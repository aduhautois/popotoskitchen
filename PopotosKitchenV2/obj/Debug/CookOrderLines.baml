   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	   %   PopotosKitchenV2.CookOrderLines   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ 
Cook Items��5   	   $	��304��6   $	��783��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
lblRecipes��5   -   $��0��6   $��0��6   $��Recipes:��6A   $��20q�6T   $��0 20 0 0q�6a   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ gridRecipes��5   0   $��0��6   $��1��6    $��1q�6E   $	��450��6Y   $	��100��6e      SelectionUnit$ FullRow=�6r      SelectionMode$ Single=�6�   	   
IsReadOnly	 . $��0 20 0 0q�6�   6�   �� 5   
   -   5        
 ��Name$
 btnCompleteRecipe��5   .   $��1��6   $��1��6   $	��275��6I   $��40��6U   $��Complete Recipe��6a   $��88,23,88,18q�6{   6�   �� 5   
   -   5        $
 btnDone��5   .   $��2��6   $��1��6   $	��275��6?   $��40��6K   $
��Done��6W   6f   �� 5   
   -   5        $
 
btnRefresh��5      $��Refresh��6%   $
��Left=�67   $	��Top=�6R   $��75��6j    J� RenderTransformOrigin$ 
2.507,5.68&�6u   $��1��6�   $��
377,23,0,0q�6�   $��1��6�   $��40��6�   6�   �� 5   
   -   5         ��Name$ 
imgRecipes��5      $��0��6%   $��2��62   $��2��6D   $	��165��6T   $	��175��6a   $��
31,23,1,19q�6m   $ 0.5,0.5&�6�   5!      5"      