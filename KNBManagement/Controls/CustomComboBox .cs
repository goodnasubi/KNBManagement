using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace KNBManagement.Controls
{
    /// <summary>
    /// <see cref="ComboBox"/> の不具合回避クラス
    /// </summary>
    public class CustomComboBox : ComboBox
    {
        //初期化直後のBindingを取得または設定します。
        public Binding OriginalSelectedValueBinding { get; set; }

        //コンストラクタです。
        public CustomComboBox()
            : base()
        {
            DefaultStyleKey = typeof(ComboBox);

            Loaded += new RoutedEventHandler(CustomComboBox_Loaded);
        }

        void CustomComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //BindingExpressionを取得します。
            var be = GetBindingExpression(SelectedValueProperty);

            if (be != null && OriginalSelectedValueBinding == null)
            {
                //Bindingを取得します。
                OriginalSelectedValueBinding = be.ParentBinding;
            }
        }

        //ItemsCollectionが変更された場合の処理です。
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            if (OriginalSelectedValueBinding != null)
            {
                //SelectedValueのデータバインドを設定します。
                SetBinding(SelectedValueProperty, OriginalSelectedValueBinding);
            }
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            try
            {
                base.PrepareContainerForItemOverride(element, item);
            }
            catch (System.Exception e)
            {
                
                throw e;
            }

        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
        }
    }
}
