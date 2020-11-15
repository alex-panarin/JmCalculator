using JmCalculator.Shared.Contracts;

namespace JmCalculator.Service.Config
{
    public class JmCalculatorConfig : IJmCalculatorConfig
    {
        public string Name { get ; set; }
        public string ConnectionString { get ; set ; }
    }
}
