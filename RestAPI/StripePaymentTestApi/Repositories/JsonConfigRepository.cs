using StripePaymentTestApi.Interfaces;
using StripePaymentTestApi.utils;

namespace StripePaymentTestApi.Repositories
{
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
}
