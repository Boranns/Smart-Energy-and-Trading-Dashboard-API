using SmartEnergyAPI.Entities;
using SmartEnergyAPI.Repositories;

namespace SmartEnergyAPI.Services
{
    public class PortfolioService
    {
        private readonly PortfolioRepository _repository;
        private readonly EnergyProductRepository _productRepository;

        public PortfolioService(PortfolioRepository repository, EnergyProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<List<Portfolio>> GetPortfoliosAsync(int userId)
        {
            return await _repository.GetPortfoliosAsync(userId);
        }

        public async Task<Portfolio> AddOrUpdatePortfolioAsync(int userId, int productId, decimal quantity)
        {
            var existingPortfolio = await _repository.GetPortfoliosAsync(userId)
                .ContinueWith(t => t.Result.FirstOrDefault(p => p.ProductId == productId));

            if (existingPortfolio != null)
            {
                existingPortfolio.Quantity += quantity;
                await _repository.UpdateAsync(existingPortfolio);
                return existingPortfolio;
            }
            else
            {
                var newPortfolio = new Portfolio
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                };
                await _repository.AddAsync(newPortfolio);
                return newPortfolio;
            }
        }

        
    }
}
