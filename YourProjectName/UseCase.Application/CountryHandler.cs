using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using UseCase.Application.Contracts;
using UseCase.Domain;

namespace UseCase.Application
{
    public class CountryHandler : ICountryHandler
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public CountryHandler(IHttpClientWrapper httpClientwrapper)
        {
            _httpClientWrapper = httpClientwrapper;
        }

        public async Task<List<Country>> GetCountryList(
            string countryName,
            int? populationInMillions,
            string sortDirection,
            int? take)
        {
            var initialList = await _httpClientWrapper.GetInitialList();

            return initialList
                .FilterByName(countryName)
                .FilterByPopulation(populationInMillions)
                .OrderByName(sortDirection)
                .TakeFromStart(take)
                .ToList();
        }
    }
}