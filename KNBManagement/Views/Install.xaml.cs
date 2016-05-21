using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace KNBManagement.Views
{
    public partial class Install : Page
    {
        private DispatcherTimer dt = new DispatcherTimer();
        
        public Install()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(InBrowser_Loaded);
            App.Current.InstallStateChanged += new EventHandler(Current_InstallStateChanged);
            dt.Interval = new TimeSpan(500);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
        }

        // ユーザーがこのページに移動したときに実行されます。
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Current.Install();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("すでにインストールされています。");
            }

            CheckInstallStatus();
        }

        void InBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            CheckInstallStatus();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            CheckInstallStatus();
        }

        void Current_InstallStateChanged(object sender, EventArgs e)
        {
            CheckInstallStatus();
        }

        private void CheckInstallStatus()
        {
            switch (App.Current.InstallState)
            {
                case InstallState.NotInstalled:
                    btnInstall.Content = string.Format("クリックしてインストール");
                    btnInstall.IsEnabled = true;
                    break;
                case InstallState.Installed:
                    btnInstall.Content = "インストール済みです";
                    btnInstall.IsEnabled = false;
                    break;
                case InstallState.Installing:
                    btnInstall.Content = "インストール中です";
                    btnInstall.IsEnabled = false;
                    break;
            }
        }

    }
}
