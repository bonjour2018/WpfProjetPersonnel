   M S B A M L   `   `   `  ����>  :NHL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NHLNHL  5   	       NHL.CongeMedecin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:NHL     5   	   -   5          � Title$  CongeMedecin��5   	   $��646.085��6   $��939.999��6/    � WindowStartupLocation$ CenterScreen=�6V   .��5	      � $��	0,0,0,-55q�6   .+�5
   
   �� -   5         ��Name$ label��5
      $��Numero Admission :��6   $
��Left=�6<   $��	57,35,0,0q�6W   $	��Top=�6j   $��15(�6�   �� 5   
   -   5         ��Name$ cbAdmis��5      $
��Left=�6$   $��
209,39,0,0q�6?   $	��Top=�6S   $��72��6k   $��15(�6v    �� DisplayMemberPath$ idAdmission��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��6�   �� 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtAdmission1��5         AutoGenerateColumns .     
IsReadOnly . $
��Left=�6W   $��
57,213,0,0q�6r   $	��Top=�6�   $	��148��6�   $	��810��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Numéro Admission��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *idAdmission+  5      $
 Médecin��6%    66   �� *	idMedecin+  5      $
 	Préposé��6%    66   �� *	idPrepose+  5      $
 Patient��6%    66   �� *	idPatient+  5      $	
 Lit��6%    62   �� *idLit+  5      $
 Commodité Sup��6%    6<   �� *	idCommo+  5      $
 Date Admission��6%    6=   �� *
dateAdmiss+  5      $
 Date de Congé��6%    6<   �� *	dateConge+  5      $
 Compagnie d'assurance��6%    6D   �� *nomAssurance+  5      $
 Montant��6%    66   �� *prix+5      �� 5   
   -   5        $ 
label_Copy��5      $��Nom :��6$   $
��Left=�64   $��	57,74,0,0q�6O   $	��Top=�6b   $��15(�6z   �� 5   
   -   5         ��Name$ txtNom��5      $
��Left=�6"   $��23��6=   $��
208,78,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��163��6�   $��15(�6�   �� 5   
   -   5         ��Name$ btnConge��5      $��Donner Congé��6#   $
��Left=�6:   $��380,582,0,0q�6U   $	��Top=�6j   $	��128��6�   $��15(�6�   6�   �� 5   
   -   5        $ label_Copy1��5      $��Date de Congé :��6%   $
��Left=�6?   $��
57,112,0,0q�6Z   $	��Top=�6n   $��15(�6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ datePicker1��5      $
��Left=�6+   $��209,118,0,0q�6F   $	��Top=�6[   �� 5   
   -
   5        $ label1��5      $��Admissions encore valides��6    $
��Left=�6D   $��
57,171,0,0q�6_   $	��Top=�6s   $��20(�6�   $��Oblique$�6�   $��SemiCondensed&�6�   $
��Bold"�6�   �� 5    
   -   5        $ label1_Copy��5       $ ��Admissions Mises en congé��6%   $
��Left=�6I   $��
57,386,0,0q�6d   $	��Top=�6x   $��20(�6�   $��Oblique$�6�   $��SemiCondensed&�6�   $
��Bold"�6�     5!   
   -   5        $ dtAdmisConge��5!       .   . $
��Left=�6W   $��
57,423,0,0q�6r   $	��Top=�6�   $	��148��6�   $	��810��6�   	 5"        5#      $
 Numéro Admission��6%    6?   �� *idAdmission+  5$      $
 Médecin��6%    66   �� *	idMedecin+  5%      $
 	Préposé��6%    66   �� *	idPrepose+  5&      $
 Patient��6%    66   �� *	idPatient+  5'      $	
 Lit��6%    62   �� *idLit+  5(      $
 Commodité Sup��6%    6<   �� *	idCommo+  5)      $
 Date Admission��6%    6=   �� *
dateAdmiss+  5*      $
 Date de Congé��6%    6<   �� *	dateConge+  5+      $
 Compagnie d'assurance��6%    6D   �� *nomAssurance+  5,      $
 Montant��6%    66   �� *prix+5.      50      51      