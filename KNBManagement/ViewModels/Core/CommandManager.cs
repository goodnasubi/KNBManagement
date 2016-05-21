namespace KNBManagement.ViewModels.Core
{
    using System;

    /// <summary>
    /// コマンドを管理します。
    /// </summary>
    public static class CommandManager
    {
        public static event EventHandler RequerySuggested;

        /// <summary>
        /// <see cref="RequerySuggested"/> イベントを発生させます。
        /// </summary>
        public static void FireRequerySuggested()
        {
            var handler = RequerySuggested;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }
    }
}
