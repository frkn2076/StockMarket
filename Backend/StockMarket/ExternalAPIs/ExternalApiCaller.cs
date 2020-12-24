using Microsoft.Extensions.Caching.Memory;
using StockMarket.Helper;
using StockMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace StockMarket.ExternalAPIs {
    public class ExternalApiCaller : IExternalApiCaller {
        private const string monthParameter = "son-1-ay-tum-endeksler/";
        private const string yearParameter = "son-1-yil-tum-endeksler/";
        private const string stockDetailCacheKey = "StockDetailBy{0}";
        private IMemoryCache _cache;
        private readonly HttpClient httpClient;
        public ExternalApiCaller(IMemoryCache memoryCache) {
            httpClient = new HttpClient();
            _cache = memoryCache;
        }

        private StockTypeModel GetStocks() {
            var response = httpClient.Get<StockTypeModel>(ApiHelper.stocksEndpoint);
            return response;
        }

        private StockDetailModel[] GetStockDetails(TimePeriod timePeriod) {

            StockDetailModel[] response;
            var cacheKey = string.Format(stockDetailCacheKey, timePeriod);
            if (!_cache.TryGetValue(cacheKey, out response))
                SetStockDetailsCacheByTimePeriod(cacheKey, timePeriod, ref response);

            return response;
        }

        private StockDetailModel GetStockDetailByCode(string stockCode, TimePeriod timePeriod) {

            StockDetailModel[] stockdetails;
            var cacheKey = string.Format(stockDetailCacheKey, timePeriod);
            if (!_cache.TryGetValue(cacheKey, out stockdetails))
                SetStockDetailsCacheByTimePeriod(cacheKey, timePeriod, ref stockdetails);

            var response = stockdetails.First(x => x.stockCode == stockCode);
            return response;
        }

        #region Interface Explicit Definitions

        StockTypeModel IExternalApiCaller.GetStocks() => GetStocks();
        StockDetailModel[] IExternalApiCaller.GetStockDetails(string timePeriod) => GetStockDetails((TimePeriod)Enum.Parse(typeof(TimePeriod), timePeriod));
        StockDetailModel IExternalApiCaller.GetStockDetailByCode(string stockCode, string timePeriod) => GetStockDetailByCode(stockCode, (TimePeriod)Enum.Parse(typeof(TimePeriod), timePeriod));

        #endregion

        #region Helper

        private string GetDateIntervalInput(TimePeriod timePeriod) {
            switch (timePeriod) {
                case TimePeriod.Week:
                    return string.Empty;
                case TimePeriod.Month:
                    return monthParameter;
                case TimePeriod.Year:
                    return yearParameter;
                default:
                    throw new ExpectedTypeNotFound("TimePeriod type not found");
            }
        }

        private void SetStockDetailsCacheByTimePeriod(string cacheKey, TimePeriod timePeriod, ref StockDetailModel[] stockDetails) {
            GetStockDetailsByTimePeriod(timePeriod, ref stockDetails);
            _cache.Set(cacheKey, stockDetails, TimeSpan.FromHours(1));
        }

        private string[] GetStockDetailHtmlRow(TimePeriod timePeriod) {

            try {
                var stockDetails = new List<(string, List<string>)>();
                var splittedHtmls = new List<string>();
                var period = GetDateIntervalInput(timePeriod);
                var htmlRows = new List<string>();
                for (int i = 1; i <= 13; i++) {
                    var htmlBody = Regex.Match(httpClient.GetEmbeddedHtml(string.Format(ApiHelper.stocksDetailEndpoint, period, i)), "<div class=\"tBody\">(?s)(.*)</div>").Value.Split("</div>")[0];
                    htmlRows.AddRange(htmlBody.Split("\n"));
                }
                return htmlRows.ToArray();
            }
            catch (Exception ex) {
                throw new DataExtractionError("Something went wrong during data extraction - GetStockDetailHtmlRow method", ex.InnerException);
            }
        }

        private void GetStockDetailsByTimePeriod(TimePeriod timePeriod, ref StockDetailModel[] stockDetails) {

            var htmlRows = GetStockDetailHtmlRow(timePeriod);
            var stocks = new List<(string, List<string>)>();
            string stockCode = null;
            var details = new List<string>();
            foreach (var htmlRow in htmlRows) {
                if (htmlRow.Contains("</a>"))
                    stockCode = htmlRow.Split(">")[1].Split("<")[0];
                else if (htmlRow.Contains("cell009"))
                    details.Add(htmlRow.Split(">")[1].Split("<")[0]);
                else if (htmlRow.Contains("</ul>")) {
                    stocks.Add((stockCode, details));
                    stockCode = null;
                    details = new List<string>();
                }
            }
            stockDetails = stocks.Select(x => new StockDetailModel(x.Item1, x.Item2[0], x.Item2[1], x.Item2[2], x.Item2[3], x.Item2[4], x.Item2[5], x.Item2[6], x.Item2[7])).ToArray();
        }

        #endregion
    }
}
