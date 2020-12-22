using StockMarket.Models;

namespace StockMarket.ExternalAPIs {
    public interface IExternalApiCaller {
        StockTypeModel GetStocks();
        StockDetailModel GetStockDetail(string code);
    }
}