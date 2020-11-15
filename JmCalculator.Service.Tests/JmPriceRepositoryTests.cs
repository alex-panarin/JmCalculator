using JmCalculator.Service.Data;
using JmCalculator.Service.Repositories;
using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace JmCalculator.Service.Tests
{
    public class JmPriceRepositoryTests
    {
        private readonly JmPriceRepository _repository;

        class MockPriceDataStorage : IJmPriceDataStorage
        {
            public MockPriceDataStorage()
            {

            }

            readonly List<JmPrice> _prices = new List<JmPrice>
            {
                new JmPrice{Height=600, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} },
                new JmPrice{Height=700, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} },
                new JmPrice{Height=800, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} },
                new JmPrice{Height=900, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} },
                new JmPrice{Height=1000, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} },
                new JmPrice{Height=1100, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} },
                new JmPrice{Height=1200, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} },
                new JmPrice{Height=1300, UnitType= JmUnitTypes.JmComfort, Values= new decimal[]{100 ,200,300,400,500, 600, 700, 800} }
            };
            public async Task<JmPrice> GetData(Expression<Func<JmPrice, bool>> expression)
            {
                return await Task.FromResult(_prices.FirstOrDefault(expression.Compile()));
            }
        }

        public JmPriceRepositoryTests()
        {
            _repository = new JmPriceRepository(() => new MockPriceDataStorage());
        }

        [Fact]
        public void Should_CreateRepositoryWithoutExceptions()
        {
            Assert.NotNull(_repository);
        }



        [Theory]
        [InlineData(600, 600, JmUnitTypes.JmComfort)]
        [InlineData(900, 1000, JmUnitTypes.JmComfort)]
        [InlineData(1100, 500, JmUnitTypes.JmComfort)]
        [InlineData(1200, 800, JmUnitTypes.JmComfort)]
        public async void Should_ReturnPrices(int height, int width, JmUnitTypes type)
        {
            //var repository = new JmPriceRepository(() => new MongoDbPriceDataStorage(new JmCalculatorConfig
            //{
            //    ConnectionString = "",
            //    Name = "test"
            //}));
            var price = await _repository.GetAsync(new JmPriceRequest 
            {
                Height = height,
                UnitType = type,
                Width = width
            });

            int index = (width - 500) / 100;

            Assert.NotNull(price);
            
            Assert.NotEmpty(price.Values);

            Assert.InRange(index + 1, 1, price.Values.Length);

            Assert.NotEqual(0, price.Values[index]);
        }

        [Fact]
        public void Should_ValidateModelAndRaiseException()
        {

            //var exception = Assert.Throws<ValidationException>(() =>
            //    _repository.Validate(new JmPriceRequest
            //    {
            //        Height = 500,
            //        UnitType = JmUnitTypes.JmComfort,
            //        Width = 600,
            //        Quantity = 0 // !!!!
            //    }));

            //Assert.Equal("Quantity should be no less than 1 and no more than 1000; ", exception.Message);
        }

    }
}
