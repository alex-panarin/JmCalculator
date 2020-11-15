using JmCalculator.Shared.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JmCalculator.Shared.Domain
{
    public class JmPriceResponse 
    {
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
