   M S B A M L   `   `   `  ����>  :NHL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AjoutSupModifPersonnelAjoutSupModifPersonnel  5   	   ,    &AjoutSupModifPersonnel.Ajout_Sup_Modif   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:AjoutSupModifPersonnel     5   	   -   5          � Title$  Ajout_Sup_Modif��5   	   $��511.27��6!   $��825.615��61    � 
ResizeMode$ NoResize=�6A   .��5	      � .+�5
   
   � $
��Left=�6   $	��404��6*   $��	77,30,0,0q�67   $	��Top=�6J   $	��612��6b   .+�5      �� -   5         ��Name$ label_Copy1��5      $��Nom           :��6)   $
��Left=�6C   $��	59,87,0,0q�6^   $	��Top=�6q   $��14(�6�   �� 5      -   5         ��Name$ 
txtMedecin��5      $
��Left=�6*   $��23��6E   $��
152,90,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 	dtMedecin��5      $
��Left=�6*   $��152,142,0,0q�6E   $	��Top=�6Z   $	��152��6r   $	��303��6      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
ID Medecin��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *	idMedecin+  5      $	 Nom��6)   	 66   �� *nom+5      �� 5      -   5        
 ��Name$
 btnAjouterMed��5      $��Ajouter��6,   $
��Left=�6>   $��183,333,0,0q�6Y   $	��Top=�6n   $��75��6�   $��14(�6�   �� 5      -   5        $
 btnModifMed��5      $��Modif��6*   $
��Left=�6:   $��352,333,0,0q�6U   $	��Top=�6j   $��76��6�   $��14(�6�   6�   �� 5      -   5        $ 
label_Copy��5      $��ID Médecin :��6(   $
��Left=�6?   $��	59,35,0,0q�6Z   $	��Top=�6m   $��14(�6�   �� 5      -   5        $ txtIdMedecin��5      $
��Left=�6,    �� 
IsReadOnly . $��23��6Y   $��
152,40,0,0q�6e   $
 Wrap=�6y   $�� ��6�   $	��Top=�6�   $��52��6�   $��14(�6�    �� IsReadOnlyCaretVisible . 6�   5      5      5      