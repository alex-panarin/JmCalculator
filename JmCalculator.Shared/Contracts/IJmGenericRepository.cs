using JmCalculator.Shared.Models;
using System.Threading.Tasks;

namespace JmCalculator.Shared.Contracts
{
    public interface IJmGenericRepository<TResponse, TRequest> 
        where TRequest : JmRequest
    {
        Task<TResponse> GetAsync(TRequest request);
    }
}
