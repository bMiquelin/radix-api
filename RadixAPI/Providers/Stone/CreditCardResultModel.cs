namespace RadixAPI.Providers.Stone
{
    public class CreditCardResultModel
    {
        public string CreditCardBrand { get; set; }
        public string InstantBuyKey { get; set; }
        public bool IsExpiredCreditCard { get; set; }
        public string MaskedCreditCardNumber { get; set; }
    }
}
