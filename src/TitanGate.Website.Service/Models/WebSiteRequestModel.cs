using System.ComponentModel.DataAnnotations;

namespace TitanGate.Website.Service.Models
{
    public class WebSiteRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public byte[] HomepageSnapshot { get; set; }

        [Required]
        public int LoginId { get; set; }
    }
}
