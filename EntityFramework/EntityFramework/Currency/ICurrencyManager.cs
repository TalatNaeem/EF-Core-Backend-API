using EntityFramework.Data;
using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public interface ICurrencyManager
    {
        Task<Response<List<CurrencyType>>> GetAllCurrencyTypes();

        Task<Response<CurrencyType>> GetCurrencyById(int id, string name);

        Task<Response<List<CurrencyType>>> GetCurrencyByIdList(List<int>ids);
        Task<Response<string>> AddCurrency(CurrencyDTO currencyObj);
	}
}
