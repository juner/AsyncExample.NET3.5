using System;

namespace ConsoleUtils
{
    public class SetConsoleCtrl : IDisposable
    {
        public static SetConsoleCtrl Create(Func<CtrlTypes, bool> ConsoleCtrl) => new SetConsoleCtrl(ConsoleCtrl);
        readonly NativeMethods.HandlerRoutine ConsoleCtrl;
        protected SetConsoleCtrl(Func<CtrlTypes, bool> ConsoleCtrl)
        {
            this.ConsoleCtrl = new NativeMethods.HandlerRoutine(ConsoleCtrl);
            NativeMethods.SetConsoleCtrlHandler(this.ConsoleCtrl, true);
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    var result = NativeMethods.SetConsoleCtrlHandler(ConsoleCtrl, false);
                }
                disposedValue = true;
            }
        }
        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose() => Dispose(true);
        #endregion
    }
}
