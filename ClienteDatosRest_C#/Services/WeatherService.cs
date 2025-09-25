using ClienteDatosRest_C_.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Text.Json;

namespace ClienteDatosRest_C_.Services
{
    public class WeatherService
    {
        private readonly string apiKey = "0043c1ec2735faa4b5ed16fc3406fb2d"; // 🔑 Reemplaza con tu API Key
        private readonly string baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherResponse> GetWeatherAsync(double? lat, double? lon)
        {
            using (var client = new HttpClient())
            {
                var url = $"{baseUrl}?lat={lat}&lon={lon}&units=metric&lang=es&appid={apiKey}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var weather = System.Text.Json.JsonSerializer.Deserialize<WeatherResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return weather;
            }
        }
    }
}