   M S B A M L   `   `   `  ����G  CLoginRoleApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LoginRoleApp.CommonLoginRoleApp.Common  5          LoginRoleApp.Views.Main   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      /local!clr-namespace:LoginRoleApp.Common   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5       � 	Resources 5      3   -LoginRoleApp.Common.RoleToVisibilityConverter   RoleToVisibilityConverter��%   &	          5   
   6*   5	      .��5
      �� .+�5   
   �� ��6   �� *
UserAuth+�� 5   
   ��6   �� *
UserRole+�� 5   
   $J��DЭтот текст только для администратора��6   
��� � �y�6S   �� *
UserRole+ �� 	Converter# [   �� ConverterParameter$  Администратор���� 5   
   $��
Выйти��60   $��	10,20,0,0q�6@   $	��180��6S   ��6   �� *	LogoutCmd+6S   5      5      