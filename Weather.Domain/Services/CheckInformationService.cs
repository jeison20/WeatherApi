using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using Weather.Domain.Dtos;
using Weather.Domain.Interfaces;
using Weather.Domain.POCOs;

namespace Weather.Domain.Services
{
    public class CheckInformationService
    {
        private readonly IConfiguration configuration;
        private readonly ICheckNewsInformation checkNewsInformation;
        private readonly ICheckWeatherInformation checkWeatherInformation;
        public CheckInformationService(IConfiguration Configuration, ICheckNewsInformation CheckNewsInformation, ICheckWeatherInformation CheckWeatherInformation)
        {
            configuration = Configuration;
            checkNewsInformation = CheckNewsInformation;
            checkWeatherInformation = CheckWeatherInformation;
        }

        public InformationResponseDto GetCheckInformation(string city)
        {

            string responseNews = checkNewsInformation.GetNewsInformation(city);
            string responseWeather = checkWeatherInformation.GetWeatherInformation(city);
            WeatherDataDto weatherData = JsonConvert.DeserializeObject<WeatherDataDto>(responseWeather);
            NewsDataDto NewsData = JsonConvert.DeserializeObject<NewsDataDto>(responseNews);

            return new InformationResponseDto { News = NewsData?.Results, Weathers = weatherData?.Data?.Values };


        }

        public List<SearchHistoryDto> GetCheckRecordsInformation(List<SearchHistory> searchHistories)
        { 
            var mapper = MapperConfig.InitializeAutomapper();
            List<SearchHistoryDto> lsSearchHistoriesDto = mapper.Map<List<SearchHistoryDto>>(searchHistories);          
           

            return lsSearchHistoriesDto.Distinct().ToList();
        }

    }
}
