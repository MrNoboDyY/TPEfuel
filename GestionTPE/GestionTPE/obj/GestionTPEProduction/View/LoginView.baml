   M S B A M L   `   `   `  ���� E  AGestionTPE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionTPE.ViewModelGestionTPE.ViewModel      GestionTPE.View.LoginView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     8	viewModel"clr-namespace:GestionTPE.ViewModel     U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  	LoginView��$	��346��$	��492�� � DataContext )   #GestionTPE.ViewModel.LoginViewModel  .���  � ColumnDefinitions �� .+��� $
��Left=�$��38��$��	170,6,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��142������ *loginModel.NumTpe+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $
��Left=�$��35��$��
165,49,0,0q�$
 Wrap=�$	��Top=�$	��142������ *loginModel.CodeSite+$ TwoWay=�$ PropertyChanged=��� $��Numero TPE :��$
��Left=�$��	83,16,0,0q�$	��Top=��� $��Numero Site :��$
��Left=�$��	83,58,0,0q�$	��Top=� J� RenderTransformOrigin$ -0.211,-0.462&��� $��	Connexion��$
��Left=�$��
366,16,0,0q�$	��Top=�$
��auto������ *ConnectionCommand+�� $��Déconnexion��$
��Left=�$��
352,71,0,0q�$	��Top=�$
��auto������ *DisconnectCommand+�� $��ENTER LOYALTY / TOMCARD��$
��Left=�$��107,189,0,0q�$	��Top=�$	��284��$��68������ *LoyaltyViewCommand+�� $
��Left=�$��30��$��111,121,0,0q�$
 Wrap=�$	��Top=�$	��284���� $��URL WebService��$
��Left=�$��
10,121,0,0q�$	��Top=�$
��auto��