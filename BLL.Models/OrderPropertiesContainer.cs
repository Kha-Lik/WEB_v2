namespace BLL.Models
{
    public class OrderPropertiesContainer
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int[] CommodityIds { get; set; }
        public int? ShopId { get; set; }
        public int? WarehouseId { get; set; }
    }
}