   M S B A M L   `   `   `  ����A  =Unit16, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Unit16Unit16  5   	       Unit16.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Unit16     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��451��5	   	   $	��449��6   $	��801��5
   	   $	��799��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��311* �6   �� 5      $	��89* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
gridClient��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         SelectionMode$ Single=�5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .  $��10,34,237,10q�5      ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       -   5        id��,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��5"   %   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5!   %   �� *id+5#   %     5%      -   5        lastName��$	 Фамилия��5'   %    5&   %   �� *
lastName+5'   %     5)      -   5        name��$	 Имя��5+   %    5*   %   �� *name+5+   %     5-      -   5        
middleName��$	 Отчество��5/   %    5.   %   �� *
middleName+5/   %     51      -   5        numberPhone��$!	 Номер телефона��53   %    52   %   �� *numberPhone+53   %     55      -   5        emailAdress��$	 Почта Email��57   %    56   %   �� *email+57   %    � ContextMenu 5:      �� 5;      .@�5<      m� -   5        $2��,Добавить данные клиента��5<      6@   m� 5=      -	   5        $0��*Удалить данные клиента��5=      6?   5>      5@        5B   
   -
   5        $ gridClientProduct��5B      $
 TrueY�5C      $ Single=�5D       .   .   .  $��453,39,10,265q�5I      $��2��6*   ��5F      ��  5L        5M      -   5        	idProduct��$	 Id товара��5O   %   
 .  5N   %   �� *id+5P   %     5R      -   5        idEmailAdress��$	 Почта Email��5T   %    5S   %   �� *email+5T   %     5V      -   5        productCode��$	 Код продукта��5X   %    5W   %   �� *codeProduct+5X   %     5Z      -   5        nameProduct��$	 Имя Товара��5\   %    5[   %   �� *nameProduct+5\   %    5_      �� 5`      .@�5a      m� -   5        $4��.Добавить данные продукта��5a      6A   m� 5b      -   5        $0��*Удалить данные продукт��5b      6?   5c      5e      �� 5g   
   $��Клиенты��6   $
��Left=�5h      $��10,0,0,0q�5i      $	��Top=�5j      $	��375��5k      $��Center=�5l      $��16(�5m      �� 5o   
   $��Покупки��6   $
��Left=�5p      $��	453,3,0,0q�5q      $	��Top=�5r      $	��337��5s      $��Center=�5t      $��16(�5u      $��2��6   5v      5w      