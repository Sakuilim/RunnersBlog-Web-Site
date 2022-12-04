using Moq;
using RunnersBlogMVC.Controllers;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests.ControllerTests
{
    public class ItemsControllerTests
    {
        private readonly Mock<IBaseService<Item, ItemDto>> mockItemService;
        private readonly CancellationToken cancellationToken;
        public ItemsControllerTests(IBaseService<Item, ItemDto> mockItemService)
        {
            this.mockItemService = new Mock<IBaseService<Item, ItemDto>>();
            cancellationToken = new CancellationToken();
        }
        public ItemsController GetSut()
            => new(mockItemService.Object);
    }
}
