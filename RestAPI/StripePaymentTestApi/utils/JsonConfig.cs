namespace StripePaymentTestApi.utils
{
    public class JsonConfig
    {
        public static string GetJsonFilepath()
        {

            var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var directoryPath = Path.Combine(localAppDataPath, "StripePaymentApp");

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return Path.Combine(directoryPath, "CreditDetails.json");

        }
    }
}
