   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.1.2.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   K GPopotosKitchenV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PopotosKitchenV2PopotosKitchenV2 5   	   (   "PopotosKitchenV2.RecipeInformation   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PopotosKitchenV2     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ RecipeInformation��5   	   $	��378��6#   $	��577��60   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6!   $��2��61   $��16(�6E   ���	#FF595959 �� Padding$ 10q�6j   �� 6x   $�Edit:��6|   6�   �� 5   
   -   5         ��Name$  lblRecipeInfo_ChooseRecipe��5   -   $��1��6   $��0��6   $��Choose recipe:��6Q   $��20q�6j   �� 5   
   -   5         ��Name$  cmbRecipeInfo_ChooseRecipe��5   0   $��1��6   $��1��6    $	��200��6T   $��40��6`   6�   �� 5    
   -   5        $ lblRecipeInfo_Price��5    -   $��2��6   $��0��6   $��Price:��6J   $��20q�6[   �� 5!   
   -   5         ��Name$ txtRecipeInfo_Price��5!   /   $��2��6   $��1��6   $��40��6L   $	��200��6X   �� 5#   
   -   5        $ lblRecipeInfo_Quantity��5#   -   $��3��6   $��0��6   $��	Quantity:��6M   $��20q�6a   �� 5$   
   -   5        $ txtRecipeInfo_Quantity��5$   /   $��3��6   $��1��6   $��40��6O   $	��200��6[   �� 5&   
   -   5        $ lblRecipeInfo_Completed��5&   -   $��4��6   $��0��6   $��
Completed:��6N   $��20q�6c   �� 5'   
   -   5        	 ��Name$	 pnlComplete��5'      
 �� Orientation$
 
Horizontal=�6*   $��4��6C   $��1��6P   {�.  .+�5(      	� -	   5         	�Name$ radCompleted_Yes��5(   (   $	��Yes��6   $��	20 0 20 0q�6B   	� 5)      -
   5        $ radCompleted_No��5)   '   $��No��6   $��	20 0 20 0q�6@   5*      �� 5,   
   -   5         ��Name$ btnRecipeInfo_Confirm��5,   .   $��5��6   $��1��6   $��40��6M   $��75��6Y   $��OK��6d   $��1,10,126,-6q�6q   6�   �� 5-   
   -   5        $ btnRecipeInfo_Cancel��5-   .   $��5��6   $��1��6   $��40��6L   $��75��6X   $��Cancel��6c   $��93,10,36,-5q�6t   6�   �� 50   
   -   5         ��Name$ 
imgRecipes��50      $$��Resources/Apkallu Omelette.png��6$   $��1��6M   $��3��6Z   $��4��6l   $	��175��6|   $	��175��6�   $��35 0 0 0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   52      53      