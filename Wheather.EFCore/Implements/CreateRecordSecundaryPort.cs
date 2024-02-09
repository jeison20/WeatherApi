using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Ports.Secundary;
using Weather.Domain.POCOs;
using Weather.EFCore.DataContext;

namespace Weather.EFCore.Implements
{
    public class CreateRecordSecundaryPort: ICheckInformationSecundaryPort
    {
        readonly WeatherContext Context;

        public CreateRecordSecundaryPort(WeatherContext context)
        {
            Context = context;
        }

        public async Task<int> CreateRecord(SearchHistory searchHistory)
        {
            Context.Add(searchHistory);
            return Context.SaveChanges();
        }

        public async Task<List<SearchHistory>> GetRecords()
        {
            var lsDataRecords = Context.SearchHistories.OrderByDescending(c=>c.Id);


            return  lsDataRecords.ToList() ;
        }
    }
}
