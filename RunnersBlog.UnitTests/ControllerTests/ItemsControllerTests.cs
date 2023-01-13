using Moq;
using DataAccessLayer.Controllers;
using DataAccessLayer.DTO;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using DataAccessLayer.Services.ItemsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DataAccessLayer.UnitTests.ControllerTests
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
