using NSubstitute;
using UseCase.Application;
using UseCase.Application.Contracts;
using UseCase.Domain;

namespace UseCase.ApplicationTests
{
    public class Tests
    {
        private IHttpClientWrapper _httpClient;
        private ICountryHandler _sut;

        [SetUp]
        public void Setup()
        {
            _httpClient = Substitute.For<IHttpClientWrapper>();

            _sut = new CountryHandler(_httpClient);
        }

        [Test]
        public async Task GetCountryList_FiltersListProperly_WhenInputIsCorrect()
        {
            var initialList = new List<Country>()
            {
                new Country()
                {
                    name = new Name()
                    {
                        common = "Argentina"
                    },
                    population = "6000000"
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "Brgentina"
                    },
                    population = "7000000"
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "Crgentina"
                    },
                    population = "8000000"
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "Croatia"
                    },
                    population = "12000000"
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "Nibiru"
                    },
                    population = "13000000"
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "Germany"
                    },
                    population = "14000000"
                },
                new Country()
                {
                    name = new Name()
                    {
                        common = "Filipins"
                    },
                    population = "15000000"
                },
            };

            _httpClient.GetInitialList().Returns(initialList);

            var result = await _sut.GetCountryList("rgenTina", 10, "descend");

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.First().name.common, Is.EqualTo("Crgentina"));
        }
    }
}