using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Currency
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly AppDbContext _context;
        public CurrencyManager(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<CurrencyType>> GetAllCurrencyTypes()
        {
            return await _context.CurrencyTypes.ToListAsync();
        }
    }
}
