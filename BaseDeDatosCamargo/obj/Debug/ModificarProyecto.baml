   M S B A M L   `   `   `  ����M  IBaseDeDatosCamargo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BaseDeDatosCamargoBaseDeDatosCamargo  5   	   *    $BaseDeDatosCamargo.ModificarProyecto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:BaseDeDatosCamargo     5   	     � Title$  Modificar Proyecto��5   	    � WindowStartupLocation$ CenterScreen=�6$    � WindowState$ 	Maximized=�6I   $	��739��6a   $
��1076��6n   $
��1076��6{   $	��739��6�   .��5	      � .+�5
   
   �� -   5         ��Name$ bt_mod_prof_max��5
      $&�� Modificar 
Profundidad 
Máxma��6*   $��239,352,758,313q�6d   $��71��6}   $��43��6�   $��10(�6�   ���	#FFABF3006�   �� 5   
   -   5        $ bt_atras��5      $��Atrás��6#   $��82,569,871,114q�63   $��25��6K   $��Tahoma)�6W   ���	#7F0057B7$	��115��6�   $��2��6�   �� 5   
   -   5        $ bt_ver_documentos��5      $��Ver documentos��6,   $��25��6E   $��82,419,756,264q�6Q   $	��230��6i   $��Tahoma)�6u   ���	#FFABF300$��2��6�   �� 5   
   -   5        $ bt_as_reporte��5      $��Asignar Reporte Final��6(   $��82,539,756,144q�6H   $	��230��6`   $��25��6l   ���	#FFABF300$��2��6�   �� 5   
   -   5        $ bt_agregar_factura��5      $��Agregar Factura��6-   $��82,449,756,234q�6G   $	��230��6_   $��25��6�   $��2��6�   �� 5   
   -   5        $ bt_agregar_orden_compra��5      $��Agregar Orden de Compra��62   $��82,479,756,204q�6T   $	��230��6l   $��25��6�   $��2��6�   �� 5   
   -   5        $ bt_agregar_cotizacion��5      $��Agregar Cotización��60   $��82,509,756,174q�6M   $	��230��6e   $��25��6�   $��2��6�   �� 5   
   -   5         ��Name$ 	lb_nombre��5      $�� ��6#   $��84,197,469,487q�6.   $��Tahoma)�6F   $��24��6Z   $	��515��6f   $��2��6r   �� 5   
   -	   5        $ 
lb_cliente��5      $�� ��6$   $��84,255,469,429q�6/   $��Tahoma)�6G   $��24��6[   $	��515��6g   $��2��6s   �� 5   
   -
   5        $ 	lb_estado��5      $�� ��6#   $��621,268,60,416q�6.   $��Tahoma)�6F   $��24��6Z   $	��387��6f   �� 5   
   -   5        $ lb_municipio��5      $�� ��6&   $��621,297,60,387q�61   $��Tahoma)�6I   $��24��6]   $	��387��6i   �� 5   
   $��Ubicación:��6   $��621,239,60,445q�6%   $��Tahoma)�6=   $
��Bold"�6Q   $��24��6c   $	��387��6o   �� 5   
   -   5        $ lb_responsable��5      $�� ��6(   $��84,313,469,371q�63   $��Tahoma)�6K   $��24��6_   $	��515��6k   $��2��6w   �� 5   
   $��Responsable de campo:��6   $��84,284,829,400q�60   $��Tahoma)�6H   $
��Bold"�6\   $��24��6n   $	��155��6z   $��2��6�   �� 5   
   $��	Proyecto:��6   $��84,168,912,516q�6$   $��72��6<   $��Tahoma)�6G   $
��Bold"�6[   $��24��6m   $��2��6y   �� 5   
   -   5        $ lb_nombre_Copy��5      $��Cliente:��6(   $��84,226,923,458q�6;   $��Tahoma)�6S   $
��Bold"�6g   $��24��6y   $��61��6�   $��2��6�   �� 5   
   $��Coordenadas:��6   $��621,326,60,358q�6'   $��Tahoma)�6?   $
��Bold"�6S   $��24��6e   $	��387��6q   �� 5   
   $��Latitud:��6   $��621,355,383,329q�6#   $��Tahoma)�6<   $��24��6P   $��64��6\   �� 5   
   $��	Longitud:��6   $��746,355,258,329q�6$   $��Tahoma)�6=   $��24��6Q   $��64��6]   �� 5   
   -   5        $ 
lb_latitud��5      $�� ��6$   $��621,384,327,300q�6/   $��Tahoma)�6H   $��24��6\   $	��120��6h   �� 5   
   -   5        $ lb_longitud��5      $�� ��6%   $��746,384,202,300q�60   $��Tahoma)�6I   $��24��6]   $	��120��6i   �� 5   
   $��Profundidad máxima:��6   $��84,342,829,342q�6.   $��Tahoma)�6F   $
��Bold"�6Z   $��24��6l   $	��155��6x   $��2��6�   �� 5    
   -   5        $ lb_prof_max��5       $�� ��6%   $��84,371,923,313q�60   $��Tahoma)�6H   $��24��6\   $��61��6h   �� 5!   
   $)��#Fecha de asignación (AAAA-MM-DD): ��6   $��621,181,60,503q�6=   $��Tahoma)�6U   $
��Bold"�6i   $��24��6{   $	��387��6�   �� 5"   
   -   5        $ lb_fecha��5"      $�� ��6"   $��621,210,60,474q�6-   $��Tahoma)�6E   $��24��6Y   $	��387��6e   �� 5#   
   $	��ID:��6   $��621,123,405,561q�6   $��Tahoma)�67   $
��Bold"�6K   $��24��6]   $��42��6i   �� 5$   
   -   5        $ lb_id��5$      $�� ��6   $��621,152,105,532q�6*   $��Tahoma)�6C    J� RenderTransformOrigin$ 	1.593,0.5&�6W   $��24��6y   $	��342��6�   �� 5%   
   $��m��6   $��150,371,886,313q�6   $��32��65   $��Tahoma)�6@   $��24��6T   �� 5&   
   -   5         ��Name$ semaforo��5&      $��84,86,926,561q�6"   $��amarillo.png��69   $��58��6O   $��61��6Z   $��2��6f   �� 5'   
   -   5        $ lb_terminado��5'      $��NO TERMINADO��6&   $��147,106,815,578q�6=   $��Tahoma)�6V   $
��Bold"�6j   $��24��6|   $	��106��6�   �� 5(   
   $+��%Fecha de finalización (AAAA-MM-DD): ��6   $��621,413,60,271q�6?   $��Tahoma)�6W   $
��Bold"�6k   $��24��6}   $	��387��6�   �� 5)   
   -   5        $ lb_fecha_finalización��5)      $��-��6/   $��621,442,60,242q�6;   $��Tahoma)�6S   $��24��6g   $	��387��6s   �� 5*   
   $��38��6   $��Membrete superior VF.png��6   $��0,-5,0,0q�6>   $	��Top=�6P   $��2��6h   �� 5+   
   -   5        $ mem_inf��5+      $��Membrete inferior VF.png��6!   $��73��6C   $��Bottom=�6O   $��2��6j   �� 5,   
   $��10,22,972,654q�6   $��	PGSVF.jpg��6'   $��86��6:   $��32��6E   5.      5/      