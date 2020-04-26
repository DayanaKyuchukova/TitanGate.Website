using System.Collections.Generic;
using System.Threading.Tasks;
using TitanGate.Website.Domain.Entities;

namespace TitanGate.Website.DAL.Abstract
{
    public interface IWebSiteRepository : IGenericRepository<WebSite>
    {
        Task<IEnumerable<WebSite>> GetWebSitesAsync();
    }
}
