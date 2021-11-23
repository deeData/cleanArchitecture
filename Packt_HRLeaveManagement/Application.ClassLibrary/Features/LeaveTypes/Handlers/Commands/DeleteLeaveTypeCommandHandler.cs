﻿using Application.ClassLibrary.Exceptions;
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
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        //Unit is a void type in MediatR
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(request.Id); 

            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            await _leaveTypeRepository.DeleteAsync(leaveType);

            return Unit.Value;
        }
    }
}
