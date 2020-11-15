using System;
using System.Collections.Generic;
using System.Text;

namespace JmCalculator.Shared.Validation
{
    public interface IJmObjectValidator<TModel>
    {
        void Validate(TModel model);
    }
}
