using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Entities;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Commodity, CommodityModel>().ReverseMap();
            CreateMap<Shop, ShopModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseModel>().ReverseMap();
            CreateMap<PurchaseOrder, PurchaseOrderModel>().ReverseMap();
        }
    }
}