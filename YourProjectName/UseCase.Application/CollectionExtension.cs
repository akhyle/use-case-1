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
    }
}
