namespace StockMarket.ViewModels {
    public record StockDetailViewModel {
        public string stockCode { get; set; }
        public string distanceToBotttom { get; set; }
        public string lastValue { get; set; }
        public string distanceToBottomPercentage { get; set; }
        public string valueOfYesterday { get; set; }
        public string highestForGivenTimePeriod { get; set; }
        public string lowestForGivenTimePeriod { get; set; }
        public string volumeOfLot  { get; set; }
        public string volumeOfCurrency { get; set; }
        public StockDetailViewModel(string stockCode, string distanceToBotttom, string lastValue, string distanceToBottomPercentage, string valueOfYesterday, string highestForGivenTimePeriod, string lowestForGivenTimePeriod, string volumeOfLot, string volumeOfCurrency) {
            this.stockCode = stockCode;
            this.distanceToBotttom = distanceToBotttom;
            this.lastValue = lastValue;
            this.distanceToBottomPercentage = distanceToBottomPercentage;
            this.valueOfYesterday = valueOfYesterday;
            this.highestForGivenTimePeriod = highestForGivenTimePeriod;
            this.lowestForGivenTimePeriod = lowestForGivenTimePeriod;
            this.volumeOfLot = volumeOfLot;
            this.volumeOfCurrency = volumeOfCurrency;
        }
    }
}
