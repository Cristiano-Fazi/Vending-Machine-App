   M S B A M L   `   `   `  ����F  BPIIIProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PIIIProjectPIIIProject  5   	       PIIIProject.CashWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PIIIProject     5   	     � Title$  
CashWindow��5   	   $	��450��6   $	��300��6)    � 
ResizeMode$ NoResize=�65   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��2* �6   .+�5#   
   �� $��0��6   $��0��6!   $��2��61    �� TextAlignment$ Center=�6E   $��5q�5$      0.Please Select the Bill You Will be Paying With5&      �� 5)   
   $��0��6   $��1��6    $��5q�6-   $��/Images/5$_Bill.jpg��68   5+      �� 5.   
   $��0��6   $��2��6    $��5q�6-   $��/Images/10$_Bill.jpg��68   50      �� 53   
   $��0��6   $��3��6    $��5q�6-   $��/Images/20$_Bill.jpg��68   55      �� 58   
   $��0��6   $��4��6    $��5q�6-   $��/Images/50$_Bill.jpg��68   5:      �� 5=   
   $��0��6   $��5��6    $��5q�6-   $��/Images/100$_Bill.jpg��68   5?      �� 5C   
   -   5         ��Name$ rdCash��5C      $��1��6%   $��1��62   $��5��6B   .+�5D      	� $��
0,20,20,20q�6   .��6/   	5$ Bill68   	� 5F      $��
0,20,20,20q�6   .��6.   
10$ Bill68   	� 5H      $��
0,20,20,20q�6   .��6.   
20$ Bill68   	� 5J      $��
0,20,20,20q�6   .��6.   
50$ Bill68   	� 5L      $��
0,20,20,20q�6   .��6.   	100$ Bill69   5M      �� 5R   
   -   5        $��0��5R      $��6��6!   $��2��6.   $��20q�6B   $��20(�6N   $��Medium"�5S      $	��2.5q�6%    � 	Resources 5T       �� 
TargetType �� Property	 �� Value��%_   '��       �� 5U      " ��6   .�5V      ��  �@��CornerRadius$	 10��65   5W      5X      ��5Y      �� 5Z      
 �� 
StartPoint$	
 0,0&�6&    �� EndPoint$	 1,1&�67   .��5[      �  � Color$ DarkGoldenrod��6#    � Offset$ 0Q�69   � 5\      $	 red��6#   $
 0.25Q�6/   � 5]      $ Green��6#   $	 0.5Q�61   � 5^      $ Purple��6#   $
 0.75Q�62   � 5_      $ 	CadetBlue��6#   $	 1.0Q�65   5`      .��5a   "   Confirm Payment5c      5e      5f      