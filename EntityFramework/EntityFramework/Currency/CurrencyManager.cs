using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly AppDbContext _context;
        public CurrencyManager(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Response<List<CurrencyType>>> GetAllCurrencyTypes()
        {
            var response = new Response<List<CurrencyType>>();
            response.Data = await _context.CurrencyTypes.ToListAsync();
            response.Message.Add("Successfull Response");

            return response;
        }

        public async Task<Response<CurrencyType>> GetCurrencyById(int id, string name)
        {
            var response = new Response<CurrencyType>();
            var result = await _context.CurrencyTypes?.FirstOrDefaultAsync(x => x.Id == id && x.Currency == name);
            if (result != null)
            {
                response.Data = result;
                response.Message.Add("Record Found");
            }
            else
            {
                response.Message.Add("Record Not Found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return response;
        }

        public async Task<Response<List<CurrencyType>>> GetCurrencyByIdList(List<int> ids)
        {
            var response = new Response<List<CurrencyType>>();
            var result = await _context?.CurrencyTypes?.Where(x=>ids.Contains(x.Id))
                .Select(x=> new CurrencyType
                {
                    Id = x.Id,
                    Currency = x.Currency
                }).ToListAsync();
            if (result != null && result.Count>0)
            {
                response.Data = result;
                response.Message.Add("Successfull");
            }
            else
            {
                response.Message.Add("No Record Found");
                response.StatusCode=System.Net.HttpStatusCode.NotFound;
            }
            return response;
        }

        public async Task<Response<string>> AddCurrency(CurrencyDTO currencyObj)
        {
            var count = _context.CurrencyTypes.Count();
            var response = new Response<string>();
            CurrencyType currencyType = new CurrencyType();
            //currencyType.Id = count+1;
            currencyType.Currency = currencyObj.Currency;
            currencyType.Description = currencyObj.Description;
            _context.CurrencyTypes.Add(currencyType);
            _context.SaveChanges();
            response.Message.Add("Added Successfully");
            return response;
        }
	}
}
