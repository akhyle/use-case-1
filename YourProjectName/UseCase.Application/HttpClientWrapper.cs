using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UseCase.Domain;

namespace UseCase.Application
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private const string BaseAddress = "https://restcountries.com/v3.1/";
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IEnumerable<Country>> GetInitialList()
        {
            var response = await _httpClient.GetAsync("all");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException();

            var stringContent = await response.Content.ReadAsStringAsync();
            var dataObjects = JsonConvert.DeserializeObject<List<Country>>(stringContent);

            return dataObjects ?? throw new NullReferenceException();
        }
    }
}
