   M S B A M L   `   `   `  ����A  =Unit18, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Unit18Unit18  5   	       Unit18.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Unit18     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
gridAnimal��5
      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         SelectionMode$ Single=�5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .  $��25,34,464,22q�5      ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Id��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5   %   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5   %   �� *Id+5   %     5      -   5        Name��$ Имя��5   %   
 5   %   �� *Name+5   %     5      -   5        
Height��$ Рост��5    %   
 5   %   �� *Height+5    %     5"      -   5        
Weight��$ 
Масса��5$   %   
 5#   %   �� *Weight+5$   %     5&      -   5        
TypeAnimal��$ Тип животного��5(   %   
 5'   %   �� *
TypeAnimal+5(   %    � ContextMenu 5,      �� 5-      .@�5.      m� -   5        $#��Добавить данные��5.      68   m� 5/      -   5        $!��Удалить данные��5/      67   50      52      �� 54   
   -	   5         ��Name$ typeSave��54      $
��Left=�55      $��
500,36,0,0q�56      $	��Top=�57      $	��159��58      59      5:      