using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Weather.Application.Ports.Primary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckInformationController : ControllerBase
    {
        readonly ICheckInformationPrimaryPort PrimaryPort;
        public CheckInformationController(ICheckInformationPrimaryPort checkInformationPrimaryPort)
        {
            PrimaryPort = checkInformationPrimaryPort;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Information([Required]string city)
        {
            var message = await PrimaryPort.HandleCheckInformation(city);

            if (message.Response != StatusCodes.Status200OK.ToString())
            {
                return BadRequest(message);
            }


            return this.StatusCode(StatusCodes.Status200OK, message);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRecrodsInformation()
        {
            var message = await PrimaryPort.HandleCheckRecordsInformation();

            if (message.Response != StatusCodes.Status200OK.ToString())
            {
                return BadRequest(message);
            }

            return this.StatusCode(StatusCodes.Status200OK, message);
        }
    }
}
