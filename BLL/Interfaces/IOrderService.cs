using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<PurchaseOrderModel> GetAll();
        
        PurchaseOrderModel Search(string name);
        
        IEnumerable<PurchaseOrderModel> SearchByDate(DateTime date);
        
        IEnumerable<PurchaseOrderModel> SearchByQuantity(int quantity);

        Task MakeOrderAsync(OrderPropertiesContainer purchaseOrderModel);

        /*Task MakeOrderAsync(int[] commodityIds, int shopId, string name, int number);
         
        Task MakeOrderWithWarehouseAsync(int[] commodityIds, int warehouseId, string name, int number);*/
    }
}