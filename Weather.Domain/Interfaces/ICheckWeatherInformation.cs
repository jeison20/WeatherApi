using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Interfaces
{
    public interface ICheckWeatherInformation
    {
        string GetWeatherInformation(string city);
    }
}
