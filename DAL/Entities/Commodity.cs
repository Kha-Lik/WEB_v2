using System.Collections.Generic;

namespace DAL.Entities
{
    public class Commodity : BaseEntity
    {
        public string Name { get; set; }
        public int Units { get; set; }
        public int Price { get; set; }
        public IEnumerable<OrdersCommodities> Orders { get; set; }
    }
}