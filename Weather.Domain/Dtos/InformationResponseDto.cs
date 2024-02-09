using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Dtos
{
    public class InformationResponseDto
    {
        public List<NewsDto>? News { get; set; }
        public WeatherDto? Weathers { get; set; }
    }
}
