using StripePaymentTestApi.Models;

namespace StripePaymentTestApi.Interfaces
{
    public interface ICreditDetails
    {
      Task<bool> SaveCreditDetails(CardDetails creditDetails);
      Task<bool> IsValidCreditDetails(CardDetails creditDetails);    
    }
}
