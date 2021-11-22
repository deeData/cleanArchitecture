using Application.ClassLibrary.DTOs.Validators;
using Application.ClassLibrary.Exceptions;
using Application.ClassLibrary.Features.LeaveTypes.Requests.Commands;
using Application.ClassLibrary.Persistence.Contracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit> 
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                //throw new Exception();
                throw new ValidationException(validationResult);

            var leaveType = await _leaveTypeRepository.GetAsync(request.LeaveTypeDto.Id);
            //get dto data and map to model
            _mapper.Map(request.LeaveTypeDto, leaveType);
            await _leaveTypeRepository.UpdateAsync(leaveType);

            return Unit.Value;
        }

    }
}
