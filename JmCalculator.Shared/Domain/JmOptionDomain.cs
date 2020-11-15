using JmCalculator.Shared.Extensions;
using JmCalculator.Shared.Models;

namespace JmCalculator.Shared.Domain
{
    public class JmOptionDomain : JmOption
    {
        public string Description 
        {
            get { return this.GetDescription(); }
        }
    }
}
