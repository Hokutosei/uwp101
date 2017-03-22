using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace uwp101.Api.Models
{
    class WeatherModel
    {
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public decimal Temp { get; set; }
        [JsonProperty("temp_max")]
        public decimal TempMax { get; set; }
        [JsonProperty("temp_min")]
        public decimal TempMin { get; set; }
    }
}
