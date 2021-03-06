using Application.ClassLibrary.DTOs;
using Application.ClassLibrary.Exceptions;
using Application.ClassLibrary.Features.LeaveTypes.Handlers.Commands;
using Application.ClassLibrary.Features.LeaveTypes.Requests.Commands;
using Application.ClassLibrary.Persistence.Contracts;
using Application.ClassLibrary.Profiles;
using Application.ClassLibrary.Responses;
using Application.xUnitTests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.xUnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly LeaveTypeDto _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;
        public CreateLeaveTypeCommandHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
            _leaveTypeDto = new LeaveTypeDto
            {
                DefaultDays = 15,
                Name = "Test Creted New Leave Type"
            };
        }


        [Fact]
        public async Task Valid_LeaveType_Added() 
        {
            var result = await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandRepoonse>();

            var leaveTypes = await _mockRepo.Object.GetAllAsync();
            leaveTypes.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Invalid_LeaveType_Added()
        {
            //replace default days value
            _leaveTypeDto.DefaultDays = -1;

            //ValidationException ex = await Should.ThrowAsync<ValidationException>
            //    ( async () =>
            //        await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto}, CancellationToken.None)
            //    );

            var result = await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto}, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAllAsync();
            
            leaveTypes.Count.ShouldBe(2);
            //ex.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandRepoonse>();
        }

    }
}
