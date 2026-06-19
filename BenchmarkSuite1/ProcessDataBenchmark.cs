using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.VSDiagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

[CPUUsageDiagnoser]
public class ProcessDataBenchmark
{
    private List<int> _data;
    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(42);
        _data = Enumerable.Range(0, 2_000_000).Select(_ => random.Next(1, 5000)).ToList();
    }

    [Benchmark]
    public int ProcessData_Original()
    {
        var filtered = _data.Where(x => x % 2 == 0).Where(x => x > 1000);
        var count = filtered.Count();
        var max = filtered.Max();
        var min = filtered.Min();
        var average = (int)filtered.Average();
        return count + max + min + average;
    }

    [Benchmark]
    public int ProcessData_Optimized()
    {
        var filtered = _data
            .Where(x => x % 2 == 0)
            .Where(x => x > 1000)
            .ToArray();

        var count = filtered.Length;
        var max = filtered.Max();
        var min = filtered.Min();
        var average = (int)filtered.Average();

        return count + max + min + average;
    }

    [Benchmark]
    public int ProcessData_Loop()
    {
        int count = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        long sum = 0;

        for (int i = 0; i < _data.Count; i++)
        {
            var value = _data[i];
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