using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TitanGate.Website.Api.Controllers;
using TitanGate.Website.Service.Abstract;
using TitanGate.Website.Service.Models;
using Xunit;

namespace TitanGate.Website.UnitTests.Controllers
{
    public class WebSiteControllerTests
    {
        private readonly WebSiteController webSiteController;
        private readonly Mock<IWebSiteService> webSiteService;

        public WebSiteControllerTests()
        {
            this.webSiteService = new Mock<IWebSiteService>();
            this.webSiteController = new WebSiteController(this.webSiteService.Object);
        }

        [Fact]
        public async Task GetByFilterAsync_ShouldInvokeGetByFilterAsync()
        {
            // Arrange
            IEnumerable<WebSiteResponseModel> webSites = new List<WebSiteResponseModel>() { new WebSiteResponseModel { Id = 1 } };
            this.webSiteService.Setup(e => e.GetByFilterAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(webSites));

            // Act
            var result = await webSiteController.GetByFilterAsync(It.IsAny<string>(), 1, 5);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(webSites, ((OkObjectResult)result).Value);
            this.webSiteService.Verify(x => x.GetByFilterAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public async Task CreateAsync_ShouldInvokeCreateAsync()
        {
            // Act
            var result = await webSiteController.CreateAsync(It.IsAny<WebSiteRequestModel>());

            // Assert
            Assert.IsType<OkResult>(result);
            this.webSiteService.Verify(x => x.CreateAsync(It.IsAny<WebSiteRequestModel>()), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_ShouldInvokeUpdateAsync()
        {
            // Act
            var result = await webSiteController.UpdateAsync(It.IsAny<int>(), It.IsAny<WebSiteRequestModel>());

            // Assert
            Assert.IsType<NoContentResult>(result);
            this.webSiteService.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<WebSiteRequestModel>()), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_ShouldInvokeDeleteAsync()
        {
            // Act
            var result = await webSiteController.DeleteAsync(It.IsAny<int>());

            // Assert
            Assert.IsType<NoContentResult>(result);
            this.webSiteService.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once());
        }
    }
}
