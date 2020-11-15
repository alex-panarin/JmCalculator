using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JmCalculator.Shared.Validation
{
    public class JmPriceValidator : IJmPriceValidator
    {
        public void Validate(JmPriceRequest request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(request, context, results, true))
            {
                StringBuilder sb = new StringBuilder();

                foreach (var result in results)
                {
                    sb.Append($"{result.ErrorMessage}; ");
                }

                throw new ValidationException(sb.ToString());
            }
        }
    }
}
