using System;
using System.IO;
using Telegram.Bot;
using Newtonsoft.Json;
using System.Net;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramBotClient bot = new TelegramBotClient("1895394169:AAEQSTodVZ9p3IsvCyrL38hRXAExuNF-EVM");

            bot.OnMessage += (s, arg) =>
            {
                string a = "Ошибка";
                try
                {
                    a = API();
                }
                catch { }
                Console.WriteLine($"{arg.Message.Chat.FirstName}: {arg.Message.Text}");
                bot.SendTextMessageAsync(arg.Message.Chat.Id, $"You say: {a}");

            };

            bot.StartReceiving();

            Console.ReadKey();
        }

        static string API()
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
                return "";
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine(result);
                return JsonConvert.DeserializeObject<Texno>(result).ToString();
            }

        }
    }

}