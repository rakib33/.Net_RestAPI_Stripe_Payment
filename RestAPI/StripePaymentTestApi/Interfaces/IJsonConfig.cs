namespace StripePaymentTestApi.Interfaces
{
    public interface IJsonConfig
    {        
        bool IsJsonFileExists();
        bool SaveDataintoJsonFile(string data);
    }
}
