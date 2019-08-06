using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DotnetAsync2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Stopwatch watch = new Stopwatch();
            watch.Start();

            //Console.WriteLine("Example1 - no wait");
            //RunExample1(watch);
            /*
            RunAsync10s Start!: 00:00:00.0009318
            RunAsync7s Start!: 00:00:00.0031089
            RunAsync3s Start!: 00:00:00.0038067
            ALL DONE! 00:00:00.0038817
            RunAsync3s Done!: 00:00:03.0044667
            RunAsync7s Done!: 00:00:07.0040369
            RunAsync10s Done!: 00:00:10.0017448
            Final: 00:00:12.2381675
            */

            //Console.WriteLine("Example2 - wait, called with no wait");
            //RunExample2(watch);
            /*
            RunAsync10s Start!: 00:00:00.0013178
            ALL DONE! 00:00:00.0029442
            RunAsync10s Done!: 00:00:10.0029396
            RunAsync7s Start!: 00:00:10.0048529
            RunAsync7s Done!: 00:00:17.0063805
            RunAsync3s Start!: 00:00:17.0082551
            RunAsync3s Done!: 00:00:20.0091404
            Final: 00:00:22.9761675
            */

            //Console.WriteLine("Example2 - wait, called with wait");
            //await RunExample2(watch);
            /*
            RunAsync10s Start!: 00:00:00.0013146
            RunAsync10s Done!: 00:00:10.0021543
            RunAsync7s Start!: 00:00:10.0041034
            RunAsync7s Done!: 00:00:17.0055400
            RunAsync3s Start!: 00:00:17.0073895
            RunAsync3s Done!: 00:00:20.0084613
            ALL DONE! 00:00:20.0085784
            Final: 00:00:22.5927585
            */

            //Console.WriteLine("Example3 - WhenAll");
            //await RunExample3(watch);
            /*
            RunAsync10s Start!: 00:00:00.0018251
            RunAsync7s Start!: 00:00:00.0034897
            RunAsync3s Start!: 00:00:00.0040749
            RunAsync3s Done!: 00:00:03.0068816
            RunAsync7s Done!: 00:00:07.0077645
            RunAsync10s Done!: 00:00:10.0025321
            Completed RunAsync10
            Completed RunAsync7
            Completed RunAsync3
            ALL DONE! 00:00:10.0027409
            Final: 00:00:11.1752193
            */

            Console.WriteLine("Example4 - Result");
            RunExample4(watch);
            /*
            RunAsync10s Start!: 00:00:00.0008287
            RunAsync10s Done!: 00:00:10.0020883
            RunAsync7s Start!: 00:00:10.0039718
            RunAsync7s Done!: 00:00:17.0081551
            RunAsync3s Start!: 00:00:17.0096466
            RunAsync3s Done!: 00:00:20.0105567
            ALL DONE! 00:00:20.0106627
            Final: 00:00:21.9910794            
            */

            Console.WriteLine($"ALL DONE! {watch.Elapsed}");
            Console.Read();
            watch.Stop();
            Console.WriteLine($"Final: {watch.Elapsed}");
        }


        public static void RunExample1(Stopwatch watch)
        {
            RunAsync10s(watch);

            RunAsync7s(watch);

            RunAsync3s(watch);
        }

        public static async Task RunExample2(Stopwatch watch)
        {
            await RunAsync10s(watch);

            await RunAsync7s(watch);

            await RunAsync3s(watch);
        }

        public static async Task RunExample3(Stopwatch watch)
        {
            List<Task<int>> tasks = new List<Task<int>>();
            tasks.Add(RunAsync10s(watch));
            tasks.Add(RunAsync7s(watch));
            tasks.Add(RunAsync3s(watch));

            var results = await Task.WhenAll(tasks);

            foreach(var result in results)
            {
                Console.WriteLine($"Completed RunAsync{result.ToString()}");
            }
        }

        public static void RunExample4(Stopwatch watch)
        {
            var a = RunAsync10s(watch).Result;

            var b = RunAsync7s(watch).Result;

            var c = RunAsync3s(watch).Result;
        }

        public static async Task<int> RunAsync10s(Stopwatch watch)
        {
            Console.WriteLine($"RunAsync10s Start!: {watch.Elapsed}");
            await Task.Delay(10000);
            Console.WriteLine($"RunAsync10s Done!: {watch.Elapsed}");
            return 10;
        }
        public static async Task<int> RunAsync7s(Stopwatch watch)
        {
            Console.WriteLine($"RunAsync7s Start!: {watch.Elapsed}");
            await Task.Delay(7000);
            Console.WriteLine($"RunAsync7s Done!: {watch.Elapsed}");
            return 7;
        }
        public static async Task<int> RunAsync3s(Stopwatch watch)
        {
            Console.WriteLine($"RunAsync3s Start!: {watch.Elapsed}");
            await Task.Delay(3000);
            Console.WriteLine($"RunAsync3s Done!: {watch.Elapsed}");
            return 3;
        }
    }
}
