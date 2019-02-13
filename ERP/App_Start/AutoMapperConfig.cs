using System;
using AutoMapper;

namespace ERP
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration _mapperConfiguration;
        public static  void RegisterAutoMapperConfig()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BusinessModels.Customer, ERP.Models.Customer>().ReverseMap();
                cfg.CreateMap<BusinessModels.Address, ERP.Models.Address>().ReverseMap();
                cfg.CreateMap<BusinessModels.Region, ERP.Models.Region>().ReverseMap();
                cfg.CreateMap<BusinessModels.Country, ERP.Models.Country>().ReverseMap();
            });
        }

        public static IMapper Mapper(){
            return _mapperConfiguration.CreateMapper();
        }
    }
}
