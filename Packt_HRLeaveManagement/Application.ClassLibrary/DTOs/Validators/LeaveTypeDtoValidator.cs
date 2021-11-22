using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.DTOs.Validators 
{
    public class LeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public LeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.DefaultDays)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .GreaterThan(0).WithMessage("{PropertyName} must be at least 1 day.")
              .LessThan(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} days.");
              
        }
    }
}
