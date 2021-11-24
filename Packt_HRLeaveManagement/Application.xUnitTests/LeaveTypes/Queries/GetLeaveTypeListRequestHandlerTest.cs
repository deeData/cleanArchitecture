using Application.ClassLibrary.DTOs;
using Application.ClassLibrary.Features.LeaveTypes.Handlers.Queries;
using Application.ClassLibrary.Features.LeaveTypes.Requests.Queries;
using Application.ClassLibrary.Persistence.Contracts;
using Application.ClassLibrary.Profiles;
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

namespace Application.xUnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        //DO NOT USE DB DEPENDENCY INJECTION IN TESTS
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        //in constructor, do not DI. 
        public GetLeaveTypeListRequestHandlerTest()
        {
            //use a Mock Repo previously created from a repo test so that you are using dummy data and not from real data
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            //configure mapper without DI
            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        //tells app that this is a unit test
        //assertions need to be fact, or else as fails
        [Fact]
        public async Task GetLeaveTypeListTest() 
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            //assertions
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(2);

        }

    }
}
