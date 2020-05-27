using System.Collections.Generic;
using BLL.Abstract;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommodityController : Controller
    {
        private readonly ICommodityService _commodityService;

        public CommodityController(ICommodityService commodityService)
        {
            _commodityService = commodityService;
        }

        [HttpGet("Get")]
        public ActionResult<IEnumerable<CommodityModel>> Get()
        {
            return Ok(_commodityService.GetAll());
        }

        [HttpGet("Search/{name}")]
        public ActionResult<CommodityModel> Search(string name)
        {
            return Ok(_commodityService.Search(name));
        }

        [HttpGet("SearchByOrder/{orderNum}")]
        public ActionResult<IEnumerable<CommodityModel>> SearchByOrder(int orderNum)
        {
            return Ok(_commodityService.SearchByWarehouseId(orderNum));
        }

        [HttpGet("SearchByShop/{shopId}")]
        public ActionResult<IEnumerable<CommodityModel>> SearchByShop(int shopId)
        {
            return Ok(_commodityService.SearchByShopId(shopId));
        }

        [HttpGet("SearchByWarehouse/{warehouseId}")]
        public ActionResult<IEnumerable<CommodityModel>> SearchByWarehouse(int warehouseId)
        {
            return Ok(_commodityService.SearchByWarehouseId(warehouseId));
        }
    }
}