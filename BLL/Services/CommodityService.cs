using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CommodityService : ICommodityService

    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public CommodityService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IEnumerable<CommodityModel> GetAll()
        {
            var commodities = _unit.CommodityRepository.GetAll();
            var commodityModels = _mapper.Map<IEnumerable<CommodityModel>>(commodities);
            return commodityModels;
        }

        public Task<CommodityModel> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommodityModel>> Search(int orderNum)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CommodityModel>> Search(ShopModel shop)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CommodityModel>> Search(WarehouseModel warehouse)
        {
            throw new System.NotImplementedException();
        }
    }
}