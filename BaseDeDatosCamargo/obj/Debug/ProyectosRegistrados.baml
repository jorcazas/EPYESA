   M S B A M L   `   `   `  ����M  IBaseDeDatosCamargo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BaseDeDatosCamargoBaseDeDatosCamargo  5   	   -    'BaseDeDatosCamargo.ProyectosRegistrados   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:BaseDeDatosCamargo     5   	     � Title$  ProyectosRegistrados��5   	    � WindowStartupLocation$ CenterScreen=�6&    � WindowState$ 	Maximized=�6K   $	��739��6c   $
��1076��6p   $
��1076��6}   $	��739��6�   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dg��5      $��10,157,113,100q�6      
IsReadOnly . $	��945��6p   $	��451��6|   �� 5   
   -   5         ��Name$ bt_atras��5      $��Atrás��6#   $��40��63   $��960,568,10,100q�6?   $��98��6W   $��Tahoma)�6b   ���	#7F0057B76�   �� 5   
   $!��Vista rápida de proyectos:��6   $��10,122,904,556q�65   $��Tahoma)�6M   $	��154��6a   $��30��6m   �� 5   
   $0��*Búsqueda de proyecto por nombre o por ID:��6   $��10,69,806,613q�6D   $��Tahoma)�6[   $	��252��6o   $��26��6{   �� 5   
   -   5         ��Name$ tb_busqueda_proyecto��5      $��24��60   $��262,71,568,613q�6<    �� TextWrapping$
 Wrap=�6T   $	��238��6h   �� 5   
   -   5        $ 	bt_buscar��5      $��Buscar��6$   $��24��65   $��505,71,469,613q�6A   $��94��6Y   $��Tahoma)�6d   ���	#FFABF3006�   �� 5   
   -   5        $ 	bt_volver��5      $��Todos los proyectos��6$   $��604,71,340,613q�6B   $	��124��6Z   $��24��6f   $��Tahoma)�6r   6�   �� 5   
   -   5        $ bt_mapa��5      $
��Mapa��6"   $��733,71,261,613q�61   $��74��6I   $��24��6T   $��Tahoma)�6`   6t   �� 5   
   -   5        $ bt_reporte_economico��5      $��Reporte
Económico��6/   $��41��6T   $��960,522,10,145q�6`   $��98��6x   $��Tahoma)�6�   ���	#FFABF3006�   �� 5   
   $��38��6   $��Membrete superior VF.png��6   $��0,-5,0,0q�6>   $	��Top=�6P   �� 5   
   -   5        	 ��Name$	 mem_inf��5      $��Membrete inferior VF.png��6!   $��73��6C   $��Bottom=�6O   $��-4,0,4,0q�6j   �� 5   
   $��10,22,972,654q�6   $��	PGSVF.jpg��6'   $��86��6:   $��32��6E   5      5      