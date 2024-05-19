using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StripePaymentTestApi.Interfaces;
using StripePaymentTestApi.Models;
using StripePaymentTestApi.utils;

namespace StripePaymentTestApi.Repositories
{
    public class CreditDetailsRepository : ICreditDetails
    {
        private readonly StripeCredential _stripeCredential;
        private readonly IJsonConfig _jsonConfig;
        private readonly StripeCardManager _stripeCardManager;
        public CreditDetailsRepository(IOptions<StripeCredential> options,
                                        IJsonConfig jsonConfig,
                                        StripeCardManager stripeCardManager)
        {
            _stripeCredential = options.Value;
            _jsonConfig = jsonConfig;
            _stripeCardManager = stripeCardManager;
        }

        public async Task<bool> IsValidCreditDetails(CardDetails creditDetails)
        {

            bool isValidCard = _stripeCardManager.StripCardIsValid(creditDetails, _stripeCredential.SecretKey);
            return isValidCard;
        }

        public async Task<bool> SaveCreditDetails(CardDetails creditDetails)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(creditDetails, Formatting.Indented);
                _jsonConfig.SaveDataintoJsonFile(jsonData);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
