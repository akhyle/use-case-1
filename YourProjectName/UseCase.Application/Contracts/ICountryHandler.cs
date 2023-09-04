using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Domain;

namespace UseCase.Application.Contracts
{
    public interface ICountryHandler
    {
        Task<List<Country>> GetCountryList(
            string countryName,
            int? populationInMillions,
            string sortDirection);
    }
}
