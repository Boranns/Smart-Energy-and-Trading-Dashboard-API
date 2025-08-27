using SmartEnergyAPI.Entities;
using SmartEnergyAPI.Repositories;
using System.Threading.Tasks;

namespace SmartEnergyAPI.Services
{
    public class TradeService
    {
        private readonly TradeRepository _tradeRepository;
        private readonly PortfolioService _portfolioService;

        public TradeService(TradeRepository tradeRepository, PortfolioService portfolioService)
        {
            _tradeRepository = tradeRepository;
            _portfolioService = portfolioService;
        }

        public async Task<Trade> ExecuteTradeAsync(int buyerId, int sellerId, int productId, decimal quantity, decimal pricePerUnit)
        {
            var newTrade = new Trade
            {
                BuyerId = buyerId,
                SellerId = sellerId,
                ProductId = productId,
                Quantity = quantity,
                PricePerUnit = pricePerUnit,
                TradeDate = DateTime.UtcNow
            };

            await _tradeRepository.AddAsync(newTrade);

            await _portfolioService.AddOrUpdatePortfolioAsync(buyerId, productId, quantity);

            await _portfolioService.AddOrUpdatePortfolioAsync(sellerId, productId, -quantity);
            
            return newTrade;

        }
    }
}
