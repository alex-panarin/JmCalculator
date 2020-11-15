namespace JmCalculator.Shared.Contracts
{
    public interface IJmCalculatorConfig
    {
        string Name { get; set; }
        string ConnectionString { get; set; }
        
    }
}
