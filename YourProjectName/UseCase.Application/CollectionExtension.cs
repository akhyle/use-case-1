using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Domain;

namespace UseCase.Application
{
    internal static class CollectionExtension
    {
        internal static IEnumerable<Country> FilterByName(this IEnumerable<Country> source, string name)
        {
            if (string.IsNullOrEmpty(name))
                return source;

            return source.Where(x =>
                x.name.common.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        internal static IEnumerable<Country> FilterByPopulation(this IEnumerable<Country> source, int? millionPpl)
        {
            if (millionPpl is null)
                return source;

            return source.Where(x => ComparePopulation(x.population, millionPpl.Value));
        }

        private static bool ComparePopulation(string source, int request)
        {
            var populationAvailable = int.TryParse(source, out var providedPopulation);

            if (!populationAvailable)
                return false;

            var providedPopulationInMillions = Math.Floor((double)providedPopulation / 1000000);

            return providedPopulationInMillions < request;
        }
    }
}
