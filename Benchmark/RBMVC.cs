using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class RBMVC
    {
        public readonly BenchmarkLogic benchMarkLogic;
        public RBMVC()
        {
            this.benchMarkLogic = new BenchmarkLogic();
        }
        [Benchmark]
        public void CreateItemBenchmark()
        {
            _ = benchMarkLogic.CreateItemBenchmark();
        }
        [Benchmark]
        public void DeleteItemByIdBenchmark()
        {
            _ = benchMarkLogic.DeleteItemByIdBenchmark();
        }
        [Benchmark]
        public void UpdateItemBenchmark()
        {
            _ = benchMarkLogic.UpdateItemBenchmark();
        }
        [Benchmark]
        public void GetAllItemsBenchmark()
        {
            _ = benchMarkLogic.GetAllItemsBenchmark();
        }
    }
}
