   M S B A M L   `   `   `  ����F  BCalendarApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CalendarAppCalendarApp  5   	       CalendarApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1calendarAppclr-namespace:CalendarApp     5   	     � Title$  
MainWindow��5   	   $	��800��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��0��5      $
��Date��6   $��2��6,   6@   �� 5   
   -   5        $��1��5      $
��Date��6   $��2��6,   6@   7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   $��2��6   $��6��6(      Child 5      $   CalendarApp.SfmlDrawingSurface  5      $   CalendarApp.SfmlDrawingSurface   SizeChanged$ DrawSurface_SizeChanged��5   1   -   5        DrawSurface��5   1   5      �� 5    
   -   5        $��3��5       $
��Play��5"      $
��Left=�5#      $��4q�5$      �� 5%   
   -   5        $��3��5%      $��1��5&      $
��Stop��5(      $
��Left=�5)      $��4q�5*      (  "System.Windows.Controls.DatePicker  5+   
   -   5        $��2��5+      $
��Left=�6%   $��3��6@   $	��Top=�6M   6e   5,      5-      