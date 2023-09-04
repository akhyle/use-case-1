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

        public PublicController(
            ICountryHandler countryHandler)
        {
            _countryHandler = countryHandler;
        }

        [HttpGet("get-paginated-list")]
        public async Task<IActionResult> GetPaginatedList(
            [FromQuery] string? countryName, int? populationInMillions, string? sortDirection, int? take)
        {
            var countries = await _countryHandler.GetCountryList(
                countryName, populationInMillions, sortDirection, take);

            return Ok(countries);
        }
    }
}
