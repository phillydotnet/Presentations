//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using System.Numerics;
//using System.Runtime.InteropServices;

//BenchmarkRunner.Run<LoopBenchmark>();

//[MemoryDiagnoser]
//public class LoopBenchmark
//{
//    int[] numbers;

//    [GlobalSetup]
//    public void Setup()
//    {
//        numbers = Enumerable.Range(1, 1000).ToArray();
//    }

//    [Benchmark(Baseline = true)]
//    public void SumForEach()
//    {
//        var sum = 0;
//        foreach (var n in numbers) {
//            sum += n;
//        }
//    }

//    [Benchmark]
//    public void SumFor()
//    {
//        var sum = 0;
//        for (int i = 0; i < numbers.Length; i++) {
//            sum += numbers[i];
//        }
//    }
//    // why? see https://www.c-sharpcorner.com/article/c-sharp-performance-of-code-for-loop-vs-for-each-loop/
//    // https://sharplab.io/#v2:CYLg1APgAgDABFAjAOgDIEsB2BHA3HAWAChiA3AQwCc5MBXAWwCMBTSgZzgF44BRO+1uUYAbZsgBK5TAHNmACkQAaOIhhqAlMgAqAewCClSuQCec9bmJkqcNgwBiOyj3IBjABZc4MC0QBmj5lcPOQpqTDgsGgYWdnViAG9iOGSbe0dndzgwbkwfAF9LIlDU+gdqbm9if2o5LAAXCM9vRoAeKKZWNjRmGTq3fHQwMDiiRKIUkrKsnOjOgG10AF18oA===

//    [Benchmark]
//    public void SumLINQ()
//    {
//        var sum = numbers.Sum();
//    }

//    [Benchmark]
//    public void SumSpanForSIMD()
//    {
//        // cast the array to vectors without copying
//        var numbersSpan = numbers.AsSpan();
//        var vectors = MemoryMarshal.Cast<int, Vector<int>>(numbersSpan);

//        // add each vector to the sum vector
//        var sumVector = Vector<int>.Zero;
//        foreach (ref readonly var vector in vectors) {
//            sumVector += vector;
//        }

//        // compute
//        var sum = Vector.Sum(sumVector);

//        // find what elements of the source were left out
//        var remainder = numbersSpan.Length % Vector<int>.Count;
//        numbersSpan = numbersSpan[^remainder..];
//        foreach (ref readonly var value in numbersSpan) {
//            sum += value;
//        }

//        // adapted from https://antao-almada.medium.com/single-instruction-multiple-data-simd-in-net-393b8cf9a90
//    }
//}