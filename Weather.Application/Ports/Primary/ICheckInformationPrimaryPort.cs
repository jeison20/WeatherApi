using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Dtos;

namespace Weather.Application.Ports.Primary
{
    public interface ICheckInformationPrimaryPort
    {

        Task<ResponseDto<InformationResponseDto>> HandleCheckInformation(string city);
        Task<ResponseDto<List<SearchHistoryDto>>> HandleCheckRecordsInformation();

    }
}
