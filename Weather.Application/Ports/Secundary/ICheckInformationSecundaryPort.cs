using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.POCOs;

namespace Weather.Application.Ports.Secundary
{
    public interface ICheckInformationSecundaryPort
    {
        Task<int> CreateRecord(SearchHistory searchHistory);
               
        Task<List<SearchHistory>> GetRecords();
    }
}
