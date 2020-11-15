using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace JmCalculator.Shared.Models
{
    public class JmOption
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } = 0;
        [Required]
        [EnumDataType(typeof(JmOperationTypes))]
        public JmOperationTypes OperationType { get; set; } = JmOperationTypes.Hand;
        [Required]
        [EnumDataType(typeof(JmUnitTypes))]
        public JmUnitTypes UnitType { get; set; } = JmUnitTypes.JmComfort;

        public static bool operator == (JmOption op1, JmOption op2) => op1.Equals(op2);
        public static bool operator != (JmOption op1, JmOption op2) => !op1.Equals(op2);
        public override bool Equals(object obj)
        {
            var option = obj as JmOption;
            return option != null && option.Name == Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}


