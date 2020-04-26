using System.Collections.Generic;
using System.Threading.Tasks;
using TitanGate.Website.DAL.Abstract;
using TitanGate.Website.Domain.Entities;

namespace TitanGate.Website.DAL.Repositories
{
    public class WebSiteRepository : GenericRepository<WebSite>, IWebSiteRepository
    {
        public WebSiteRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Task<IEnumerable<WebSite>> GetWebSitesAsync()
            => QueryAsync(ws => ws.IsDeleted == false);
    }
}
