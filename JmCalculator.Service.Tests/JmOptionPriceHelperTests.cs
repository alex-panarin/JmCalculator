using JmCalculator.Shared.Extensions;
using JmCalculator.Shared.Models;
using Xunit;

namespace JmCalculator.Service.Tests
{
    public class JmOptionPriceHelperTests
    {
        [Fact]
        public void Should_CreateOptionFromEmun()
        {
            var option = JmComponentColorTypes.Black.CreateOption(99, JmUnitTypes.JmComfort);

            Assert.NotNull(option);
        }

        [Fact]
        public void Should_GetDescriptionFromEnum()
        {
            var description = JmOperationTypes.Without.GetDescription();

            Assert.Equal("Без управления", description);

            description = JmHeadrailBracketTypes.DK3.GetDescription();
            
            Assert.Equal("DK3", description);

        }
    }
}
