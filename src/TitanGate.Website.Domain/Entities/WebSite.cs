namespace TitanGate.Website.Domain.Entities
{
    public class WebSite : BaseEntity<int>, IDeletable
    {
        public string Name { get; set; }

        public string URL { get; set; }

        public int CategoryId { get; set; }

        public byte[] HomepageSnapshot { get; set; }

        public int LoginId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; }

        public virtual Login Login { get; set; }
    }
}
