﻿#pragma checksum "..\..\NuevoCliente.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "73191D40778EB871B1B6F2186637E6B4763DB06AF0FE61685B9EBC5A1EB49C5C"
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
    /// NuevoCliente
    /// </summary>
    public partial class NuevoCliente : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_nombre;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_tel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_correo;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_agregar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_cancelar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_empresa_cliente;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_nueva;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NuevoCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_refresh;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\NuevoCliente.xaml"
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
            System.Uri resourceLocater = new System.Uri("/BaseDeDatosCamargo;component/nuevocliente.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NuevoCliente.xaml"
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
            this.tb_nombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tb_tel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tb_correo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.bt_agregar = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\NuevoCliente.xaml"
            this.bt_agregar.Click += new System.Windows.RoutedEventHandler(this.bt_agregar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bt_cancelar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\NuevoCliente.xaml"
            this.bt_cancelar.Click += new System.Windows.RoutedEventHandler(this.bt_cancelar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cb_empresa_cliente = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\NuevoCliente.xaml"
            this.cb_empresa_cliente.Loaded += new System.Windows.RoutedEventHandler(this.cb_empresa_cliente_Loaded);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bt_nueva = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\NuevoCliente.xaml"
            this.bt_nueva.Click += new System.Windows.RoutedEventHandler(this.bt_nueva_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.bt_refresh = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\NuevoCliente.xaml"
            this.bt_refresh.Click += new System.Windows.RoutedEventHandler(this.bt_refresh_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.mem_inf = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
