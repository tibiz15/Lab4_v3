   M S B A M L   `   `   `  ����?  ;Lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab4Lab4  5   	   /clr-namespace:Lab4.controllsLab4.controlls  5   	       Lab4.EditUserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab4     5   	   2	controllsclr-namespace:Lab4.controlls     5   	     � Title$  EditUserWindow��5	   	   $	��320��6    $	��450��6-    � 
ResizeMode$ CanMinimize=�69   .��5
      � .+�5   
   �� -   5         ��Name$ label��5      $&�� Enter your personal information:��6   $��Center=�6J   $��Center=�6n   $��0,5,0,0q�6�   $	��Top=�6�   �� 5   
   $��60,25q�6   .+�5      �� .��6   Name:6   #  Lab4.controlls.ColorInputText  5      $
��10,3q�6'   ��65   �� *
NameText+"  Lab4.controlls.ColorControll   IsValid 6P   �� *	ValidName+ �� Mode$ TwoWay=��� 5      .��6   
Surname:6     5      $
��10,3q�6'   ��65   �� *SurnameText+ 6R   �� *ValidSurName+$ TwoWay=��� 5      .��6   Email:6     5      $
��10,3q�6'   ��65   �� *	EmailText+ 6P   �� *
ValidEmail+$ TwoWay=��� 5      .��6   Birth date:6!   $  Lab4.controlls.ColorDatePicker  5      $
��40,3q�6(   (  "System.Windows.Controls.DatePicker   SelectedDate 66   �� *	BirthDate+   IsValidDate 6Y   �� *
ValidBirth+$ TwoWay=��� 5      $
��Left=�69   $
��Save��6T   $	��7,7q�6c   ��6   �� *ProceedCommand+{�6p   �� *FilledFields+5      5      5      