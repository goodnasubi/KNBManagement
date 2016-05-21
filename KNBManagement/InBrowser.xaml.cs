namespace KNBManagement
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    public partial class InBrowser : UserControl
    {
        private DispatcherTimer dt = new DispatcherTimer();
        public InBrowser()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(InBrowser_Loaded);
            App.Current.InstallStateChanged += new EventHandler(Current_InstallStateChanged);
            dt.Interval = new TimeSpan(500);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            tbStatus.Text = DateTime.Now.ToString();
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

        void InBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            CheckInstallStatus();
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
    }
}
