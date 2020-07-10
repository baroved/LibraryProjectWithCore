using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCoreLibrary.API;
using Shared.Model;

namespace ServerCoreLibrary.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _historySales;

        public SaleController(ISaleService historySales)
        {
            _historySales = historySales;
        }

        [HttpGet("GetHistorySales")]
        public async Task<IEnumerable<Sale>> GetHistorySellsAsync()
        {
            return await _historySales.GetHistorySalesAsync();
        }

        [HttpPost("Buy")]
        public async Task<bool> BuyItemAsync(Sale historySale)
        {
            if (ModelState.IsValid)
                return await _historySales.BuyItemAsync(historySale);
            return false;
        }
    }
}