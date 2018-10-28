using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class RequestAuthModel
    {
        [Required]
        public CredentialsModel Login { get; set; }
    }
}
