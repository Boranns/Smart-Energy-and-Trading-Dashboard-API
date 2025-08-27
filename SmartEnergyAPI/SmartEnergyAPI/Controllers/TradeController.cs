using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEnergyAPI.DTOs;
using SmartEnergyAPI.Services;

namespace SmartEnergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TradeController : ControllerBase
    {
        private readonly TradeService _service;

        public TradeController(TradeService service)
        {
            _service = service;
        }

        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteTrade([FromBody] TradeDto dto)
        {
            var newTrade = await _service.ExecuteTradeAsync(dto.BuyerId, dto.SellerId, dto.ProductId, dto.Quantity, dto.PricePerUnit);
            
            return Ok(newTrade);
        }
    }
}
