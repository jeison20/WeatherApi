using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Dtos
{
    public class WeatherDto
    {
        public decimal? CloudBase { get; set; }
        public decimal? CloudCeiling { get; set; }       
        public decimal? CloudCover { get; set; }
        public decimal? DewPoint { get; set; }
        public decimal? FreezingRainIntensity { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? PrecipitationProbability { get; set; }
        public decimal? PressureSurfaceLevel { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? TemperatureApparent { get; set; }
        public decimal? Visibility { get; set; }
        public decimal? WeatherCode { get; set; }
        public decimal? WindDirection { get; set; }
        public decimal? WindGust { get; set; }
        public decimal? WindSpeed { get; set; }
        
    }
}
