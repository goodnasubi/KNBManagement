﻿#pragma checksum "c:\users\ikeda\documents\visual studio 2010\Projects\KNBManagement\KNBManagement\Views\Login\LoginRegistrationWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "70F475C619E908E3989526CFC321AA83"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.237
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using KNBManagement.LoginUI;
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


namespace KNBManagement.LoginUI {
    
    
    public partial class LoginRegistrationWindow : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.ChildWindow childWindow;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal KNBManagement.LoginUI.LoginForm loginForm;
        
        internal KNBManagement.LoginUI.RegistrationForm registrationForm;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/KNBManagement;component/Views/Login/LoginRegistrationWindow.xaml", System.UriKind.Relative));
            this.childWindow = ((System.Windows.Controls.ChildWindow)(this.FindName("childWindow")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.loginForm = ((KNBManagement.LoginUI.LoginForm)(this.FindName("loginForm")));
            this.registrationForm = ((KNBManagement.LoginUI.RegistrationForm)(this.FindName("registrationForm")));
        }
    }
}

