using JmCalculator.Service.Data;
using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JmCalculator.Service.Repositories
{

    public class JmOptionsRepository : IJmOptionsRepository
    {
        private readonly IJmOptionDataStorage _dataStorage;

        public JmOptionsRepository(Func<IJmOptionDataStorage> dataStorage)
        {
            if (dataStorage == null)
                throw new ArgumentNullException(nameof(dataStorage));

            _dataStorage = dataStorage();

            if (_dataStorage == null)
                throw new NullReferenceException(nameof(_dataStorage));
        }
        public async Task<IEnumerable<JmOption>> GetAsync(JmOptionRequest request)
        {
            var options = await _dataStorage.GetData(x => x.UnitType.HasFlag(request.UnitType) && x.OperationType.HasFlag(request.OperationType));

            return options;
        }

    }
}
