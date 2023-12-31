using System.Net.Http; 
using System.Text.Json; 
using System.Threading; 
using System.Threading.Tasks; 
using System.IO; 


class Program
{
    static async Task Main(string[] args)
    {
      
        await FetchDataAndUpdateJsonAsync();

      
        var timer = new Timer(async _ => await FetchDataAndUpdateJsonAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(30));

        Console.WriteLine("Premi 'q' per uscire.");
        while (Console.Read() != 'q') { }
    }

    static async Task FetchDataAndUpdateJsonAsync()
    {
        try
        {
            string apiKey = "1c0688641e16e99ed13c8c383b696f3a";

            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Piacenza&appid={apiKey}&units=metric";
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                
                var data = JsonSerializer.Deserialize<object>(jsonString);

           
                string filePath = "../dataweather.json";
                File.WriteAllText(filePath, jsonString);

                Console.WriteLine("File JSON aggiornato con successo.");
            }
            else
            {
                Console.WriteLine($"Errore durante la chiamata API: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
        }
    }
}