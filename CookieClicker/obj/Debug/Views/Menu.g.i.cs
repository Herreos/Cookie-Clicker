﻿#pragma checksum "..\..\..\Views\Menu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D7D0A3EA9A2701373F0DE40C485BF0764609D3F8606AC57F0EBE4A3E7FED3914"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using CookieClicker.Views;
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


namespace CookieClicker.Views {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Views\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MenuContinueButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MenuNewGameButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InstructionButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CookieClicker;component/views/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Menu.xaml"
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
            this.MenuContinueButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Views\Menu.xaml"
            this.MenuContinueButton.Click += new System.Windows.RoutedEventHandler(this.MenuContinueButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MenuNewGameButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Views\Menu.xaml"
            this.MenuNewGameButton.Click += new System.Windows.RoutedEventHandler(this.MenuNewGameButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.InstructionButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Views\Menu.xaml"
            this.InstructionButton.Click += new System.Windows.RoutedEventHandler(this.InstructionButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

