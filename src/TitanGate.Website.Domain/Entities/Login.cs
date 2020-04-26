using System.Collections.Generic;

namespace TitanGate.Website.Domain.Entities
{
    public class Login : BaseEntity<int>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<WebSite> WebSites { get; set; }
    }
}
