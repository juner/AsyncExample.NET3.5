using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUtils
{
    static class NativeMethods
    {
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);
        /// <summary>
        /// コンソールのコントロールが呼ばれた時のハンドラ
        /// </summary>
        /// <param name="Handler"></param>
        /// <param name="Add"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
    }
}
