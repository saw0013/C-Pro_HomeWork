   M S B A M L   `   `   `  ����A  =Unit17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Unit17Unit17  5   	       Unit17.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Unit17     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��311* �6   �� 5      $	��89* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
gridClient��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         SelectionMode$ Single=�5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .  $��10,34,237,10q�5      ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        id��,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��5   %   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� *Id+5    %     5"      -   5        lastName��$	 Фамилия��5$   %    5#   %   �� *
lastName+5$   %     5&      -   5        name��$	 Имя��5(   %    5'   %   �� *name+5(   %     5*      -   5        
middleName��$	 Отчество��5,   %    5+   %   �� *
middleName+5,   %     5.      -   5        numberPhone��$!	 Номер телефона��50   %    5/   %   �� *numberPhone+50   %     52      -   5        emailAdress��$	 Почта Email��54   %    53   %   �� *email+54   %    � ContextMenu 57      �� 58      .@�59      m� -   5        $2��,Добавить данные клиента��59      6@   m� 5:      -	   5        $0��*Удалить данные клиента��5:      6?   5;      5=        5?   
   -
   5        $ gridClientProduct��5?      $
 TrueY�5@      $ Single=�5A       .   .   .  $��453,39,10,265q�5F      $��2��6*   ��5C      ��  5I        5J      -   5        	idProduct��$	 Id товара��5L   %   
 .  5K   %   �� *Id+5M   %     5O      -   5        idEmailAdress��$	 Почта Email��5Q   %    5P   %   �� *email+5Q   %     5S      -   5        productCode��$	 Код продукта��5U   %    5T   %   �� *productCode+5U   %     5W      -   5        nameProduct��$	 Имя Товара��5Y   %    5X   %   �� *nameProduct+5Y   %    5\      �� 5]      .@�5^      m� -   5        $4��.Добавить данные продукта��5^      6A   m� 5_      -   5        $0��*Удалить данные продукт��5_      6?   5`      5b      �� 5d   
   $��Клиенты��6   $
��Left=�5e      $��10,0,0,0q�5f      $	��Top=�5g      $	��375��5h      $��Center=�5i      $��16(�5j      �� 5l   
   $��Покупки��6   $
��Left=�5m      $��	453,3,0,0q�5n      $	��Top=�5o      $	��337��5p      $��Center=�5q      $��16(�5r      $��2��6   5s      5t      