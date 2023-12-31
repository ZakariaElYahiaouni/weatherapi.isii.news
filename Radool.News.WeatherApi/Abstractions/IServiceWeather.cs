using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using radool.news.weatherapi.Domain;

namespace radool.news.weatherapi.Abstractions
{
    public interface IServiceWeather
    {
        public Task<WeatherModel> GetWeatherRealTime();
    }
}