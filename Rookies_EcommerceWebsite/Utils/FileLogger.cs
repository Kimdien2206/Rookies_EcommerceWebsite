using System.Collections.Concurrent;

namespace Rookies_EcommerceWebsite.Utils
{
    public class FileLogger
    {
        public static void Log(string logInfo)
        {
            while (true)
            {
                try
                {
                    File.AppendAllTextAsync(@".\log.txt", logInfo);
                    break;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}
