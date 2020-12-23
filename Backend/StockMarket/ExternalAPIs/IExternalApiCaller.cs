using StockMarket.Models;

namespace StockMarket.ExternalAPIs {
    public interface IExternalApiCaller {
        StockTypeModel GetStocks();
        StockDetailModel[] GetStockDetails(string timePeriod);
        StockDetailModel GetStockDetailByCode(string stockCode, string timePeriod);
    }
}