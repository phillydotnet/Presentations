var sequence = "";
var numbers = Fibonacci().Take(1000);
foreach (var number in numbers)
{
    sequence += number;
    sequence += ", ";
}

Console.WriteLine(sequence);

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