﻿#pragma checksum "..\..\VerificarID.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4A3C3B972C7F1D72D9027910D1F37F3DE062BD52CA1C4163F1592A0ED1753C01"
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
    /// VerificarID
    /// </summary>
    public partial class VerificarID : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\VerificarID.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image mem_inf;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\VerificarID.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_id;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\VerificarID.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_si;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\VerificarID.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_cancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/BaseDeDatosCamargo;component/verificarid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VerificarID.xaml"
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
            this.mem_inf = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.lb_id = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.bt_si = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\VerificarID.xaml"
            this.bt_si.Click += new System.Windows.RoutedEventHandler(this.bt_si_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bt_cancelar = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\VerificarID.xaml"
            this.bt_cancelar.Click += new System.Windows.RoutedEventHandler(this.bt_cancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

