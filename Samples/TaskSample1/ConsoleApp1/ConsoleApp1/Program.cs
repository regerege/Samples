using System;
using System.Threading;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var start = DateTime.Now;
            var end = start.AddMinutes(1.0);

            Console.WriteLine("開始時刻: {0:HH:mm.ss.fff}, 終了時刻: {1:HH:mm.ss.fff}", start, end);

            SampleClass.Run(end, Action);

            Console.WriteLine("開始時刻: {0:HH:mm.ss.fff}, 終了時刻: {1:HH:mm.ss.fff}", start, end);
        }

        // 重たい処理
        private static void Action(CancellationToken token)
        {
            for (var i = 0; i <= Int32.MaxValue; i++)
            {
                if (token.IsCancellationRequested) return;      // 1step 事に入れること。

                Console.WriteLine("[{0:HH:mm.ss.fff}] 処理{1}", DateTime.Now, i);

                if (token.IsCancellationRequested) return;      // 1step 事に入れること。
            }
        }
    }
}
