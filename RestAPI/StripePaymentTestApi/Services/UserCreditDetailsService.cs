using StripePaymentTestApi.Interfaces;
using StripePaymentTestApi.Models;
using StripePaymentTestApi.utils;
using System.Net;

namespace StripePaymentTestApi.Services
{
    public class UserCreditDetailsService
    {
        private readonly ICreditDetails _creditDetails;
        public UserCreditDetailsService(ICreditDetails creditDetails)
        { 
         _creditDetails = creditDetails;
        }

        public async Task<string> SaveCreditDetailsInfoToJsonFile(CreditDetails creditDetails)
        {
            if(await _creditDetails.IsValidCreditDetails(creditDetails))
            {
                if (await _creditDetails.SaveCreditDetails(creditDetails))
                    return ResponseStatus.Credit_Details_Save_Code;
                else
                    return ResponseStatus.Credit_Details_Save_Failed_Code;
            }

            return ResponseStatus.Credit_Details_Invalid_Code;
        }
    }
}
