using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace KNBManagement.ViewModels.Core
{
    public class RelayPropertyObject : DependencyObject
    {
        /// <summary>
        /// 何でも中継するためにObjectで定義します。
        /// </summary>
        public object RelayProperty
        {
            get { return (object)GetValue(RelayPropertyProperty); }
            set { SetValue(RelayPropertyProperty, value); }
        }

        public static readonly DependencyProperty RelayPropertyProperty =
            DependencyProperty.Register(
            "RelayProperty", typeof(object), typeof(RelayPropertyObject), new PropertyMetadata(null));
    }
}
