using System.Linq;
using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Implementation.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Commodity, CommodityModel>().ReverseMap();
            CreateMap<Shop, ShopModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseModel>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderModel>().ForMember(o => o.Commodities,
                opt =>
                    opt.MapFrom(o => o.Commodities.Select(oc => oc.Commodity)));
            CreateMap<PurchaseOrderModel, PurchaseOrder>().ForMember(o => o.Commodities,
                opt =>
                    opt.MapFrom(o => o.Commodities.Select(c => new OrdersCommodities {CommodityId = c.Id})));
            CreateMap<UserRegistrationModel, User>()
                .ForMember(u => u.UserName,
                    opt => opt.MapFrom(x => x.Email));
        }
    }
}