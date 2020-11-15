using JmCalculator.Shared.Domain;
using System.Threading.Tasks;

namespace JmCalculator.Service.Processors
{
    public interface IJmPriceProcessor
    {
        Task<JmPriceResponse> CalculatePrice(JmPriceRequest priceRequest);
        Task<JmPriceRequest> GetPriceRequest();
        Task<JmOptionResponse> GetOptionResponse(JmPriceRequest priceRequest);
    }
}
