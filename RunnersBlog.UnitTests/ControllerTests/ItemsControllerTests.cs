using Moq;
using RunnersBlogMVC.Controllers;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services;
using RunnersBlogMVC.Services.ItemsServices;
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
        private readonly Mock<IItemsService> mockItemService;
        public ItemsControllerTests(Mock<IItemsService> mockItemService)
        {
            this.mockItemService = new Mock<IItemsService>();
        }
        public ItemsController GetSut()
            => new(mockItemService.Object);
    }
}
