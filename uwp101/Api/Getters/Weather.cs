using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using uwp101.Api.Models;

namespace uwp101.Api.Getters
{
    class Weather
    {
        const string weatherAPIKey = "4b4b497e39d42c7f5ba7dd98d1adbc21";

        public static WeatherModel GetWeather(string city)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");

                var response = client.GetAsync($"/data/2.5/weather?q={city}&appid={weatherAPIKey}");
                Task.WhenAll(response);

                var stringResponse = response.Result.Content.ReadAsStringAsync();
                Task.WhenAll(stringResponse);

                dynamic r = JsonConvert.DeserializeObject<WeatherModel>(stringResponse.Result);
                System.Diagnostics.Debug.WriteLine($"weather {r.Main}");

                return r;
            }
        }

        public static decimal KelvinToC(decimal input)
        {
            return input - (decimal)273.15;
        }
    }
}
