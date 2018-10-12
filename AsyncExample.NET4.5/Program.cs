using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExampleNET45
{
    class Program
    {
        static readonly TimeSpan WaitTime = TimeSpan.FromSeconds(1);
        static async Task Main(string[] args)
        {
            var listener = new TextWriterTraceListener(Console.Out);
            Trace.Listeners.Add(listener);
            using (var TokenSource = new CancellationTokenSource())
            using (ConsoleUtils.SetConsoleCtrl.Create(type => {
                TokenSource?.Cancel();
                return false;
            }))
                await MainRoop(TokenSource.Token);
        }
        static async Task MainRoop(CancellationToken Token)
        {
            uint Number = 0;
            var FriendlyName = System.AppDomain.CurrentDomain.FriendlyName;
            Trace.WriteLine($"{FriendlyName} Start");
            while (!Token.IsCancellationRequested)
            {
                try
                {
                    Trace.WriteLine($"{FriendlyName} {nameof(WaitTime)} {Number++}");
                    await Task.Delay(WaitTime, Token);
                }
                catch (OperationCanceledException)
                {
                    Trace.WriteLine($"{FriendlyName} Cancel");
                }
            }
            Trace.WriteLine($"{FriendlyName} End");
        }
    }
}
