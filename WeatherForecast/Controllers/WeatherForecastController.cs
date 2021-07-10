using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Entities;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly string _cityJson;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _cityJson = Utils.CityJson;
        }

        [HttpGet]
        public Forecast TomorrowWeather(string cityName)
        {
            var cityList = JsonConvert.DeserializeObject<List<CityEntity>>(_cityJson);
            var city = cityList.Where(x => x.city_name.Contains(cityName) && !string.IsNullOrEmpty(x.city_code)).FirstOrDefault();
           
            var client = new RestClient("http://t.weather.itboy.net/api/weather/city/" + city.city_code);
            var request = new RestRequest(Method.GET);
            var response = client.Get(request);
            var result = JsonConvert.DeserializeObject<WeatherForecastEntity>(response.Content);

            return result.data.forecast[1];
        }
    }
}
