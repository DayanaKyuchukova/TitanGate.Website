using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanGate.Website.DAL.Abstract;
using TitanGate.Website.Domain.Entities;
using TitanGate.Website.Service.Abstract;
using TitanGate.Website.Service.Models;

namespace TitanGate.Website.Service.Services
{
    public class WebSiteService : IWebSiteService
    {
        private readonly IWebSiteRepository webSiteRepository;

        public WebSiteService(IWebSiteRepository webSiteRepository)
        {
            this.webSiteRepository = webSiteRepository;
        }

        public async Task<IEnumerable<WebSiteResponseModel>> GetByFilterAsync(
            string sortBy,
            int page,
            int pageSize)
        {
            var webSites = await webSiteRepository.GetWebSitesAsync();

            // sorting
            webSites = SortWebSitesBy(sortBy, webSites);

            // pagination
            webSites = webSites.Skip((page - 1) * pageSize).Take(pageSize);

            return webSites.Select(resp => GetWebSiteResponse(resp));
        }

        public Task CreateAsync(WebSiteRequestModel model)
        {
            var webSite = new WebSite
            {
                Name = model.Name,
                URL = model.URL,
                CategoryId = model.CategoryId,
                HomepageSnapshot = model.HomepageSnapshot,
                LoginId = model.LoginId
            };

            return webSiteRepository.CreateAsync(webSite);
        }

        public async Task UpdateAsync(int id, WebSiteRequestModel model)
        {
            var webSite = await webSiteRepository.GetByIdAsync(id);

            webSite.Name = model.Name;
            webSite.URL = model.URL;
            webSite.CategoryId = model.CategoryId;
            webSite.HomepageSnapshot = model.HomepageSnapshot;
            webSite.LoginId = model.LoginId;

            await webSiteRepository.UpdateAsync(webSite);
        }

        public async Task DeleteAsync(int id)
        {
            var webSite = await webSiteRepository.GetByIdAsync(id);

            await webSiteRepository.SoftDeleteAsync(webSite);
        }

        private static WebSiteResponseModel GetWebSiteResponse(WebSite webSite)
            => new WebSiteResponseModel
            {
                Id = webSite.Id,
                Name = webSite.Name,
                URL = webSite.URL,
                CategoryId = webSite.CategoryId,
                HomepageSnapshot = webSite.HomepageSnapshot,
                LoginId = webSite.LoginId
            };

        private static IEnumerable<WebSite> SortWebSitesBy(string sortBy, IEnumerable<WebSite> webSites)
        {
            if (sortBy != null)
            {
                var existingProperty = new WebSite().GetType().GetProperty(sortBy);

                if (existingProperty != null)
                {
                    webSites = webSites.OrderBy(website => GetPropertyValueByName(website, sortBy));
                }
            }

            return webSites;
        }

        private static object GetPropertyValueByName(WebSite website, string propertyName)
            => website
                .GetType()
                .GetProperty(propertyName)
                .GetValue(website, null);
    }
}
