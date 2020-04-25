using System;
using System.Collections.Generic;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet("Get")]
        public ActionResult<IEnumerable<PurchaseOrderModel>> Get()
        {
            return Ok(_orderService.GetAll());
        }
        
        [HttpGet("SearchByDate/{date}")]
        public ActionResult<IEnumerable<PurchaseOrderModel>> SearchByDate(DateTime date)
        {
            return Ok(_orderService.SearchByDate(date));
        }
        
        [HttpGet("SearchByQuantity/{quantity}")]
        public ActionResult<IEnumerable<PurchaseOrderModel>> SearchByQuantity(int quantity)
        {
            return Ok(_orderService.SearchByQuantity(quantity));
        }

        [HttpPost("MakeOrder")]
        public IActionResult MakeOrder(OrderPropertiesContainer container)
        {
            if (container.Shop != null)
            {
                _orderService.MakeOrder(container.Commodities, container.Shop, container.Name,
                    container.Number);
                return Ok();
            }

            if (container.Warehouse != null)
            {
                _orderService.MakeOrder(container.Commodities, container.Warehouse, container.Name,
                    container.Number);
                return Ok();
            }

            return StatusCode(401);
        }
    }
}