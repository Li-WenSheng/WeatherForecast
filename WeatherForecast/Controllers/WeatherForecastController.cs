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
        public Object TomorrowWeather(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return "请填写城市名";
            }

            var cityList = JsonConvert.DeserializeObject<List<CityEntity>>(_cityJson);
            var city = cityList.Where(x => x.city_name == cityName).FirstOrDefault();
            if (city is null)
            {
                return "找不到该城市";
            }

            var client = new RestClient("http://t.weather.itboy.net/api/weather/city/" + city.city_code);
            var request = new RestRequest(Method.GET);
            var response = client.Get(request);

            var forecasts = JsonConvert.DeserializeObject<WeatherForecastEntity>(response.Content).data.forecast;
            var result = forecasts.Select(x => new { x.high, x.low, x.notice }).ToList()[1];

            return result;
        }
    }
}
