#pragma checksum "..\..\Asignar_Profundidad.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "587636FE4B1E6C9D73DE5AB909E8F3A3668856477CD91EF97444D0B50EA2E549"
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
    /// Asignar_Profundidad
    /// </summary>
    public partial class Asignar_Profundidad : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Asignar_Profundidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_agregar;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Asignar_Profundidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_atras;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Asignar_Profundidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_prof;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Asignar_Profundidad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_prof_mod;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Asignar_Profundidad.xaml"
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
            System.Uri resourceLocater = new System.Uri("/BaseDeDatosCamargo;component/asignar_profundidad.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Asignar_Profundidad.xaml"
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
            this.bt_agregar = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Asignar_Profundidad.xaml"
            this.bt_agregar.Click += new System.Windows.RoutedEventHandler(this.bt_agregar_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bt_atras = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Asignar_Profundidad.xaml"
            this.bt_atras.Click += new System.Windows.RoutedEventHandler(this.bt_atras_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_prof = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lb_prof_mod = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.mem_inf = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

