using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var results = BenchmarkRunner.Run<RBMVC>();
        }
    }
}