using System.Collections.Generic;

namespace DAL.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public IEnumerable<Commodity> Commodities { get; set; }
        public int? ShopId { get; set; }
        public int? StorageId { get; set; }
        public Shop Shop { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}