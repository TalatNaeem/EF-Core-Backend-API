using EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Currency
{
    public interface ICurrencyManager
    {
        Task<List<CurrencyType>> GetAllCurrencyTypes();
    }
}
