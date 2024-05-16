//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using System.Buffers;

//BenchmarkRunner.Run<PoolBenchmark>();

//[MemoryDiagnoser, ShortRunJob]
//public class PoolBenchmark
//{
//    [Benchmark(Baseline = true)]
//    public void Array()
//    {
//        // create array
//        var numbers = new UInt128[1000];

//        // initial case
//        numbers[0] = 0;
//        numbers[1] = 1;

//        // generator
//        UInt128 n0 = 0, n1 = 1;
//        for (var i = 2; i < 998; i++)
//        {
//            UInt128 next = n0 + n1;
//            n0 = n1;
//            n1 = next;

//            numbers[i] = next;
//        }
//    }

//    [Benchmark]
//    public void ArrayPool()
//    {
//        // rent array
//        var pool = ArrayPool<UInt128>.Shared;
//        var numbers = pool.Rent(1000);

//        // initial case
//        numbers[0] = 0;
//        numbers[1] = 1;

//        // generator
//        UInt128 n0 = 0, n1 = 1;
//        for (var i = 2; i < 998; i++)
//        {
//            UInt128 next = n0 + n1;
//            n0 = n1;
//            n1 = next;

//            numbers[i] = next;
//        }

//        // return array
//        pool.Return(numbers);
//    }
//}

////| Method     | Mean      | Error      | StdDev     | Ratio  | RatioSD  | Gen0    | Allocated  | Alloc Ratio  |
////| ---------- | --------- | ---------- | ---------- | ------ | -------- | ------- | ---------- | ------------ |
////| Array      | 2.006 us  | 5.8214 us  | 0.3191 us  | 1.00   | 0.00     | 1.9112  | 16024 B    | 1.00         |
////| ArrayPool  | 1.037 us  | 0.1522 us  | 0.0083 us  | 0.53   | 0.09     | -       | -          | 0.00         |
