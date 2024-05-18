using Microsoft.Extensions.Options;
using StripePaymentTestApi.Interfaces;
using StripePaymentTestApi.Models;

namespace StripePaymentTestApi.Repositories
{
    public class CreditDetailsRepository : ICreditDetails
    {
        private readonly StripeCredential _stripeCredential;      
        public CreditDetailsRepository(IOptions<StripeCredential> options) { 
         _stripeCredential = options.Value;
        }      

        public Task<bool> IsValidCreditDetails(CreditDetails creditDetails)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveCreditDetails(CreditDetails creditDetails)
        {
            throw new NotImplementedException();
        }
    }
}
