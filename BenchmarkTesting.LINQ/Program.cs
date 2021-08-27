using BenchmarkDotNet.Running;
using Bogus;
using System;

namespace BenchmarkTesting.LINQ
{
    public class Program
    {
        static void Main()
        {
            Randomizer.Seed = new Random(420);

            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
