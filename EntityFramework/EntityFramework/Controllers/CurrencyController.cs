using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyManager _icurrencyManager;

        public CurrencyController(ICurrencyManager currencyManager)
        {
            _icurrencyManager = currencyManager;
        }
        [HttpGet("GetAllCurrenciesTypes")]
        public async Task<ActionResult<Response<List<CurrencyType>>>> GetAllCurrencies()
        {
            return Ok( await _icurrencyManager.GetAllCurrencyTypes());
        }

        [HttpGet("GetCurrencyById/{id}/{name}")]
        public async Task<ActionResult<Response<CurrencyType>>> GetCurrencyById([FromRoute] int id, [FromRoute] string name)
        {
            return Ok(await _icurrencyManager.GetCurrencyById(id, name));
        }

        [HttpPost("GetCurrencyByIdList")]
        public async Task<ActionResult<Response<List<CurrencyType>>>> GetCurrencyByIdList([FromBody] List<int> ids)
        {
            return Ok(await _icurrencyManager.GetCurrencyByIdList(ids));
        }

        [HttpPost("AddCurrency")]
        public async Task<ActionResult<Response<string>>> AddCurrency(CurrencyDTO currencyObject)
        {
            return Ok(await _icurrencyManager.AddCurrency(currencyObject));
        }

    }
}
