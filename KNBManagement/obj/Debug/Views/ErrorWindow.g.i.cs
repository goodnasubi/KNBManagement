﻿#pragma checksum "C:\Users\ikeda\Documents\Visual Studio 2010\Projects\KNBManagement\KNBManagement\Views\ErrorWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "237D03C9B7D2836F6669CE36AE912E12"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.237
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace KNBManagement {
    
    
    public partial class ErrorWindow : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock IntroductoryText;
        
        internal System.Windows.Controls.StackPanel ContentStackPanel;
        
        internal System.Windows.Controls.TextBlock LabelText;
        
        internal System.Windows.Controls.TextBox ErrorTextBox;
        
        internal System.Windows.Controls.Button OKButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/KNBManagement;component/Views/ErrorWindow.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.IntroductoryText = ((System.Windows.Controls.TextBlock)(this.FindName("IntroductoryText")));
            this.ContentStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentStackPanel")));
            this.LabelText = ((System.Windows.Controls.TextBlock)(this.FindName("LabelText")));
            this.ErrorTextBox = ((System.Windows.Controls.TextBox)(this.FindName("ErrorTextBox")));
            this.OKButton = ((System.Windows.Controls.Button)(this.FindName("OKButton")));
        }
    }
}

