using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using UseCase.Application.Contracts;
using UseCase.Domain;

namespace UseCase.Application
{
    public class CountryHandler : ICountryHandler
    {
        public async Task<List<Country>> GetCountryList()
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("https://restcountries.com/v3.1/");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("all");

            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                var dataObjects = JsonConvert.DeserializeObject<List<Country>>(stringContent);
                return dataObjects;
            }

            return new List<Country>();
        }
    }
}