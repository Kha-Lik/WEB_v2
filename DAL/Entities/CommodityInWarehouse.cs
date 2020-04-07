namespace DAL.Entities
{
    public class CommodityInWarehouse : BaseEntity
    {
        public int StorageId { get; set; }
        public int CommodityId { get; set; }
        public Warehouse Warehouse { get; set; }
        public Commodity Commodity { get; set; }
    }
}