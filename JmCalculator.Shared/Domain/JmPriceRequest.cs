using JmCalculator.Shared.Extensions;
using JmCalculator.Shared.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JmCalculator.Shared.Domain
{
    public class JmPriceRequest : JmRequest
    {
        [Required]
        [Range(500, 6000, ErrorMessage = "Width should be no less than 500 mm and no grater than 6000 mm")]
        public int Width { get; set; } = 500;
        [Required]
        [Range(500, 6000, ErrorMessage = "Height should be no less than 500 mm and no grater than 6000 mm")]
        public int Height { get; set; } = 500;
        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity should be no less than 1 and no more than 1000")]
        public int Quantity { get; set; } = 1;
        public JmColorTypes SlatColor { get; set; } = JmColorTypes.RAL9006;
        public JmColorTypes ProfileColor { get; set; } = JmColorTypes.RAL9006;
        public JmComponentColorTypes ComponentColor { get; set; } = JmComponentColorTypes.Grey;

        public JmOptionDomain HeadRailBraket { get; set; } = JmHeadrailBracketTypes.DK3.CreateOption();
        public JmOptionDomain GuidingRailBracket { get; set; } = JmRailBracketTypes.K1.CreateOption();
        public JmOptionDomain OperationControl { get; set; } = JmHandOperationTypes.ExteriorGear.CreateOption();
        public JmOptionDomain LeftGuidingRail { get; set; } = JmGuidingRailTypes.VL2.CreateOption();
        public JmOptionDomain RightGuidingRail { get; set; } = JmGuidingRailTypes.VL2.CreateOption();


    }
}
