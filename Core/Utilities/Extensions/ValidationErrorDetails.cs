using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Utilities.Extensions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
