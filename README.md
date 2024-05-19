# .Net 6 Rest API Stripe Payment gateway Test

This sample project contains stripe payment system test using .Net core rest api 

## .Net Core rest API project Create

 - Open visual studio 2022 . New -> Create Project

    ![image](https://github.com/rakib33/.Net_RestAPI_Stripe_Payment/assets/10026710/1e6a532c-fb4a-4870-b77b-aa630756284c)
 
 - In the next page give project Name and others information and Create the project. 

   ![image](https://github.com/rakib33/.Net_RestAPI_Stripe_Payment/assets/10026710/6b456a2b-32ad-4cfd-8071-30aa6e354c07)
 
 - Install Stripe.Net from nuget package manager.
 - Create a Model CardDetails in Models folder

    ```
    public class CardDetails
    { 

        [Required]      
        [Display(Name ="Card Number")]
        public string CardNumber { get; set; }

        [Required]       
        [Display(Name = "Expire Month(mm)")]
        public string ExpiryMonth { get; set; }


        [Required]
        [Display(Name = "Expire Year(yy)")]
        public string ExpiryYear { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public string NameOnCard { get; set; }

        [Required]      
        [Display(Name = "Card Security Code")]        
        public string CardSecurityCode { get; set; }
    }
   ```

  -  Create StripeCredential class in Models folder
  
   ```
    public class StripeCredential
     {
         public string PublishableKey { get; set; }
         public string SecretKey { get; set; }
     }

  ```
