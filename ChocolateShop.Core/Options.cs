namespace ChocolateShop.Core
{
    public static class Options
    {
        public static string ConnectionString
        {
            get
            {
                return Environment.GetEnvironmentVariable("ChocolateShopConnectionString");
            }
        }
    }
}
