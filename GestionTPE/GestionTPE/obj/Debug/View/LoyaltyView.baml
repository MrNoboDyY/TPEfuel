   M S B A M L   `   `   `  ����E  AGestionTPE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GestionTPE.ViewModelGestionTPE.ViewModel  5   	   !    GestionTPE.View.LoyaltyView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6	viewModel"clr-namespace:GestionTPE.ViewModel    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6F     � Title$  LoyaltyView��5   	   $��464.633��6   $��959.552��6.    � 
ResizeMode$ NoResize=�6>    � WindowStartupLocation$ CenterScreen=�6T    � DataContext 5      +   %GestionTPE.ViewModel.LoyaltyViewModel  5	   
   .��5      �� $��	0,0,-6,-6q�6   .@�5   
   �� $��SOLDE POINT��6   .��5      � ���	#FFB3DEF7$��-11,1,-3,-2q�6*    � RowDefinitions 5      �� 5      $	��206 �6$    � ColumnDefinitions 5      �� 5      .+�5      �� -   5         ��Name$ numerodecarteLabel��5      $��NumCarte * :��64   $��Stretch=�6K   $��10,46,790,112q�6i   $
��Bold"�6�   �� 5      $��Stretch=�6   $��166,46,261,112q�68    �� TextWrapping$
 Wrap=�6P   $��Stretch=�6�   
����ح�$��1q�6�   ��6d   �� *LoyaltyModel.NumeroDeCarte+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5      -   5        $ historiquepointLabel��5      $��Points Bruts��66   $��Stretch=�6M   $��10,113,790,0q�6k   $	��Top=�6�   $��42��6�   $
��Bold"�6�   �� 5      {�.  
����ح�$��Stretch=�6C   $��166,111,367,52q�6a   $
 Wrap=�6y   $��Stretch=�6�   $��1q�6  $
��Bold"�6  ��6�   �� *LoyaltyModel.ReponseDecodee+$ TwoWay=�$	 PropertyChanged=�6  �� 5      $��Valider��6?   $��715,46,10,61q�6Q   $��Stretch=�6g   $
��Auto��6�   
��� � �$��3q�6�   ���	#FF11BD18��6   �� *SoldePointCommand+6�   �� 5      $��Retour Accueil��6B   $��715,343,21,-183q�6[   $��1��6t   
 J� RenderTransformOrigin$
 0.419,4.188&�6�   $
��Auto��6�   $��12(�6�   $
��Bold"�6�   $��3q�6�   ���	#FF0E6DB8��6   �� *RetourAccueilCommand+6�   � 5      $
��Left=�6R   $	��156��6m   $��10,160,0,-109q�6z   $	��Top=�6�   $	��334��6�   y�6   �� *%#LoyaltyModel.VisibiliteInformations+.+�5      �� $��Solde Points��6   $
��Left=�64   $��26��6O   $��	10,10,0,0q�6[   $	��Top=�6n   $	��121��6�   �� 5      $��Au��6   $��Right=�6*   $��35��6F   $��
0,61,214,0q�6R   $	��Top=�6f   $	��121��6~   �� 5      $��Statut��6   $
��Left=�6-   $��24��6H   $��
10,112,0,0q�6T   $	��Top=�6h   $	��121��6�   �� 5      -   5        $��txtPointCarte��5   0   {�.  $
��Left=�6E   $��26��6`   $��
160,10,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��126��6  ��6�   �� *LoyaltyModel.PointCarte+$ TwoWay=�$	 PropertyChanged=�6  �� 5       -   5        $��txtReponseDecodee��5    0   {�.  $
��Left=�6I   $��44��6d   $��
160,51,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��126��6
  ��6�   �� *LoyaltyModel.DateCarte+$ TwoWay=�$	 PropertyChanged=�6
  �� 5!      {�.  $
��Left=�60   $��36��6K   $��160,100,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��126��6�   ��6�   �� *LoyaltyModel.StatutCarte+$ TwoWay=�$	 PropertyChanged=�6�   5"      � 5#      $
��Left=�6   $��31��63   $��596,113,0,0q�6?   $	��Top=�6T   $��94��6l   �� 5$      $��ERREUR��6   $��31��6^   $��608,113,21,0q�6j   ���	#FFFF1100$��14(�6�   $��Antique Olive Compact)�6�   $	��Top=�6�   y�6)   �� *LoyaltyModel.VisibiliteErreur+6�   � 5%      $
��Left=�6L   $��87��6g   $��596,165,0,-45q�6s   $	��Top=�6�   $	��111��6�   y�6   �� *LoyaltyModel.VisibiliteErreur+.+�5&      �� -   5         ��Name$ MessageErreur��5&      $��87��65   $��470,163,-470,-163q�6A   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   5'      '  !MaterialDesignThemes.Wpf.PackIcon  5(      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ Cards=�6*   $	��156��67   $��748,160,0,-109q�6D   
����  �$	��141��6r   5)      5*      �� 5+   
   $��PRODUIT��6   .��5,      � ���	#FFB3DEF7$��-10,-1,-2,-1q�6*    5-      �� 5.      $��0* �6'   �� 5/      .+�51      � $
��Left=�6   $��0��62   $��0,10,0,0q�6=   $	��Top=�6O   $��0��6g   $��1��6q   �� 52      $��
Validation��6F   $
��Auto��6[   $��312,166,233,192q�6i   
��� � �$
 0.461,-0.741&�6�   $��1��6�   ���	#FF1C6838$��3q�6�   ��6   �� *BrulerCodeProduitCommand+6�   �� 53      $��
Annulation��6G   $
��Auto��6\   $��312,250,233,106q�6j   $
 0.539,1.625&�6�   
���  ��$��1��6�   ���	#FF720C07$��3q�6�   ��6   �� *LibererCodeProduitCommand+6�   �� 54      $��Retour Accueil��6B   $
��Auto��6[   $��722,355,27,13q�6i   $��1��6�   ���	#FF3E72CD$��3q�6�   ��6   �� *RetourAccueilCommand+6�   �� 55      -   5        $��lblcodeproduit��55      $��
codproduit��6.   $��26��6C   $��20,26,794,0q�6O   $	��Top=�6d   $��1��6|   $
��Bold"�6�   $��Center=�6�   $	��138��6�   �� 56      -   5        $��codeproduit��56      $��69��6-    �� 	MaxLength$ 2��69   $��20,65,789,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $
 
0.54,0.478&�6�   $��1��6  $��1q�6  ��6G   �� *LoyaltyModel.Codeproduit+$ TwoWay=�$	 PropertyChanged=�6  �� 57      -   5        $��	codebarre��57      $��Right=�6+   $��66��6G   $��
0,68,545,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��222��6�   $
 
1.71,0.391&�6�   $��1��6  $��1q�6*  ��6S   �� *LoyaltyModel.Codebarre+$ TwoWay=�$	 PropertyChanged=�6*  �� 58      -	   5        $��ajouter��58      $��Ajouter��6(   $
��Left=�6d   $��66��6   $��
426,68,0,0q�6�   $	��Top=�6�   $	��186��6�   $��1��6�   $��3q�6�   ���	#FF1672CF��6:   �� *CodebarrePointCommand+6�   �� 59      -
   5        $��points��59      $
��Left=�6(   {�.  $��67��6�   $��
617,67,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��102��6�   $��1��6  
���   �$��1q�6+  ��6U   �� *LoyaltyModel.Pointproduit+$ TwoWay=�$	 PropertyChanged=�6+  �� 5:      -   5        $��	lblpoints��5:      $��points��6)   $��Center=�6:   $��35��6W   $��617,26,226,0q�6c   $	��Top=�6y   $	��109��6�   $
 1.459,0.346&�6�   $��1��6�   $
��Bold"�6�   �� 5;      -   5        $��lblcodebarre��5;      $��	codebarre��6,   $��199,26,545,0q�6@   $��1��6V   $
��Bold"�6f   $	��Top=�6x   $��26��6�   �� 5<      -   5        $��	lblstatut��5<      $��statut��6)   $��Center=�6:   $��35��6W   $��765,26,70,0q�6c   $	��Top=�6x   $	��117��6�   $��1��6�   $
��Bold"�6�   �� 5=      -   5        $��statut��5=      {�.  $��1��6:   $
��Left=�6J   $��66��6e   $��
765,68,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��117��6  $��1q�6  ��6�   �� *LoyaltyModel.Statutcode+$ TwoWay=�$	 PropertyChanged=�6    5>      $ Cards=�6*   
����  �$��2��6N   $	��141��6b   $	��144��6o   $��768,166,0,0q�6{   5?      5@      �� 5A   
   $��LISTE DE PRODUITS��6   .��5B      � $��0,0,0,-5q�6    5C      �� 5D      .+�5F      �� $��CODEPRODUIT��6   $��13,213,836,149q�6.   �� 5G      $��	CODEBARRE��6   $��13,287,836,83q�6,   �� 5H      -   5        $��button��5H      $��Ajouter��6'   $
��Left=�6c   $��49��6~   $��
13,345,0,0q�6�   $	��Top=�6�   $	��349��6�   ��69   �� *AjouterProduitCommand+6�   �� 5J      -   5        $��
validation��5J      $��
Validation��6+   $
��Left=�6@   $
��Auto��6[   $	��220��6i   $��454,339,0,23q�6u   
��� � �6�   �� 5K      -   5        $��
annulation��5K      $��
Annulation��6+   $
��Left=�6@   $
��Auto��6[   $	��211��6i   $��709,268,0,94q�6u   
���  ��6�   �� 5L      $
��Left=�6u   $��54��6�   $��123,213,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��88��6�   ��6   �� *LoyaltyModel.Codeproduit+$ TwoWay=�$	 PropertyChanged=�6�   �� 5M      $
��Left=�6r   $��47��6�   $��123,286,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��90��6�   ��6   �� *LoyaltyModel.Codebarre+$ TwoWay=�$	 PropertyChanged=�6�   �� 5N      -   5        $��listproduit��5N   .   $��	10,8,20,0q�6   
���   �$	��200��5O   N   $	��Top=�6[   $��3q�6s   ���	#890E5DE8��6   ��  �� Path$ LoyaltyModel.Produits� �� View 5P      �� 5Q      .P�5R      �� $��Code produit��5S       �� Width$
 auto��6*    �� DisplayMemberBinding 5R   -   �� $ codeproduit�5S   *   �� 5T      $��
Code barre��5U      $
 auto��6'    5T   -   �� $ 	codebarre�5U   '   �� 5V      $��Points produit��5W      $
 auto��6+    5V   -   �� $ pointproduit�5W   +   �� 5X      $��Statut code��5Y      $
 auto��6(    5X   -   �� $ 
statutcode�5Y   (   5Z      5\      �� 5]      $��Retour Accueil��6   $
��Left=�6[   $��35��6v   $��709,353,0,0q�6�   $	��Top=�6�   $	��211��6�   ��62   �� *RetourAccueilCommand+6�     5^      $ Cards=�6*   $	��115��67   
����  �$	��220��6Z   $��454,216,0,0q�6f   5_      5`      5a      5b      