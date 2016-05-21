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
using System.ComponentModel;

namespace KNBManagement.Controls
{
    public partial class ModeViewer : UserControl
    {
        public ModeViewer()
        {
            InitializeComponent();

            if (DesignerProperties.IsInDesignTool)
            {
                this.lblAdding.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.lblAdding.Visibility = System.Windows.Visibility.Collapsed;
                this.lblEditting.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        #region IsAdding プロパティ
        
        /// <summary>
        /// 追加中プロパティ
        /// </summary>
        public bool IsAdding
        {
            get { return (bool)GetValue(IsAddingProperty); }
            set { SetValue(IsAddingProperty, value); }
        }

        public static readonly DependencyProperty IsAddingProperty = DependencyProperty.Register(
            "IsAdding",
            typeof(bool),
            typeof(ModeViewer),
            new PropertyMetadata(false, new PropertyChangedCallback(OnIsAddingChanged)));

        private static void OnIsAddingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ModeViewer)d).OnIdAddingChanged(e);
        }

        private void OnIdAddingChanged(DependencyPropertyChangedEventArgs e)
        {

            if (this.IsAdding)
            {
                this.lblAdding.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.lblAdding.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        #endregion

        #region IsEditting プロパティ

        public bool IsEditting
        {
            get { return (bool)GetValue(IsEdittingProperty); }
            set { SetValue(IsEdittingProperty, value); }
        }
        
        #endregion

        public static readonly DependencyProperty IsEdittingProperty = DependencyProperty.Register(
            "IsEditting",
            typeof(bool),
            typeof(ModeViewer),
            new PropertyMetadata(false, new PropertyChangedCallback(OnIsEdittingChanged)));

        private static void OnIsEdittingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ModeViewer)d).OnIsEdittingChanged(e);
        }

        private void OnIsEdittingChanged(DependencyPropertyChangedEventArgs e)
        {

            if (this.IsEditting)
            {
                this.lblEditting.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.lblEditting.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
