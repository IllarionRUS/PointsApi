using PointsApiMongoDB.Models;
using PointsApiMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PointsApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly PointService _pointService;

        public PointsController(PointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public ActionResult<List<Point>> Get() =>
            _pointService.Get();

        [HttpGet("{id:length(7)}", Name = "GetPoint")]
        public ActionResult<Point> Get(string id)
        {
            var point = _pointService.Get(id);

            if (point == null)
            {
                return NotFound();
            }

            return point;
        }


    }
}
