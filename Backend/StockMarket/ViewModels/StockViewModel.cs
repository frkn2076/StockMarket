namespace StockMarket.ViewModels {
    public record StockViewModel {
        public string code { get; set; }
        public string name { get; set; }
        public StockViewModel(string code, string name) {
            this.code = code;
            this.name = name;
        }
    }
}
