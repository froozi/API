// OpenWeatherMap REST API example
// DKY 2021

using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            var ApiKey = "abe6e881d725e775b19a763603537862";
            //var City = "Kazan";
            var url = $"https://apidata.mos.ru/v1/datasets/2254/rows?api_key={ApiKey}";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine(result);
                var weatherForecast = JsonConvert.DeserializeObject<Texno>(result);
            }

        }
    }
}

