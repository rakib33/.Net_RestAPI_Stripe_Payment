namespace StripePaymentTestApi.Interfaces
{
    public interface IJsonConfig
    {
        Task<bool> IsJsonFileExists();
        Task<bool> SaveDataintoJsonFile();
    }
}
