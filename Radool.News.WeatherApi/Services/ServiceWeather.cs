using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using radool.news.weatherapi.Abstractions;
using radool.news.weatherapi.Domain;

namespace radool.news.weatherapi.Services
{
    public class ServiceWeather : IServiceWeather
    {
        public async Task<WeatherModel> GetWeatherRealTime()
        {
            try
            {
                string filePath = "./../dataweather.json";

                // Verifica l'esistenza del file
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Il file JSON non esiste.");
                    return null; // Qui potresti voler gestire diversamente questa situazione, ad esempio lanciare un'eccezione
                }

                string jsonWeather = await File.ReadAllTextAsync(filePath).ConfigureAwait(false);

                WeatherModel weatherData = JsonSerializer.Deserialize<WeatherModel>(jsonWeather);


                // Modifica il campo 'city' nell'oggetto WeatherModel
                weatherData.city = "Piacenza";
              
                

                return weatherData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
                throw; // Puoi scegliere di gestire l'errore in un altro modo, ad esempio registrandolo o lanciando una specifica eccezione
            }
        }
    }
}
