using stocks_api.Models;
using stocks_api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks_api.Services
{
    public class GlobalQuotesService : IGlobalQuotesService
    {
        private IGlobalQuotesRepository _repo;
        public GlobalQuotesService(IGlobalQuotesRepository repo)
        {
            _repo = repo;
        }
        public async Task <List<GlobalQuotes>> GetGlobalQuotes(string symbol)
        {
            return await _repo.GetGlobalQuotes(symbol);
        }
    }
}
