namespace Rookies_EcommerceWebsite.Utils
{
    public class FileLogger
    {
        public static void Log(string logInfo)
        {
            File.AppendAllText(@".\log.txt", $"{DateTime.Now}: {logInfo}\n");
        }
    }
}
