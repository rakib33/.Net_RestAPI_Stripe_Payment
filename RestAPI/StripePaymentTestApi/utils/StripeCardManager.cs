using Stripe;
using StripePaymentTestApi.Models;

namespace StripePaymentTestApi.utils
{
    public sealed class StripeCardManager
    {
        public static Token stripeToken;
        private static CardDetails _cardDetails;
        private static string _apiKey;
        public bool StripCardIsValid(CardDetails cardDetails, string apiKey)
        {
            _cardDetails = cardDetails;
            _apiKey = apiKey;
            return CreateCardToken();           
        }


        private bool CreateCardToken()
        {   
            StripeConfiguration.ApiKey = _apiKey;   
            var options1 = new PaymentIntentCreateOptions
            {
                Amount = 500,
                Currency = "gbp",
                PaymentMethod = "pm_card_visa",
            };
            var service1 = new PaymentIntentService();
            try
            {
                service1.Create(options1);
                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                
            }

            return false;
            #region CodeBlock
            // Create a card token
            //var options = new TokenCreateOptions
            //{
            //    Card = new TokenCardOptions
            //    {
            //        Number = _cardDetails.CardNumber,
            //        ExpMonth = _cardDetails.ExpiryMonth,
            //        ExpYear = _cardDetails.ExpiryYear,
            //        Cvc = _cardDetails.CardSecurityCode,                    
            //    },

            //};

            //var service = new TokenService();
            //stripeToken = null;

            //try
            //{
            //    stripeToken = service.Create(options);
            //    Console.WriteLine($"Token created successfully: {stripeToken.Id}");
            //}
            //catch (StripeException ex)
            //{
            //    Console.WriteLine($"Error creating token: {ex.Message}");
            //}
            #endregion
        }

        #region CodeBlock
        //private void Payment()
        //{
        //    // Use the token to create a payment method or charge
        //    if (stripeToken != null)
        //    {
        //        var paymentOptions = new PaymentMethodCreateOptions
        //        {
        //            Type = "card",
        //            Card = new PaymentMethodCardOptions
        //            {
        //                Token = stripeToken.Id
        //            }
        //        };

        //        var paymentService = new PaymentMethodService();
        //        try
        //        {
        //            var paymentMethod = paymentService.Create(paymentOptions);
        //            Console.WriteLine($"Payment method created successfully: {paymentMethod.Id}");
        //        }
        //        catch (StripeException ex)
        //        {
        //            Console.WriteLine($"Error creating payment method: {ex.Message}");
        //        }
        //    }
        //}
        //static void ExampleFunction(PaymentIntentCreateOptions options)
        //{
        //    try
        //    {
        //        var service = new PaymentIntentService();
        //        service.Create(options);
        //        Console.WriteLine("No error.");
        //    }
        //    catch (StripeException e)
        //    {
        //        switch (e.StripeError.Type)
        //        {
        //            case "card_error":
        //                Console.WriteLine($"A payment error occurred: {e.StripeError.Message}");
        //                break;
        //            case "invalid_request_error":
        //                Console.WriteLine("An invalid request occurred.");
        //                break;
        //            default:
        //                Console.WriteLine("Another problem occurred, maybe unrelated to Stripe.");
        //                break;
        //        }
        //    }
        //}
        //private static void Callexample()
        //{
        //    var options = new PaymentIntentCreateOptions
        //    {
        //        Amount = 2000,
        //        // The required parameter Currency is missing
        //        Confirm = true,

        //        PaymentMethod = "pm_card_visa"
        //    };
        //    ExampleFunction(options);
        //}
        #endregion

    }
}
