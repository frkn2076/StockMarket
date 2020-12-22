namespace StockMarket.ViewModels {
    public struct StockViewModel {
        public string code { get; set; }
        public string name { get; set; }
        public StockViewModel(string code, string name) {
            this.code = code;
            this.name = name;
        }
    }
}
