namespace ConsoleUtils
{
    /// <summary>
    /// 終了を試みたタイプ
    /// </summary>
    public enum CtrlTypes
    {
        /// <summary>
        /// Ctrl+Cが押された
        /// </summary>
        CTRL_C_EVENT = 0,
        /// <summary>
        /// ブレイクイベントが起こった
        /// </summary>
        CTRL_BREAK_EVENT = 1,
        /// <summary>
        /// 閉じようとした
        /// </summary>
        CTRL_CLOSE_EVENT = 2,
        /// <summary>
        /// ログオフしようとした
        /// </summary>
        CTRL_LOGOFF_EVENT = 5,
        /// <summary>
        /// シャットダウンを試みられた
        /// </summary>
        CTRL_SHUTDOWN_EVENT = 6,
    }
}
