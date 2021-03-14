using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SampleClass
    {
        public static void Run(DateTime date, Action<CancellationToken> action)
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            var a = Task.Run(() => action(token), token);
            var b = Watcher(source, date);

            Task.WhenAll(a, b).GetAwaiter().GetResult();
        }

        private static async Task Watcher(CancellationTokenSource source, DateTime date)
        {
            var sub = new TimeSpan(0, 0, 0, 0, 200);
            var time = date - DateTime.Now;
            time -= sub;
            await Task.Delay(time);

            while(true)
            {
                if (DateTime.Now >= date)
                {
                    source.Cancel();
                    break;
                }
                await Task.Delay(100);
            }
        }
    }
}
