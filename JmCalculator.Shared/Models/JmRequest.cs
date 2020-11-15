using JmCalculator.Shared.Extensions;
using System.ComponentModel.DataAnnotations;

namespace JmCalculator.Shared.Models
{

    public class JmRequest
    {
        [Required]
        public JmUnitTypes UnitType { get; set; } = JmUnitTypes.JmComfort;
        [Required]
        public JmOperationTypes OperationType { get; set; } = JmOperationTypes.Hand;
    }
}
