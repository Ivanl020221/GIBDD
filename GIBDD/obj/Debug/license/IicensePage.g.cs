﻿#pragma checksum "..\..\..\license\IicensePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "078ADC37E1B602FCF105CF335C845450CCB8757096FA9E0F358C1EBDD24B30C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GIBDD.license;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace GIBDD.license {
    
    
    /// <summary>
    /// IicensePage
    /// </summary>
    public partial class IicensePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\license\IicensePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost IicenseMask;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\license\IicensePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame IicenseFrame;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\license\IicensePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Gifts;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\license\IicensePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeReq;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\license\IicensePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock status;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\license\IicensePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkRequest;
        
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
            System.Uri resourceLocater = new System.Uri("/GIBDD;component/license/iicensepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\license\IicensePage.xaml"
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
            this.IicenseMask = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 2:
            this.IicenseFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.Gifts = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\license\IicensePage.xaml"
            this.Gifts.Click += new System.Windows.RoutedEventHandler(this.GetNew);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TypeReq = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.status = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.OkRequest = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\license\IicensePage.xaml"
            this.OkRequest.Click += new System.Windows.RoutedEventHandler(this.EventReq);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

