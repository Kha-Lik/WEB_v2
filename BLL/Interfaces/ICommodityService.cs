using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ICommodityService
    {
        IEnumerable<CommodityModel> GetAll();
        Task<CommodityModel> Search(string name);
        Task<IEnumerable<CommodityModel>> Search(int orderNum);
        Task<IEnumerable<CommodityModel>> Search(ShopModel shop);
        Task<IEnumerable<CommodityModel>> Search(WarehouseModel warehouse);
    }
}