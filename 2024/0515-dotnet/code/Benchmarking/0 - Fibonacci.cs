using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

BenchmarkRunner.Run<IteratorBenchmark>();

[MemoryDiagnoser]
public class IteratorBenchmark
{
    [Benchmark(Baseline = true)]
    public void Original()
    {
        var sequence = "";
        var numbers = Fibonacci().Take(1000);
        foreach (var number in numbers)
        {
            sequence += number;
            sequence += ", ";
        }

        static IEnumerable<UInt128> Fibonacci()
        {
            // initial case
            yield return 0;
            yield return 1;

            // generator
            UInt128 n0 = 0, n1 = 1;
            while (true)
            {
                UInt128 next = n0 + n1;
                n0 = n1;
                n1 = next;

                yield return next;
            }
        }
    }

    [Benchmark]
    public void StringBuilder()
    {
        var sequence = new StringBuilder();
        var numbers = Fibonacci().Take(1000);
        foreach (var number in numbers)
        {
            sequence.Append(number);
            sequence.Append(", ");
        }
        var output = sequence.ToString();

        static IEnumerable<UInt128> Fibonacci()
        {
            // initial case
            yield return 0;
            yield return 1;

            // generator
            UInt128 n0 = 0, n1 = 1;
            while (true)
            {
                UInt128 next = n0 + n1;
                n0 = n1;
                n1 = next;

                yield return next;
            }
        }
    }

    [Benchmark]
    public void StringBuilderNoIterator()
    {
        var sequence = new StringBuilder();

        // initial case
        sequence.Append(0);
        sequence.Append(", ");

        sequence.Append(1);
        sequence.Append(", ");

        // generator
        UInt128 n0 = 0, n1 = 1;
        for (int i = 2; i < 998; i++)
        {
            UInt128 next = n0 + n1;
            n0 = n1;
            n1 = next;

            sequence.Append(next);
            sequence.Append(", ");
        }

        var output = sequence.ToString();
    }
}