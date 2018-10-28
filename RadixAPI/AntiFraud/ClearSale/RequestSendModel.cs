using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class RequestSendModel
    {
        [Required]
        public string ApiKey { get; set; }

        [Required]
        public string LoginToken { get; set; }

        [Required]
        public Collection<OrderModel> Orders { get; set; }

        /// <summary>
        /// Location of Analysis ( “BRA” to Brazil and “USA” to United States)
        /// </summary>
        [Required]
        public string AnalysisLocation { get; set; }
    }
}
