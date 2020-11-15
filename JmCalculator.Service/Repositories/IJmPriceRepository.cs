using JmCalculator.Shared.Contracts;
using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Models;

namespace JmCalculator.Service.Repositories
{
    public interface IJmPriceRepository : IJmGenericRepository<JmPrice, JmPriceRequest>
    {
        
    }
}