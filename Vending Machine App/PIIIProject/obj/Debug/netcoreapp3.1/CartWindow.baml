   M S B A M L   `   `   `  ����F  BPIIIProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PIIIProjectPIIIProject  5   	       PIIIProject.CartWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PIIIProject     5   	     � Title$  
CartWindow��5   	   $	��450��6   $	��800��6)    � 
ResizeMode$ NoResize=�65   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   �� $��
10,10,10,0q�6    �� CornerRadius$ 10��6%   $��3q�67   
���   ���5      �� 5        �� EndPoint$ 0.5,0.9&�6&    �� 
StartPoint$ 0.5,0&�69   .��5!      �  � Color$ White��6#    � Offset$	 0.9Q�61   � 5"      $	 Red��6#   5#      ._�5%      �� $��30(�6   $��	Pescadero)�6&   $��Medium"�6=   $��Italic$�6Q   	 �� TextAlignment$	 Center=�5&      $��Center=�6+   ��5'      �� 5(      
 �� 
TargetType"
 ��6   .�5)      ��  �� Property �@J�Effect �� Value 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+   "      ShadowDepth$ 5Q�63      Color$	 Red��5,   '      Opacity$ 50Q�5-   '      
BlurRadius$ 12Q�5.   '   50      51      Previous Purchases54      55      �� 58   
   $��
10,10,10,0q�6   $��0��6%   $��1��62   $ 10��6B   $��3q�6T   
���   ���59      �� 5:      $ 0.5,0.9&�6&   $ 0.5,0&�69   .��5;      � $ White��6#   $	 0.9Q�61   � 5<      $ ForestGreen��6#   5=      ._�5?      �� $��30(�6   $��	Pescadero)�6&   $��Medium"�6=   $��Italic$�6Q   $	 Center=�5@      $��Center=�6+   ��5A      �� 5B      "
 ��6   .�5C      ��  �@J�Effect 5D        5E   "   $ 5Q�63   $ ForestGreen��5F   '   $ 50Q�5G   '   $ 12Q�5H   '   5J      5K      Shopping Cart5N      5O      �� 5R   
   $��10q�6   $��1��6#   $��0��60   .��5S      �� -   5         ��Name$ txtPreviousPurchases��5S      5U      5V      �� 5[   
   -   5         ��Name$ lvCurrentCart��5[      $��10q�6*   $��1��66   $��1��6C   
���   �$��2q�6g    �� View 5\      �� 5]      -   5        shoppingCartList��.P�5^      �� $
��Name��6%    �� Width$	 200��63    �� DisplayMemberBinding 6?   �� *ProductName+�� 5_      $��Price��6%   $	 165��64    6@   �� *Price+5`      5b      �� 5f   
   $��2��6   $��0��6   $��10q�6.   $ 10��6:   $��3q�6L   
���   ���5g      �� 5h      $ 0.5,0.9&�6&   $ 0.5,0.2&�69   .��5i      � $	 Red��6#   $	 0.9Q�6/   � 5j      $ White��6#   5k      ._�5m      �� -   5        $��2��5m      $��0��6"   $��20(�5n      $��	Pescadero)�6#   $��Medium"�6:   $��Italic$�6N   
������ .��5o   F   Return To Vending Machine5q      5r      �� 5u   
   $��2��6   $��1��6   $��10q�6.   $ 10��6:   $��3q�6L   
���   ���5v      �� 5w      $ 0.5,0.9&�6&   $ 0.5,0.2&�69   .��5x      � $ ForestGreen��6#   $	 0.9Q�67   � 5y      $ White��6#   5z      ._�5}      �� -   5        $��2��5}      $��0��6"   $��20(�5~      $��	Pescadero)�6#   $��Medium"�6:   $��Italic$�6N   
������ .��5   J    Remove Item From Shopping Cart5�      5�      5�      5�      