using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace StockMarket.Helper {
    public static class ApiHelper {
        public const string stocksEndpoint = "https://bigpara.hurriyet.com.tr/api/v1/hisse/list";
        public const string stocksDetailEndpoint = "https://bigpara.hurriyet.com.tr/analiz/dip-zirve-analizi/dibine-yakin-hisseler/{0}{1}/";

        public static T Get<T>(this HttpClient httpClient, string endpoint) {
            try {
                T responseModel;
                using (var response = httpClient.GetAsync(endpoint).Result) {
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    responseModel = JsonConvert.DeserializeObject<T>(responseBody);
                }
                return responseModel;
            } catch(Exception ex) {
                throw new ExternalServiceError("An error occured while ApiHelper - Get method", ex.InnerException);
            }
        }

        public static string GetEmbeddedHtml(this HttpClient httpClient, string endpoint) {
            try {
                using (var response = httpClient.GetAsync(endpoint).Result) {
                    response.EnsureSuccessStatusCode();
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    return responseBody;
                }
            }
            catch (Exception ex) {
                throw new ExternalServiceError("An error occured while ApiHelper - GetEmbededHTML method", ex.InnerException);
            }
        }
    }
}
