using System;
using AutoMapper;
using StockMarket.Models;
using StockMarket.ViewModels;

namespace StockMarket.Mapper {
    public class MapperPoint : Profile {
        public MapperPoint() {
            // Add as many of these lines as you need to map your objects
            CreateMap<StockDetailModel, StockDetailViewModel>();
                //.ForMember(dest => dest.stockCode, opt => opt.MapFrom(src => src.stockCode))
                //.ForMember(dest => dest.distanceToBotttom, opt => opt.MapFrom(src => decimal.Parse(src.distanceToBotttom)))
                //.ForMember(dest => dest.lastValue, opt => opt.MapFrom(src => decimal.Parse(src.lastValue)))
                //.ForMember(dest => dest.distanceToBottomPercentage, opt => opt.MapFrom(src => decimal.Parse(src.distanceToBottomPercentage)))
                //.ForMember(dest => dest.valueOfYesterday, opt => opt.MapFrom(src => decimal.Parse(src.valueOfYesterday)))
                //.ForMember(dest => dest.highestForGivenTimePeriod, opt => opt.MapFrom(src => decimal.Parse(src.highestForGivenTimePeriod)))
                //.ForMember(dest => dest.lowestForGivenTimePeriod, opt => opt.MapFrom(src => decimal.Parse(src.lowestForGivenTimePeriod)))
                //.ForMember(dest => dest.volumeOfLot, opt => opt.MapFrom(src => decimal.Parse(src.volumeOfLot)))
                //.ForMember(dest => dest.volumeOfCurrency, opt => opt.MapFrom(src => decimal.Parse(src.volumeOfCurrency)));

        }
    }
}
