using StripePaymentTestApi.Interfaces;

namespace StripePaymentTestApi.Repositories
{
    public class JsonConfigRepository : IJsonConfig
    {
        public Task<bool> IsJsonFileExists()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveDataintoJsonFile()
        {
            throw new NotImplementedException();
        }
    }
}
