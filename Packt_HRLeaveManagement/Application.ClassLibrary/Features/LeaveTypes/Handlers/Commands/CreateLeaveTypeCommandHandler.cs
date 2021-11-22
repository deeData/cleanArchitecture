
using Application.ClassLibrary.DTOs.Validators;
using Application.ClassLibrary.Exceptions;
using Application.ClassLibrary.Features.LeaveTypes.Requests.Commands;
using Application.ClassLibrary.Persistence.Contracts;
using Application.ClassLibrary.Responses;
using AutoMapper;
using Domain.ClassLibrary;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ClassLibrary.Features.LeaveTypes.Handlers.Commands
{
    class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandRepoonse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandRepoonse();
            var validator = new LeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            //will throw an exception if failed
            leaveType = await _leaveTypeRepository.AddAsync(leaveType);

            //return leaveType.Id;
            response.Success = true;
            response.Message = "Creation Successful.";
            response.Id = leaveType.Id;
            return response;
        }
    }


}
