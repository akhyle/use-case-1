using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using UseCase.Application.Contracts;
using UseCase.Domain;

namespace UseCase.Application
{
    public class CountryHandler : ICountryHandler
    {
        private const string BaseAddress = "https://restcountries.com/v3.1/";
        private readonly HttpClient _httpClient;

        public CountryHandler()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Country>> GetCountryList(
            string countryName)
        {
            var initialList = await GetInitialList();

            return initialList.FilterByName(countryName).ToList();
        }

        private async Task<IEnumerable<Country>> GetInitialList()
        {
            var response = await _httpClient.GetAsync("all");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var stringContent = await response.Content.ReadAsStringAsync();
            var dataObjects = JsonConvert.DeserializeObject<List<Country>>(stringContent);

            return dataObjects ?? throw new Exception();
        }
    }
}