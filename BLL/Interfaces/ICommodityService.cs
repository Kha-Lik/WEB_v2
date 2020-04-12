using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ICommodityService
    {
        IEnumerable<CommodityModel> GetAll();
        CommodityModel Search(string name);
        IEnumerable<CommodityModel> Search(int orderNum);
        IEnumerable<CommodityModel> Search(ShopModel shop);
        IEnumerable<CommodityModel> Search(WarehouseModel warehouse);
    }
}