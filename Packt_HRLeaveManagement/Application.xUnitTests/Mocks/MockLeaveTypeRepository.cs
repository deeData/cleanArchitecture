using Application.ClassLibrary.Persistence.Contracts;
using Domain.ClassLibrary;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.xUnitTests.Mocks
{
    //setting up a mock repository for testing
    public static class MockLeaveTypeRepository
    {
        //decorated with keyword Mock will mock the repository
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository() 
        {
            //can be fictional examples in this test
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                { 
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                { 
                    Id = 2,
                    DefaultDays = 15,
                    Name = "Test Sick"
                }
            };

            //intialize
            var mockRepo = new Mock<ILeaveTypeRepository>();
            //setup with the methods in ILeaveTypeRepository
            //setup to test GetAllAsync method, leaveTypes is the mock database data
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(leaveTypes);
            //setup to test AddAsync method
            //can only call method when LeaveType obj is passed in
            mockRepo.Setup(r => r.AddAsync(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) => {
                //when called, add the obj and return obj
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepo;
        }
    }
}
