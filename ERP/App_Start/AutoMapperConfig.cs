using System;
using AutoMapper;

namespace ERP
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration _mapperConfiguration;
        public static void RegisterAutoMapperConfig()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BusinessModels.Customer, ERP.Models.Customer>().ReverseMap();
                cfg.CreateMap<BusinessModels.Address, ERP.Models.Address>().ReverseMap();
                cfg.CreateMap<BusinessModels.Region, ERP.Models.Region>().ReverseMap();
                cfg.CreateMap<BusinessModels.Country, ERP.Models.Country>().ReverseMap();
                cfg.CreateMap<BusinessModels.State, ERP.Models.State>().ReverseMap();
                cfg.CreateMap<BusinessModels.District, ERP.Models.District>().ReverseMap();
                cfg.CreateMap<BusinessModels.Location, ERP.Models.Location>().ReverseMap();
                cfg.CreateMap<BusinessModels.CompanyType, ERP.Models.CompanyType>().ReverseMap();
                cfg.CreateMap<BusinessModels.Company, ERP.Models.Company>().ReverseMap();
                cfg.CreateMap<BusinessModels.Vendor, ERP.Models.Vendor>().ReverseMap();
                cfg.CreateMap<BusinessModels.Brand, ERP.Models.Brand>().ReverseMap();
                cfg.CreateMap<BusinessModels.ProductMaster, ERP.Models.ProductMaster>().ReverseMap();
                cfg.CreateMap<BusinessModels.PurchaseRequestType, ERP.Models.PurchaseRequestType>().ReverseMap();
                cfg.CreateMap<BusinessModels.SalesRoleType, ERP.Models.SalesRoleType>().ReverseMap();
                cfg.CreateMap<BusinessModels.IdentificationsType, ERP.Models.IdentificationsType>().ReverseMap();
                cfg.CreateMap<BusinessModels.Modules, ERP.Models.Modules>().ReverseMap();
                cfg.CreateMap<BusinessModels.RoleType, ERP.Models.RoleType>().ReverseMap();
                cfg.CreateMap<BusinessModels.RoleMaster, ERP.Models.RoleMaster>().ReverseMap();
                cfg.CreateMap<BusinessModels.UOMMaster, ERP.Models.UOMMaster>().ReverseMap();
                cfg.CreateMap<BusinessModels.ItemMaster, ERP.Models.ItemMaster>().ReverseMap();
                cfg.CreateMap<BusinessModels.LocalSupplier, ERP.Models.LocalSupplier>().ReverseMap();
                cfg.CreateMap<BusinessModels.Discount, ERP.Models.Discount>().ReverseMap();
                cfg.CreateMap<BusinessModels.Tax, ERP.Models.Tax>().ReverseMap();
                cfg.CreateMap<BusinessModels.Warranty, ERP.Models.Warranty>().ReverseMap();
                cfg.CreateMap<BusinessModels.Employee, ERP.Models.Employee>().ReverseMap();
                cfg.CreateMap<BusinessModels.FloorMaster, ERP.Models.FloorMaster>().ReverseMap();
                cfg.CreateMap<BusinessModels.Login, ERP.Models.Login>().ReverseMap();
                cfg.CreateMap<BusinessModels.EnquiryLevel, ERP.Models.EnquiryLevel>().ReverseMap();
                cfg.CreateMap<BusinessModels.ProductEnquiry, ERP.Models.ProductEnquiry>().ReverseMap();
                cfg.CreateMap<BusinessModels.SubModules, ERP.Models.SubModules>().ReverseMap();
                cfg.CreateMap<BusinessModels.ReportMenu, ERP.Models.ReportMenu>().ReverseMap();
                cfg.CreateMap<BusinessModels.Purpose, ERP.Models.Purpose>().ReverseMap();
                cfg.CreateMap<BusinessModels.RoleAccess, ERP.Models.RoleAccess>().ReverseMap();

            });
        }

        public static IMapper Mapper(){
            return _mapperConfiguration.CreateMapper();
        }
    }
}
