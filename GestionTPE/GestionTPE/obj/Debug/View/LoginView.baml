   M S B A M L   `   `   `  ����E  AGestionTPE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionTPE.ViewModelGestionTPE.ViewModel  5   	       GestionTPE.View.LoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8	viewModel"clr-namespace:GestionTPE.ViewModel     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	LoginView��5   	   $	��427��6   $	��858��6(    � WindowStyle$ SingleBorderWindow=�64    � 
ResizeMode$ NoResize=�6V    � WindowStartupLocation$ CenterScreen=�6l   
���   � � DataContext 5      )   #GestionTPE.ViewModel.LoginViewModel  5   
   .��5
      � ���	#FFB3DEF7 � ColumnDefinitions 5   
   �� 5      .+�5   
   '  !MaterialDesignThemes.Wpf.PackIcon  -   5        $��conicon��5   "   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ AccessPointNetwork=�61   $��61��6K   $��90��6W   $��732,249,0,0q�6b   #��� ��6w   
���   � J� OpacityMask 5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 Black��6#    � Offset$ 0Q�61   � 5      $
 White��6#   $ 1Q�61   5      5      �� 5   
   $
��Left=�6   $��38��6-   $��
223,74,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6�   $	��262��6�   ��6a   �� *loginModel.NumTpe+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $
��Left=�6   $��35��6-   $��223,139,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��262��6�   ��6b   �� *loginModel.CodeSite+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��Numero TPE :��6   $
��Left=�6'   $��	94,83,0,0q�6B   $	��Top=�6U   $��38��6m   $	��105��6y   �� 5   
   $��Numero Site :��6   $
��Left=�6(   $��
94,149,0,0q�6C   $	��Top=�6W    J� RenderTransformOrigin$ -0.211,-0.462&�6o   $��35��6�   $	��105��6�   �� 5   
   $��	Connexion��67   $
��Left=�6K   $��
561,74,0,0q�6f   $	��Top=�6z   $	��194��6�   $��65��6�   $ 0.526,0.062&�6�   ��6   �� *ConnectionCommand+6�   �� 5   
   $��Déconnexion��68   $
��Left=�6N   $��561,176,0,0q�6i   $	��Top=�6~   $	��194��6�   $��64��6�   ��6   �� *DisconnectCommand+6�   �� 5   
   $��ENTER LOYALTY / TOMCARD��69   $��111,325,91,10q�6[   $
��Auto��6r   ��6   �� *LoyaltyViewCommand+6r   �� 5    
   -   5        $��webserviceAddress��5       $
��Left=�6�   $��41��6�   $��111,269,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��616��6�   {�.  $��2q�6  ��6,   �� *loginModel.WebServiceAddress+$ TwoWay=�$ PropertyChanged=�6  �� 5!   
   $��URL WebService��6   $
��Left=�6)   $��
10,279,0,0q�6D   $	��Top=�6X   $	��101��6p   $��41��6|   5$      5%      