﻿using System;
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

        internal static IEnumerable<Country> OrderByName(this IEnumerable<Country> source, string direction)
        {
            const string Ascend = nameof(Ascend);
            const string Descend = nameof(Descend);

            if (direction is null)
                return source;

            if (string.Equals(direction, Ascend, StringComparison.OrdinalIgnoreCase))
                return source.OrderBy(x => x.name.common);

            if(string.Equals(direction, Descend, StringComparison.OrdinalIgnoreCase))
                return source.OrderByDescending(x => x.name.common);

            return source;
        }

        internal static IEnumerable<Country> TakeFromStart(this IEnumerable<Country> source, int? numberToTake)
        {
            if (numberToTake is null)
                return source;

            return source.Take(numberToTake.Value);
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
