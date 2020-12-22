using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockMarket.ExternalAPIs;
using StockMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase {

        private readonly ILogger<StockController> _logger;
        private readonly IExternalApiCaller _externalApiCaller;

        public StockController(ILogger<StockController> logger, IExternalApiCaller externalApiCaller) {
            _logger = logger;
            _externalApiCaller = externalApiCaller;
        }

        [HttpGet("stocks")]
        public StockViewModel[] GetStocks() {
            var stocks = _externalApiCaller.GetStocks();
            var response = stocks?.data?.Select(stockDetail => new StockViewModel(stockDetail.kod, stockDetail.ad)).ToArray();
            return response;
        }

        [HttpPost("stockDetail")]
        public decimal GetStockDetailByCode(string code) {
            var stockDetail = _externalApiCaller.GetStockDetail(code);
            var response = stockDetail?.data?.hisseYuzeysel?.alis ?? 0;
            return response;
        }
    }
}
