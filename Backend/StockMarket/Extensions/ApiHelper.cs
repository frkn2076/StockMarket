using Newtonsoft.Json;
using System.Net.Http;

namespace StockMarket.Extensions {
    public static class ApiHelper {
        public static T Get<T>(this HttpClient httpClient, string endpoint) {
            T responseModel;
            using (var response = httpClient.GetAsync(endpoint).Result) {
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                responseModel = JsonConvert.DeserializeObject<T>(responseBody);
            }
            return responseModel;
        }
    }
}
