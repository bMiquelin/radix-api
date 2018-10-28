using System.ComponentModel.DataAnnotations;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class ItemModel
    {
        /// <summary>
        /// Product ID
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Unit Price
        /// </summary>
        [Required]
        public decimal ItemValue { get; set; }

        /// <summary>
        /// Quantity Purchased
        /// </summary>
        [Required]
        public int Qty { get; set; }
    }
}
