using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UseCase.Application.Contracts;

namespace YourProjectName.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicController : ControllerBase
    {
        private readonly ICountryHandler _countryHandler;
        private readonly ILogger<PublicController> _logger;

        public PublicController(
            ILogger<PublicController> logger,
            ICountryHandler countryHandler)
        {
            _logger = logger;
            _countryHandler = countryHandler;
        }

        [HttpGet("get-paginated-list")]
        public async Task<IActionResult> GetPaginatedList(
            [FromQuery] string? countryName, int? populationInMillions, string? sortDirection, string? arg4)
        {
            var countries = await _countryHandler.GetCountryList(
                countryName, populationInMillions, sortDirection);

            return Ok(countries);
        }
    }
}
