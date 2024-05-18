using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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

        public async Task<bool> IsValidCreditDetails(CreditDetails creditDetails)
        {
            return true;
        }

        public async Task<bool> SaveCreditDetails(CreditDetails creditDetails)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(creditDetails, Formatting.Indented);
                 _jsonConfig.SaveDataintoJsonFile(jsonData);
                return  true;
            }
            catch (Exception)
            {
              return false;
            }
        }
    }
}
