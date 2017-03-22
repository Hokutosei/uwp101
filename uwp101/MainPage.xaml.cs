using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

using uwp101.Api.Getters;
// using uwp101.Api.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace uwp101
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static List<WeatherModel> cityWeathers = new List<WeatherModel>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine($"input value {input.Text}");

            var cities = new string[] { "akiruno-shi", "omiya-shi" };
            foreach (string city in cities)
            {
                var weather = Weather.GetWeather(city);
                cityWeathers.Add(weather);
            }
            WeathersList.ItemsSource = cityWeathers;
            // var w = Weather.GetWeather(input.Text);
        }
    }

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
