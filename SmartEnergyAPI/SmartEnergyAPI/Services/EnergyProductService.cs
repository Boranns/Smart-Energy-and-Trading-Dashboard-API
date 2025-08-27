using SmartEnergyAPI.Entities;
using SmartEnergyAPI.Repositories;

namespace SmartEnergyAPI.Services
{
    public class EnergyProductService
    {
        private readonly EnergyProductRepository _repository;

        public EnergyProductService(EnergyProductRepository repository )
        {
            _repository = repository;
        }

        public Task<List<EnergyProduct>> GetAll() => _repository.GetAllAsync();
        public Task<EnergyProduct> GetById(int id) => _repository.GetByIdAsync(id);
        public Task Add(EnergyProduct product) => _repository.AddAsync(product);
        public Task Update(EnergyProduct product) => _repository.UpdateAsync(product);
        public Task Delete(EnergyProduct product) => _repository.DeleteAsync(product);
    }
}
