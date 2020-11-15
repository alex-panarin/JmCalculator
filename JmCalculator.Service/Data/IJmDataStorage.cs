using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JmCalculator.Service.Data
{
    public interface IJmDataStorage<TResponse, TData>
        where TResponse : class
        where TData : class
    {
        Task<TResponse> GetData(Expression<Func<TData, bool>> expression);
    }
}
