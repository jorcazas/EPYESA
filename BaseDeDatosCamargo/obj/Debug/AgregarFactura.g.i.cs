﻿#pragma checksum "..\..\AgregarFactura.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "16155C0512D338FD69B3A849C19C6E4A2EA60B4942489C6370E9C0AEBF3942CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using BaseDeDatosCamargo;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BaseDeDatosCamargo {
    
    
    /// <summary>
    /// AgregarFactura
    /// </summary>
    public partial class AgregarFactura : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AgregarFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_X_r;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AgregarFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_agregar;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AgregarFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_atras;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AgregarFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_asignar_factura;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AgregarFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_r;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AgregarFactura.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image mem_inf;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BaseDeDatosCamargo;component/agregarfactura.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AgregarFactura.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bt_X_r = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\AgregarFactura.xaml"
            this.bt_X_r.Click += new System.Windows.RoutedEventHandler(this.bt_X_r_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bt_agregar = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\AgregarFactura.xaml"
            this.bt_agregar.Click += new System.Windows.RoutedEventHandler(this.bt_agregar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bt_atras = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\AgregarFactura.xaml"
            this.bt_atras.Click += new System.Windows.RoutedEventHandler(this.bt_atras_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bt_asignar_factura = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\AgregarFactura.xaml"
            this.bt_asignar_factura.Click += new System.Windows.RoutedEventHandler(this.bt_asignar_factura_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lb_r = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.mem_inf = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

