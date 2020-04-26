using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanGate.Website.DAL.Abstract;
using TitanGate.Website.Domain.Entities;
using TitanGate.Website.Service.Models;
using TitanGate.Website.Service.Services;
using Xunit;

namespace TitanGate.Website.UnitTests.Services
{
    public class WebSiteServiceTests
    {
        private readonly WebSiteService webSiteService;

        private Mock<IWebSiteRepository> webSiteMockRepository;

        public WebSiteServiceTests()
        {
            this.webSiteMockRepository = new Mock<IWebSiteRepository>();
            this.webSiteService = new WebSiteService(this.webSiteMockRepository.Object);
        }

        [Fact]
        public async Task GetByFilterAsync_ShouldInvokeGetByFilterAsync()
        {
            // Arrange
            IEnumerable<WebSite> webSites = new List<WebSite>(){ new WebSite{ Id = 1 } };

            this.webSiteMockRepository.Setup(e => e.GetWebSitesAsync())
                .Returns(Task.FromResult(webSites));

            // Act
            var result = await webSiteService.GetByFilterAsync(It.IsAny<string>(), 1, 5);

            // Assert
            Assert.Equal(webSites.First().Id, result.First().Id);
        }

        [Fact]
        public async Task CreateAsync_ShouldInvokeCreateAsync()
        {
            // Arrange
            var model = new WebSiteRequestModel
            {
                Name = "test Name",
                URL = "URL",
                CategoryId = 1,
                HomepageSnapshot = new byte[] { 1, 2, 3 },
                LoginId = 3
            };

            // Act
            await webSiteService.CreateAsync(model);

            // Assert
            this.webSiteMockRepository.Verify(
                    x => x.CreateAsync(
                        It.Is<WebSite>(
                            y => y.Name == model.Name
                                 && y.URL == model.URL
                                 && y.CategoryId == model.CategoryId
                                 && y.HomepageSnapshot == model.HomepageSnapshot
                                 && y.LoginId == model.LoginId)),
                    Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_ShouldInvokeUpdateAsync()
        {
            // Arrange
            var model = new WebSiteRequestModel
            {
                Name = "test Name",
                URL = "URL",
                CategoryId = 1,
                HomepageSnapshot = new byte[] { 1, 2, 3 },
                LoginId = 3
            };

            var existingWebSite = new WebSite();
            this.webSiteMockRepository.Setup(e => e.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(existingWebSite));

            // Act
            await webSiteService.UpdateAsync(1, model);

            // Assert
            this.webSiteMockRepository.Verify(
                    x => x.UpdateAsync(
                        It.Is<WebSite>(
                            y => y.Name == model.Name
                                 && y.URL == model.URL
                                 && y.CategoryId == model.CategoryId
                                 && y.HomepageSnapshot == model.HomepageSnapshot
                                 && y.LoginId == model.LoginId)),
                    Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_ShouldInvokeDeleteAsync()
        {
            // Arrange
            var existingWebSite = new WebSite();
            this.webSiteMockRepository.Setup(e => e.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(existingWebSite));
            this.webSiteMockRepository.Setup(e => e.SoftDeleteAsync(existingWebSite))
                .Returns(Task.FromResult(existingWebSite.IsDeleted = true));

            // Act
            await webSiteService.DeleteAsync(It.IsAny<int>());

            // Assert
            this.webSiteMockRepository.Verify(
                    x => x.SoftDeleteAsync(
                        It.Is<WebSite>(
                            y => y.IsDeleted == true)),
                    Times.Once());
        }
    }
}
