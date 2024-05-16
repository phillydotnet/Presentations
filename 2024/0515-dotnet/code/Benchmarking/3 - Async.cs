//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;

//BenchmarkRunner.Run<AsyncBenchmark>();

//[ShortRunJob]
//public class AsyncBenchmark
//{
//    private static void SyncTask(string x)
//    {
//        Console.WriteLine("Start Task " + x);
//        Task.Delay(1000).Wait();
//        Console.WriteLine("Complete Task " + x);
//    }

//    [Benchmark(Baseline = true)]
//    public void Sync()
//    {
//        SyncTask("A");
//        SyncTask("B");
//    }

//    private async static Task AsyncTask(string x)
//    {
//        Console.WriteLine("Start Task " + x);
//        await Task.Delay(1000);
//        Console.WriteLine("Complete Task " + x);
//    }

//    [Benchmark]
//    public async Task Async()
//    {
//        var taskA = AsyncTask("A");
//        var taskB = AsyncTask("B");

//        await taskA;
//        await taskB;
//    }
//}

//| Method  | Mean     | Error     | StdDev    | Ratio  |
//| ------- | -------- | --------- | --------- | ------ |
//| Sync    |  2.023 s |  0.1298 s |  0.0071 s |   1.00 |
//| Async   |  1.001 s |  0.1120 s |  0.0061 s |   0.49 |