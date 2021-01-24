using System.Threading.Tasks;
using CodingChallenge.Application;
using CodingChallenge.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpPost("Listing/{passengerNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CalculateTotal(int passengerNumber)
        {

            var products = await _passengerService.GetQuote(passengerNumber);
            return Ok(products);
        }
    }
}
