   M S B A M L   `   `   `  ����D  @Task 10.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Task_10._1
Task_10._1  5   	       Task_10._1.ClientAdder   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Task_10._1     5   	     � Title$6  0Добавление нового клиента��5   	   $	��400��6+   $	��300��68    � Icon$ /a-bank-logo.png��6D   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Фамилия:��6   $��0��6#   �� 5   
   -   5         ��Name$ SurnameTextBox��5      $��14(�6*   $
��Bold"�68   $��1��6J   �� 5   
   $��Имя:��6   $��2��6   �� 5   
   -   5        $ NameTextBox��5      $
��Bold"�6'   $��14(�69   $��3��6G   �� 5   
   $��Отчество:��6   $��4��6$   �� 5   
   -   5        $ PatronymicTextBox��5      $
��Bold"�6-   $��14(�6?   $��5��6M   �� 5    
   $"��Номер телефона:��6   $��6��6*   �� 5!   
   -   5        $ PhoneNumberTextBox��5!      $
��Bold"�6.   $��14(�6@   $��7��6N   �� 5#   
   $0��*Серия и номер паспорта:��6   $��8��62   �� 5$   
   -   5        $ PassportTextBox��5$      $
��Bold"�6+   $��14(�6=   $��9��6K   �� 5&   
   -   5         ��Name$ AddClientButton��5&      $��Добавить��6*   $��10��6=   ���	#FFEF3124$��16(�5'      
����������	#FFEF31246=   5(      5)      