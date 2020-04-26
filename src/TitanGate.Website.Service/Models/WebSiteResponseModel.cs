namespace TitanGate.Website.Service.Models
{
    public class WebSiteResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public int CategoryId { get; set; }

        public byte[] HomepageSnapshot { get; set; }

        public int LoginId { get; set; }
    }
}
