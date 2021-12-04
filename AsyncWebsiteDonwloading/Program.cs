using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace AsyncWebsiteDonwloading
{
    class Program
    {
        static byte[] AsyncDownloading(string Url)
        {
            HttpClient client = new HttpClient();
            var SizeOfPage = client.GetAsync(Url).Result.Content.ReadAsByteArrayAsync();
            return SizeOfPage.Result;
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("Enter list of URL for downloading and separate them by space:");
            string [] Urls = (Console.ReadLine()).Split(' ');
            List<byte[]> SizeOfEveryPage = new List<byte[]> { };
            foreach (string url in Urls)
            {
                SizeOfEveryPage.Add(AsyncDownloading(url));                
            }
            double TotalSize = 0;
            foreach (byte[] size in SizeOfEveryPage)
            {
                TotalSize += size.Length;
            }
            Console.WriteLine($"Size of pages is {TotalSize / 1024} Kb.");
            Console.ReadKey();
        }
    }
}
