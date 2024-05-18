namespace StripePaymentTestApi.Models
{
    public class CreditDetails
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string NameOnCard { get; set; }
        public string CardSecurityCode { get; set; }
    }
}
