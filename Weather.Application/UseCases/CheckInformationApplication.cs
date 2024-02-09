using Weather.Application.Ports.Primary;
using Weather.Application.Ports.Secundary;
using Weather.Domain.Dtos;
using Weather.Domain.POCOs;
using Weather.Domain.Services;

namespace Weather.Application.UseCases
{
    public class CheckInformationApplication : ICheckInformationPrimaryPort
    {


        readonly CheckInformationService CheckInformationService;
        readonly ICheckInformationSecundaryPort CheckInformationSecundaryPort;
        public CheckInformationApplication(CheckInformationService checkInformationService, ICheckInformationSecundaryPort checkInformationSecundaryPort)
        {
            CheckInformationService = checkInformationService;
            CheckInformationSecundaryPort = checkInformationSecundaryPort;
        }
        public async Task<ResponseDto<InformationResponseDto>> HandleCheckInformation(string city)
        {
            try
            {
                InformationResponseDto informationResponse = CheckInformationService.GetCheckInformation(city);

                string resultInformation = Newtonsoft.Json.JsonConvert.SerializeObject(informationResponse);
                await CheckInformationSecundaryPort.CreateRecord(new SearchHistory { Info = resultInformation, City = city });

                return new ResponseDto<InformationResponseDto> { Data = informationResponse, Message = "OK", Response = "200" };
            }
            catch (Exception)
            {
                return new ResponseDto<InformationResponseDto> { Data = null, Message = "Lo sentimos por favor intente nuevamente mas tarde", Response = "500" };
            }
        }

        public async Task<ResponseDto<List<SearchHistoryDto>>> HandleCheckRecordsInformation()
        {
            try
            {
                List<SearchHistory> searchHistories = await CheckInformationSecundaryPort.GetRecords();
                List<SearchHistoryDto> lsRecords = CheckInformationService.GetCheckRecordsInformation(searchHistories);

                return new ResponseDto<List<SearchHistoryDto>> { Data = lsRecords, Message = "OK", Response = "200" };
            }
            catch (Exception)
            {
                return new ResponseDto<List<SearchHistoryDto>> { Data = null, Message = "Lo sentimos por favor intente nuevamente mas tarde", Response = "500" };
            }
        }
    }
}
