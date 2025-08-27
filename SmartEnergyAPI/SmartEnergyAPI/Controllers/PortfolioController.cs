using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEnergyAPI.DTOs;
using SmartEnergyAPI.Services;

namespace SmartEnergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly PortfolioService _service;
    

    public PortfolioController(PortfolioService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<IActionResult> GetUserPortfolios()
        {
            var userId = User.Identity.Name;
            if (userId == null)
            {
                return Unauthorized();
            }

            var portfolios = await _service.GetPortfoliosAsync(int.Parse(userId));
            return Ok(portfolios);


        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEnergyToPortfolio([FromBody] PortfolioDto dto)
        {
            var userId = User.Identity.Name;
            if (userId == null)
            {
                return Unauthorized();
            }

            var updatePortfolio = await _service.AddOrUpdatePortfolioAsync(int.Parse(userId), dto.ProductId, dto.Quantity);
            return Ok(updatePortfolio);
        }

    } }
