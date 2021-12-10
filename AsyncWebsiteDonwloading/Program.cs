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
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter list of URL for downloading and separate them by space:");
            string [] urls = (Console.ReadLine()).Split(' ');
            List <Task<HttpResponseMessage>> response = new List<Task<HttpResponseMessage>> { };
            foreach (string url in urls)
            {
                response.Add(Task.Run(async () =>
                {
                    return await client.GetAsync(url);
                }));
            }
            var result = await Task.WhenAll(response);
            foreach (var message in result)
            {
                Console.WriteLine(message.Content.Headers.ContentLength);
            }
            Console.ReadKey();
        }
    }
}
