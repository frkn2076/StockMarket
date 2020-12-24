using AutoMapper;
using StockMarket.Models;
using StockMarket.ViewModels;
using System.Globalization;

namespace StockMarket.Mapper {
    public class MapperPoint : Profile {
        public MapperPoint() {
            // Add as many of these lines as you need to map your objects
            CreateMap<StockDetailModel, StockDetailViewModel>();
        }

        private decimal ToDecimal(string number) => decimal.Parse(number);
    }
}
