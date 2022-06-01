using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace MathConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("CustomerId");
            var customerId = System.Console.ReadLine();

            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44379/math?CustomerId=" + customerId);
            httpWebRequest.Method = "GET";

            string test = string.Empty;

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                test = reader.ReadToEnd();
                stream.Close();
            }

            var CustomerIdList = JsonSerializer.Deserialize<List<Customer>>(test, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (Customer item in CustomerIdList)
            {
                System.Console.WriteLine(item.CompanyName);
            }
        }
    }
}
