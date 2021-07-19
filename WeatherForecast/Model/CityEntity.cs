using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Model
{
    public class CityEntity
    {
        public int id { get; set; }
        public int pid { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string post_code { get; set; }
        public string area_code { get; set; }
        public string ctime { get; set; }
    }
}
