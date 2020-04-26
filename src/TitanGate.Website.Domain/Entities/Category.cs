using System.Collections.Generic;

namespace TitanGate.Website.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; }

        public virtual ICollection<WebSite> WebSites { get; set; }
    }
}
