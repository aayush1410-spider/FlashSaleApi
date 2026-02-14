using FlashSaleApi.Models;
using FlashSaleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlashSaleApi.Controllers
{
    [ApiController]
    [Route("api/sale")]
    public class SaleController : ControllerBase
    {
        private readonly SaleSvc _svc;

        public SaleController(SaleSvc svc)
        {
            _svc = svc;
        }

        // Admin initialization
        [HttpPost("init")]
        public IActionResult Init([FromBody] dynamic body)
        {
            int count = body.count;
            _svc.Init(count);
            return Ok(new { message = "Inventory initialized", count });
        }

        // Reserve item
        [HttpPost("reserve")]
        public IActionResult Reserve([FromBody] ReserveReq req)
        {
            if (string.IsNullOrEmpty(req.user_id))
                return BadRequest("user_id required");

            var res = _svc.Reserve(req.user_id);

            if (res.waitlist_position.HasValue)
                return Accepted(res);   // 202

            return Created("", res);   // 201
        }

        // For Status
        [HttpGet("status")]
        public IActionResult Status()
        {
            var st = _svc.GetStatus();
            return Ok(st);
        }
    }
}
