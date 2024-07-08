namespace AssetManagement.Core.Helper
{
    public class DriverHelper
    {
        public static void NavigateTo(string url)
        {
            DriverManager.driver.Navigate().GoToUrl(url);
        }

        public static void Wait(int milliseconds)
        {
            Task.Delay(milliseconds).Wait();
        }

        public void RefreshPage()
        {
            DriverManager.driver.Navigate().Refresh();
        }
    }
}
