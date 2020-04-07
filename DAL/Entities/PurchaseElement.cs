namespace DAL.Entities
{
    public class PurchaseElement : BaseEntity
    {
        public int CommodityId { get; set; }
        public int PurchaseOrderId { get; set; }
        public Commodity Commodity { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}