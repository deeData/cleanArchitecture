using Application.ClassLibrary.DTOs.LeaveRequest;
using Application.ClassLibrary.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ClassLibrary.DTOs.Validators
{
    public class LeaveRequestDtoValidator : AbstractValidator<LeaveRequestDto>
    {
        private ILeaveTypeRepository _leaveTypeRepository;

        //DI repository
        public LeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}.");

            RuleFor(p => p.StartDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}.");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                //cancellation token
                .MustAsync(async (id, token) => 
                {
                    bool leaveTypeExists = await _leaveTypeRepository.IsExists(id);
                    return !leaveTypeExists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
