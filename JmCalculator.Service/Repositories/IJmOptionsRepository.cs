using JmCalculator.Shared.Contracts;
using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Models;
using System.Collections.Generic;

namespace JmCalculator.Service.Repositories
{
    public interface IJmOptionsRepository : IJmGenericRepository<IEnumerable<JmOption>, JmOptionRequest>
    {

    }
}
