using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ICommodityService
    {
        IEnumerable<CommodityModel> GetAll();

        CommodityModel GetById(int id);

        IEnumerable<CommodityModel> GetByIdCollection(params int[] idCollection);

        CommodityModel Search(string name);

        IEnumerable<CommodityModel> Search(int orderNum);

        IEnumerable<CommodityModel> SearchByShopId(int shopId);

        IEnumerable<CommodityModel> SearchByWarehouseId(int warehouseId);
    }
}