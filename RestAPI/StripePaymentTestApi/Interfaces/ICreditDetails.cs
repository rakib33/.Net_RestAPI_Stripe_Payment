using StripePaymentTestApi.Models;

namespace StripePaymentTestApi.Interfaces
{
    public interface ICreditDetails
    {
      Task<bool> SaveCreditDetails(CreditDetails creditDetails);
      Task<bool> IsValidCreditDetails(CreditDetails creditDetails);    
    }
}
