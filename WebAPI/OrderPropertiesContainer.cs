using System;
using System.Collections.Generic;
using BLL.Models;

namespace WebAPI
{
    public class OrderPropertiesContainer
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public IEnumerable<CommodityModel> Commodities { get; set; }
        public ShopModel Shop { get; set; }
        public WarehouseModel Warehouse { get; set; }
    }
}