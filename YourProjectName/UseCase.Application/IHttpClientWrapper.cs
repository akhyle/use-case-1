using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Domain;

namespace UseCase.Application
{
    public interface IHttpClientWrapper
    {
        Task<IEnumerable<Country>> GetInitialList();
    }
}
