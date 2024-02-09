using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Dtos;
using Weather.Domain.POCOs;

namespace Weather.Domain
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SearchHistory, SearchHistoryDto>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
