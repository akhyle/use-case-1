using UseCase.Domain;

namespace UseCase.Application.Contracts
{
    public interface ICountryHandler
    {
        Task<List<Country>> GetCountryList(
            string countryName,
            int? populationInMillions,
            string sortDirection,
            int? take);
    }
}
