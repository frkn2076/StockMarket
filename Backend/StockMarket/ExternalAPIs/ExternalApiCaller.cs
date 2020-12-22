using StockMarket.Extensions;
using StockMarket.Models;
using System.Net.Http;

namespace StockMarket.ExternalAPIs {
    public class ExternalApiCaller : IExternalApiCaller {
        private readonly HttpClient httpClient;
        public ExternalApiCaller() {
            httpClient = new HttpClient();
        }

        private StockTypeModel GetStocks() => httpClient.Get<StockTypeModel>("https://bigpara.hurriyet.com.tr/api/v1/hisse/list");
        private StockDetailModel GetStockDetail(string code) => httpClient.Get<StockDetailModel>($"https://bigpara.hurriyet.com.tr/api/v1/borsa/hisseyuzeysel/{code}");

        #region Interface Definitions
        StockTypeModel IExternalApiCaller.GetStocks() => GetStocks();
        StockDetailModel IExternalApiCaller.GetStockDetail(string code) => GetStockDetail(code);
        #endregion

    }
}
