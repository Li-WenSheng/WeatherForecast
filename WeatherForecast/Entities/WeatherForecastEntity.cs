using System;
using System.Collections.Generic;

namespace WeatherForecast
{
    public class CityInfo
    {
        public string city { get; set; }
        public string citykey { get; set; }
        public string parent { get; set; }
        public string updateTime { get; set; }
    }

    public class Forecast
    {
        public string date { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string ymd { get; set; }
        public string week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public int aqi { get; set; }
        public string fx { get; set; }
        public string fl { get; set; }
        public string type { get; set; }
        public string notice { get; set; }
    }

    public class Yesterday
    {
        public string date { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string ymd { get; set; }
        public string week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public int aqi { get; set; }
        public string fx { get; set; }
        public string fl { get; set; }
        public string type { get; set; }
        public string notice { get; set; }
    }

    public class Data
    {
        public string shidu { get; set; }
        public double pm25 { get; set; }
        public double pm10 { get; set; }
        public string quality { get; set; }
        public string wendu { get; set; }
        public string ganmao { get; set; }
        public List<Forecast> forecast { get; set; }
        public Yesterday yesterday { get; set; }
    }

    public class WeatherForecastEntity
    {
        public string message { get; set; }
        public int status { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public CityInfo cityInfo { get; set; }
        public Data data { get; set; }
    }
}
