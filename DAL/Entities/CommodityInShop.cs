namespace DAL.Entities
{
    public class CommodityInShop : BaseEntity
    {
        public int ShopId { get; set; }
        public int CommodityId { get; set; }
        public Shop Shop { get; set; }
        public Commodity Commodity { get; set; }
    }
}