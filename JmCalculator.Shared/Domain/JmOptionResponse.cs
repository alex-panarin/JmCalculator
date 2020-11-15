using JmCalculator.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace JmCalculator.Shared.Domain
{
    public class JmOptionResponse
    {
        public JmOptionResponse(IEnumerable<JmOptionDomain> options)
        {
            HeadrailBracketTypes = options.Where(x => (x.Type == typeof(JmHeadrailBracketTypes).FullName));
            GuidingBracketTypes = options.Where(x => (x.Type == typeof(JmRailBracketTypes).FullName || x.Type == typeof(JmWireBracketTypes).FullName));
            OperationTypes = options.Where(x => (x.Type == typeof(JmHandOperationTypes).FullName || x.Type == typeof(JmMotorOperationTypes).FullName));
            GuidingRailTypes = options.Where(x => x.Type == typeof(JmGuidingRailTypes).FullName);
        }
        public IEnumerable<JmOptionDomain> HeadrailBracketTypes { get; } 
        public IEnumerable<JmOptionDomain> GuidingBracketTypes { get; }
        public IEnumerable<JmOptionDomain> OperationTypes { get; }
      
        public IEnumerable<JmOptionDomain> GuidingRailTypes { get; }
    }
}