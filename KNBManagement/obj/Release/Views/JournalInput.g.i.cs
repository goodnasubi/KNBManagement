﻿#pragma checksum "C:\Users\ikeda\Documents\Visual Studio 2010\Projects\KNBManagement\KNBManagement\Views\JournalInput.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1234EB3439962BA0BF87611400D766DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.239
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


namespace KNBManagement.Views {
    
    
    public partial class JournalInput : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock HeaderText;
        
        internal System.Windows.Controls.DomainDataSource companyDomainDataSource;
        
        internal System.Windows.Controls.DomainDataSource journalDomainDataSource;
        
        internal System.Windows.Controls.Border border1;
        
        internal System.Windows.Controls.Grid grid1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/KNBManagement;component/Views/JournalInput.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.HeaderText = ((System.Windows.Controls.TextBlock)(this.FindName("HeaderText")));
            this.companyDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("companyDomainDataSource")));
            this.journalDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("journalDomainDataSource")));
            this.border1 = ((System.Windows.Controls.Border)(this.FindName("border1")));
            this.grid1 = ((System.Windows.Controls.Grid)(this.FindName("grid1")));
        }
    }
}

