using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Abstract
{
    public interface IOrderService
    {
        IEnumerable<PurchaseOrderModel> GetAll();

        PurchaseOrderModel Search(string name);

        IEnumerable<PurchaseOrderModel> SearchByDate(DateTime date);

        IEnumerable<PurchaseOrderModel> SearchByQuantity(int quantity);

        Task MakeOrderAsync(OrderPropertiesContainer purchaseOrderModel);
    }
}