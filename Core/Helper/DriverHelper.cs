namespace AssetManagement.Core.Helper
{
    public class DriverHelper
    {
        public static void NavigateTo(string url)
        {
            DriverManager.driver.Navigate().GoToUrl(url);
        }
    }
}
