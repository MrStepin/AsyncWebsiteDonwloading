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

        static Task<HttpResponseMessage> AsyncDownloading(string Url)
        {
            HttpClient client = new HttpClient();
            var SizeOfPage = client.GetAsync(Url);
            return SizeOfPage;
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter list of URL for downloading and separate them by space:");
            string [] urls = (Console.ReadLine()).Split(' ');
            List <HttpResponseMessage> response = new List<HttpResponseMessage> { };
            foreach (string url in urls)
            {
                response.Add(await AsyncDownloading(url));                
            }
            double totalSize = 0;
            foreach (var size in response)
            {
                totalSize += size.Content.ReadAsByteArrayAsync().Result.Length;
            }
            Console.WriteLine($"Size of pages is {totalSize / 1024} Kb.");
            Console.ReadKey();
        }
    }
}
