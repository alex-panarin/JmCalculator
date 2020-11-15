using JmCalculator.Service.Data;
using JmCalculator.Service.Repositories;
using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Extensions;
using JmCalculator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace JmCalculator.Service.Tests
{

    class MockOptionDataSource : IJmOptionDataStorage
    {
        readonly List<JmOption> options = new List<JmOption>
        {
            JmHeadrailBracketTypes.DK3.CreateOption(6),
            JmHeadrailBracketTypes.DK5.CreateOption(10),
            JmHeadrailBracketTypes.DK6.CreateOption(12),
            JmHeadrailBracketTypes.MD1a.CreateOption(3),
            JmHeadrailBracketTypes.MD2a.CreateOption(5),
            JmHeadrailBracketTypes.MD2b.CreateOption(6),
            JmHeadrailBracketTypes.MD1c.CreateOption(8, JmUnitTypes.JmConsole),
            JmWireBracketTypes.DL1.CreateOption(5, JmUnitTypes.JmComfortWired),
            JmWireBracketTypes.DL2.CreateOption(6, JmUnitTypes.JmComfortWired),
            JmWireBracketTypes.DL3.CreateOption(7, JmUnitTypes.JmComfortWired),
            JmWireBracketTypes.DL4.CreateOption(10, JmUnitTypes.JmComfortWired),
            JmHandOperationTypes.ExteriorGear.CreateOption(89, JmOperationTypes.Hand),
            JmHandOperationTypes.InteriorGear.CreateOption(102, JmOperationTypes.Hand),
            JmMotorOperationTypes.SOMFY6.CreateOption(145, JmOperationTypes.Motor),
            JmMotorOperationTypes.SOMFY10.CreateOption(185, JmOperationTypes.Motor),
            JmMotorOperationTypes.SOMFY18.CreateOption(205, JmOperationTypes.Motor),
            JmMotorOperationTypes.SOMFY6RTS.CreateOption(245, JmOperationTypes.Motor),
            JmMotorOperationTypes.SOMFY10RTS.CreateOption(265, JmOperationTypes.Motor),
            JmRailBracketTypes.K1.CreateOption(1, JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmRailBracketTypes.K2.CreateOption(5, JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmRailBracketTypes.K3.CreateOption(7, JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmRailBracketTypes.TK3.CreateOption(7, JmUnitTypes.JmConsole | JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmRailBracketTypes.TK4.CreateOption(10, JmUnitTypes.JmConsole | JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmRailBracketTypes.TK5.CreateOption(5, JmUnitTypes.JmConsole | JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmRailBracketTypes.TK6.CreateOption(6, JmUnitTypes.JmConsole | JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmGuidingRailTypes.VL2.CreateOption(0, JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmGuidingRailTypes.VL3.CreateOption(0, JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmGuidingRailTypes.VL7.CreateOption(0, JmUnitTypes.JmComfort | JmUnitTypes.JmProfi90 | JmUnitTypes.JmProfi70),
            JmGuidingRailTypes.VL6.CreateOption(3, JmUnitTypes.JmConsole)
        };
        public async  Task<IEnumerable<JmOption>> GetData(Expression<Func<JmOption, bool>> expression)
        {
            //var jsonstring = JsonSerializer.Serialize<IEnumerable<JmOption>>(options);
            //File.WriteAllText("options.json", jsonstring);

            return await Task.FromResult(options.Where(expression.Compile()));
        }
    }


    public class JmOptionRepositoryTests
    {
        [Fact]
        public async void Should_ReturnAvailableOptions()
        {
            var optionRepository = new JmOptionsRepository(() => new MockOptionDataSource());

            Assert.NotNull(optionRepository);

            var response = await optionRepository.GetAsync(new JmOptionRequest {UnitType = JmUnitTypes.JmConsole, OperationType = JmOperationTypes.Motor});

            Assert.NotNull(response);

            Assert.NotEmpty(response);
        }

        
    }


}
