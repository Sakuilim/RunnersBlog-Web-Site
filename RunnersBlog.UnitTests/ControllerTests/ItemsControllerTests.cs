using DataAccessLayer.Controllers;
using Moq;
using RunnersBlogMVC.Services.ItemsServices;

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
