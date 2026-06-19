using System.Diagnostics;

class Program
{
    static void Main()
    {
        var data = GenerateData(2_000_000);

        var stopwatch = Stopwatch.StartNew();

        var result = ProcessData(data);

        stopwatch.Stop();

        Console.WriteLine($"Result: {result}");
        Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");
    }

    static List<int> GenerateData(int size)
    {
        var random = new Random();

        return Enumerable.Range(0, size)
            .Select(_ => random.Next(1, 5000))
            .ToList();
    }

    static int ProcessData(List<int> data)
    {
        int count = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        long sum = 0;

        for (int i = 0; i < data.Count; i++)
        {
            var value = data[i];
            if (value % 2 == 0 && value > 1000)
            {
                count++;
                sum += value;
                if (value > max) max = value;
                if (value < min) min = value;
            }
        }

        var average = count > 0 ? (int)(sum / count) : 0;
        return count + max + min + average;
    }
}