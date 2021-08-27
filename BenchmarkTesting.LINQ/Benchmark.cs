using BenchmarkDotNet.Attributes;

namespace BenchmarkTesting.LINQ
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private readonly LINQTesting testClassHelper = new();

        [Benchmark]
        public int StudentsCountWithWhereExpression() => testClassHelper.StudentsCountWithWhereExpression();

        [Benchmark]
        public int StudentsCountWithOnlyCountExpression() => testClassHelper.StudentsCountWithOnlyCountExpression();

        [Benchmark]
        public int StudentsCountWithFor() => testClassHelper.StudentsCountWithFor();

        [Benchmark]
        public int StudentsCountWithForEach() => testClassHelper.StudentsCountWithForEach();

        [Benchmark]
        public Person GetPersonWithWhereExperession() => testClassHelper.GetPersonWithWhereExperession();

        [Benchmark]
        public Person GetPersonWithOnlySingleExpression() => testClassHelper.GetPersonWithOnlySingleExpression();
    }
}
