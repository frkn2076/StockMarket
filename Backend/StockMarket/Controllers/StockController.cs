using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockMarket.ExternalAPIs;
using StockMarket.Models;
using StockMarket.ViewModels;
using System.Linq;

namespace StockMarket.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase {

        private readonly ILogger<StockController> _logger;
        private readonly IExternalApiCaller _externalApiCaller;
        private readonly IMapper _mapper;

        public StockController(ILogger<StockController> logger, IExternalApiCaller externalApiCaller, IMapper mapper) {
            _logger = logger;
            _externalApiCaller = externalApiCaller;
            _mapper = mapper;
        }

        [HttpGet("stocks")]
        public StockViewModel[] GetStocks() {
            var stocks = _externalApiCaller.GetStocks();
            var response = stocks?.data?.Select(stockDetail => new StockViewModel(stockDetail.kod, stockDetail.ad)).ToArray();
            return response;
        }

        [HttpPost("stockDetails")]
        public StockDetailViewModel[] GetStockDetails(string timePeriod) {
            var stockDetails = _externalApiCaller.GetStockDetails(timePeriod);
            var response = _mapper.Map<StockDetailModel[], StockDetailViewModel[]>(stockDetails);
            return response;
        }
        
        [HttpPost("stockDetailByCode")]
        public StockDetailViewModel GetStockDetailByCode(string stockCode, string timePeriod) {
            var stockDetail = _externalApiCaller.GetStockDetailByCode(stockCode, timePeriod);
            var response = _mapper.Map<StockDetailViewModel>(stockDetail);
            return response;
        }
    }
}
