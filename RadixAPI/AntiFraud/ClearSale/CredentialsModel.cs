using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class CredentialsModel
    {
        [Required]
        public string ApiKey { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public string ClientSecret { get; set; }
    }
}
