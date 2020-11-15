using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JmCalculator.Shared.Models
{
    public class JmPrice
    {
        [Required]
        [EnumDataType(typeof(JmUnitTypes))]
        public JmUnitTypes UnitType { get; set; }
        [Required]
        public int Height { get; set; }
        public decimal[] Values { get; set; } = new decimal[] { };
    }
}
