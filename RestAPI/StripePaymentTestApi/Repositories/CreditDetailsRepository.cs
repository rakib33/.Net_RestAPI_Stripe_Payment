using Microsoft.Extensions.Options;
using StripePaymentTestApi.Interfaces;
using StripePaymentTestApi.Models;

namespace StripePaymentTestApi.Repositories
{
    public class CreditDetailsRepository : ICreditDetails
    {
        private readonly StripeCredential _stripeCredential;   
        private readonly IJsonConfig _jsonConfig;
        public CreditDetailsRepository(IOptions<StripeCredential> options , IJsonConfig jsonConfig) { 
         _stripeCredential = options.Value;
         _jsonConfig = jsonConfig;
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
