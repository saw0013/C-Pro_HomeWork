   M S B A M L   `   `   `  ����A  =Unit16, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Unit16Unit16  5   	       Unit16.AddClientData   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Unit16     5   	     � Title$6  0Добавление записи (клиент)��5   	   $	��250��6,   $	��400��69   $	��399��5	   	   $	��400��6   $	��249��5
   	   $	��251��6   .��5      � $	��184��6   $��Center=�6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��Фамилия��6   $��0,15,200,145q�5      $	��190��5       J� RenderTransformOrigin$ 0.5,0.5&�5      $��Center=�6-   �� 5   
   $��Имя��6   $��0,44,200,116q�5      $	��190��5      $ 0.5,0.5&�5      $��Center=�6-   �� 5   
   $��Отчество��6   $��0,73,200,87q�5      $	��190��5      $ 0.5,0.5&�5      $��Center=�6-   �� 5    
   $!��Номер телефона��6   $��0,102,200,58q�5!      $	��190��5"      $ 0.5,0.5&�5#      $��Center=�6-   �� 5%   
   $��Email потча��6   $��0,131,200,29q�5&      $	��190��5'      $ 0.5,0.5&�5(      $��Center=�6-   �� 5*   
   -   5         ��Name$ lastName��5+      $��200,21,10,0q�5,       �� TextWrapping$
 Wrap=�5-      $	��Top=�6!   69   �� 5/   
   -   5        $
 name��50      $��200,47,10,0q�51      $
 Wrap=�52      $	��Top=�53      54      �� 56   
   -   5        $ 
middleName��57      $��200,76,10,0q�58      $
 Wrap=�59      $	��Top=�5:      5;      �� 5=   
   -   5        $ numberPhone��5>      $��200,105,10,0q�5?      $
 Wrap=�5@      $	��Top=�5A      �� 5C   
   -   5        $ Email��5D      $��200,134,10,0q�5E      $
 Wrap=�5F      $	��Top=�5G      5H      �� 5J   
   -   5         ��Name$ 	AddButton��5K      $��Добавить��5L      {�.  $��Right=�5N      $��0,173,205,-13q�5O      $	��185��6$   �� 5P   
   -   5        $ CancelButton��5Q      $��Отмена��5R      $
��Left=�5S      $	��185��6(   $��205,0,0,-13q�64   $��24��6I   $��Bottom=�6U   5U      5V      