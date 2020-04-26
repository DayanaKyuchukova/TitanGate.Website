using System.Collections.Generic;
using System.Threading.Tasks;
using TitanGate.Website.Service.Models;

namespace TitanGate.Website.Service.Abstract
{
    public interface IWebSiteService
    {
        Task<IEnumerable<WebSiteResponseModel>> GetByFilterAsync(string sortBy, int page, int pageSize);

        Task CreateAsync(WebSiteRequestModel model);

        Task UpdateAsync(int id, WebSiteRequestModel model);

        Task DeleteAsync(int id);
    }
}
