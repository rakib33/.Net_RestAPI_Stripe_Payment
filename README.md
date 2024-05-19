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

- Create ICreditDetails and IJsonConfig interface on Interfaces folder
  
  ```
   public interface ICreditDetails
   {
     Task<bool> SaveCreditDetails(CardDetails creditDetails);
     Task<bool> IsValidCreditDetails(CardDetails creditDetails);    
   }

  public interface IJsonConfig
  {        
      bool IsJsonFileExists();
      bool SaveDataintoJsonFile(string data);
  }
  
  ```

- Now implement those interface . Create JsonConfigRepository.cs class to implement IJosnConfig. We will save credential info into a json file.

 ```
 public class JsonConfigRepository : IJsonConfig
 {
   
     private readonly string _filePath;   
     
     public JsonConfigRepository()
     {
         _filePath = JsonConfig.GetJsonFilepath();
     }
     public bool IsJsonFileExists()
     {
         //// Ensure the file exists
         if (!File.Exists(_filePath))           
             return true;
         return false;
     }

     public bool SaveDataintoJsonFile(string data)
     {
         try
         {
             //.WriteAllText
             File.AppendAllText(_filePath, data);
             return true;
         }
         catch (Exception ex)
         {
             return false;
         }
     }
 }
 ```

- Create CreditDetailsRepository.cs to implement ICreditDetails interfaces . Here we check is the credential is valid and if valid then save to json config file.


 ```
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

```

- Create UserCreditDetailsService.cs in Service Folder. We will call this method from our Rest Api Controller.

```
  public class UserCreditDetailsService
  {
      private readonly ICreditDetails _creditDetails;
      public UserCreditDetailsService(ICreditDetails creditDetails)
      { 
       _creditDetails = creditDetails;
      }

      public async Task<string> SaveCreditDetailsInfoToJsonFile(CardDetails creditDetails)
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

```

- Create StripePaymentTestController.cs Web API controller under Controllers folder.

```
[Route("api/[controller]")]
[ApiController]
public class StripePaymentTestController : ControllerBase
{
    private readonly UserCreditDetailsService _userCreditDetailsService;
    public StripePaymentTestController(UserCreditDetailsService userCreditDetailsService)
    {
       _userCreditDetailsService = userCreditDetailsService;
    }
    

    [HttpPost("CreditDetails")]
    public async Task<IActionResult> CreditDetails([FromForm] CardDetails creditDetails)
    {
        string result = await _userCreditDetailsService.SaveCreditDetailsInfoToJsonFile(creditDetails);

        if (result == ResponseStatus.Credit_Details_Save_Code)
            return StatusCode(StatusCodes.Status201Created, ResponseStatus.Credit_Details_Save_Msg);

        else if(result == ResponseStatus.Credit_Details_Save_Failed_Code)
            return StatusCode(StatusCodes.Status500InternalServerError, ResponseStatus.Credit_Details_Save_Failed_Msg);

        return BadRequest(ResponseStatus.Credit_Details_Invalid_Msg);

    }

}

```

- Now add all the services dependecies in Program.cs file.

```
builder.Services.AddControllers();

// IOptions 
builder.Services.Configure<StripeCredential>(builder.Configuration.GetSection("StripeKey"));


builder.Services.AddScoped<IJsonConfig, JsonConfigRepository>();
builder.Services.AddScoped<ICreditDetails, CreditDetailsRepository>();

builder.Services.AddScoped<UserCreditDetailsService>();
builder.Services.AddSingleton<StripeCardManager>();

```

- Get secret key from stripe developers mode
![image](https://github.com/rakib33/.Net_RestAPI_Stripe_Payment/assets/10026710/46b7049c-3414-40c1-b66f-8f986b610932)

- Add this key in appsettings.json file

```

 "AllowedHosts": "*",
 "StripeKey": {
   "PublishableKey": "pk_test_51PHkV1001KhaFPFJIifuIqwRyX2JgRO9aENw8wDhFdU6LECOWAOqdPEIIh52UX2LbVa1wrwVHN9w4tTiBNsAlZBa005oHTNP7F",
   "SecretKey": "sk_test_51PHkV1001..................u5w00jOSr85Eo"

 }

```

- We will get this key uisng IOptions patterns already configure in Program.cs file 

- Now run the app using swagger and execute the api method.

   ![image](https://github.com/rakib33/.Net_RestAPI_Stripe_Payment/assets/10026710/7d66b2c2-669b-4d2e-842d-b9b38fce15bc)

- After execute and success we get http status code 201 with custom message.
  
  ![image](https://github.com/rakib33/.Net_RestAPI_Stripe_Payment/assets/10026710/ba2af62d-beee-4e0c-9fa6-5f0068028e2c)

- Data is saved on json file on this location . [C:\Users\<YourPcName>\AppData\Local\StripePaymentApp]

- When data save is failed for any internal reason, user get this response message with http status code 500.

  ![image](https://github.com/rakib33/.Net_RestAPI_Stripe_Payment/assets/10026710/07ba7df4-0213-42f9-ad7f-8fb7ee525c1f)

- For invalid credit information we return status code 400 with message.

  ![image](https://github.com/rakib33/.Net_RestAPI_Stripe_Payment/assets/10026710/b24c8234-8fea-442c-bf11-a4426a9df9a4)

- Also we can return any custom response in web api.

## References

- https://docs.stripe.com/testing
- https://docs.stripe.com/api
- https://stackoverflow.com/questions/69099948/how-to-check-stripe-card-is-valid-and-is-still-working-without-making-any-paymen 

## Question Asked
- https://github.com/stripe/stripe-android/issues/819
