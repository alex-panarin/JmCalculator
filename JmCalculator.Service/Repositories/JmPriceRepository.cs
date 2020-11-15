using JmCalculator.Service.Data;
using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Models;
using System;
using System.Threading.Tasks;

namespace JmCalculator.Service.Repositories
{
    public class JmPriceRepository : IJmPriceRepository
    {
        private readonly IJmPriceDataStorage _dataStorage;

        public JmPriceRepository(Func<IJmPriceDataStorage> dataStorage)
        {
            if (dataStorage == null)
                throw new ArgumentNullException(nameof(dataStorage));

            _dataStorage = dataStorage();

            if (_dataStorage == null)
                throw new NullReferenceException(nameof(_dataStorage));
        }

        public async Task<JmPrice> GetAsync(JmPriceRequest request)
        {
           var price = await _dataStorage.GetData(x => x.Height == request.Height && x.UnitType == request.UnitType);

            return price;
        }

    }
}
