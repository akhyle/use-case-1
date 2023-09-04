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
        private static List<Country> _countries;

        [SetUp]
        public void Setup()
        {
            _httpClient = Substitute.For<IHttpClientWrapper>();

            _sut = new CountryHandler(_httpClient);

            _countries = new List<Country>()
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
                        common = "Drgentina"
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
        }

        [Test]
        public async Task GetCountryList_FiltersListProperly_WhenInputIsCorrect()
        {
            _httpClient.GetInitialList().Returns(_countries);

            var result = await _sut.GetCountryList("rgenTina", 10, "descend", 3);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result.First().name.common, Is.EqualTo("Drgentina"));
        }

        [Test]
        public async Task GetCountryList_ReturnsCompleteList_WhenInputIsCorrect()
        {
            _httpClient.GetInitialList().Returns(_countries);

            var result = await _sut.GetCountryList(null, null, null, null);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(_countries.Count));
        }
    }
}