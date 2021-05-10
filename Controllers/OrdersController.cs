using PointsApiMongoDB.Models;
using PointsApiMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PointsApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly PointService _pointService;

        public OrdersController(OrderService orderService, PointService pointService)
        {
            _orderService = orderService;
            _pointService = pointService;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get() =>
            _orderService.Get();

        [HttpGet("{id:length(4)}", Name = "GetOrder")]
        public ActionResult<Order> Get(int id)
        {
            var order = _orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public ActionResult<Order> Create(Order order)
        {
            var point = _pointService.Get(order.PointNumber);
            if (point == null) return NotFound();
            if (point.Status != true) return Forbid();

            if (order.OrderList.Length > 10) return BadRequest();
            if (ValidationOrder(order.RecepientPhone, "phone") == false) return BadRequest();
            if (ValidationOrder(order.PointNumber, "point") == false) return BadRequest();

            _orderService.Create(order);

            return CreatedAtRoute("GetOrder", new { id = order.Id.ToString() }, order);
        }

        [HttpPut("{id:length(4)}")]
        public IActionResult Update(int id, Order orderIn)
        {
            var order = _orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            if (order.PointNumber != orderIn.PointNumber)
            {
                return BadRequest();
            }

            if (order.Status != orderIn.Status)
            {
                return BadRequest();
            }

            _orderService.Update(id, orderIn);

            return NoContent();
        }

        [HttpDelete("{id:length(4)}")]
        public IActionResult Delete(int id)
        {
            var order = _orderService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            _orderService.Remove(order.Id);

            return NoContent();
        }

        public bool ValidationOrder(string checkValue, string pattern)
        {
            string strPattern = "";
            if (pattern == "phone") 
            { 
                strPattern = @"^\+7[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}$";
            }

            if (pattern == "point")
            {
                strPattern = @"(PT-[0-9]{4})";
            }
            Match mm = Regex.Match(checkValue, strPattern);
            return mm.Success;
        }
    }
}
