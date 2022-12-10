using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public class BenchmarkLogic
    {
        private ItemsService itemsService;

        [GlobalSetup]
        public void Setup()
        {
            var cancellationToken = new CancellationToken();

            var mockDependency = new Mock<IBaseService<Item, ItemDto>>();

            var mockItemsRepository = new Mock<IItemsRepository>();

            mockDependency.Setup(x => x.CreateAsync(It.IsAny<ItemDto>(), cancellationToken )).Returns((Task<IActionResult>)It.IsAny<IActionResult>());
            mockDependency.Setup(x => x.DeleteByIdAsync(It.IsAny<Guid>(), cancellationToken)).Returns(It.IsAny<Task<ActionResult<Item>>>());
            mockDependency.Setup(x => x.UpdateByIdAsync(It.IsAny<Guid>(), It.IsAny<ItemDto>(), cancellationToken)).Returns((Task<IActionResult>)It.IsAny<IActionResult>());
            mockDependency.Setup(x => x.GetAllAsync(cancellationToken)).Returns((Task<IActionResult>)It.IsAny<IActionResult>());

            itemsService = new ItemsService(mockItemsRepository.Object);
        }
        [Benchmark]
        public async Task CreateItemBenchmark()
        {
            var cancellationToken = new CancellationToken();
            var item = new ItemDto
            {
                Name = "Test",
                Price = 1M
            };

            await itemsService.CreateAsync(item, cancellationToken);
        }
        [Benchmark]
        public async Task DeleteItemByIdBenchmark()
        {
            var cancellationToken = new CancellationToken();
            var mockGuid = Guid.NewGuid();

            await itemsService.DeleteByIdAsync(mockGuid, cancellationToken);
        }
        [Benchmark]
        public async Task UpdateItemBenchmark()
        {
            var cancellationToken = new CancellationToken();
            var item = new ItemDto
            {
                Name = "Test",
                Price = 1M
            };
            var mockGuid = Guid.NewGuid();

            await itemsService.UpdateByIdAsync(mockGuid, item, cancellationToken);
        }
        [Benchmark]
        public async Task GetAllItemsBenchmark()
        {
            var cancellationToken = new CancellationToken();

            await itemsService.GetAllAsync(cancellationToken);
        }
    }
}
