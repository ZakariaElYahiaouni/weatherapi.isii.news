using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radool.news.weatherapi.Domain
{
    public class WeatherModel
    {
        public string city{get; set;} = string.Empty; 
        public Main main{get; set;}


    }
}