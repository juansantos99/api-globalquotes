using stocks_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks_api.Services
{
    public interface IGlobalQuotesService
    {
        Task<List<GlobalQuotes>> GetGlobalQuotes(string symbol);
    }
}
