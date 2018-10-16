using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheraotCoreAsyncExample
{
    class Program
    {
        static readonly TimeSpan WaitTime = TimeSpan.FromSeconds(20);
        static async Task Main(string[] args)
        {
            var listener = new TextWriterTraceListener(Console.Out);
            Trace.Listeners.Add(listener);
            using (var TokenSource = new CancellationTokenSource())
            using(ConsoleUtils.SetConsoleCtrl.Create(type => {
                TokenSource?.Cancel();
                return false;
            }))
                await MainAction(TokenSource.Token);

        }
        static async Task MainAction(CancellationToken Token)
        {
            DateTime StartTime = DateTime.Now;
            await Task.Factory.StartNew(() => Task2Action(StartTime, Token)).Unwrap();
            Trace.WriteLine($"Task1 {DateTime.Now - StartTime}");
            await Task.Run(() => Task4Action(StartTime, Token));
            Trace.WriteLine($"Task3 {DateTime.Now - StartTime}");
        }
        static async Task Task2Action(DateTime StartTime, CancellationToken Token)
        {
            await TaskEx.Delay(WaitTime, Token);
            Trace.WriteLine($"Task2 {DateTime.Now - StartTime}");
        }
        static async Task Task4Action(DateTime StartTime, CancellationToken Token)
        {
            await TaskEx.Delay(WaitTime, Token);
            Trace.WriteLine($"Task4 {DateTime.Now - StartTime}");
        }
    }
}
