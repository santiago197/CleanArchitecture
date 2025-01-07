﻿namespace CleanArchitecture.Application.Exeptions
{
    public sealed class ValidationException:Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; }
    }
}
