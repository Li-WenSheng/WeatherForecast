using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Entity

{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options) : base(options) { }

        public DbSet<StudentEntity> Student { get; set; }

        public DbSet<CityEntity> City { get; set; }
    }
}