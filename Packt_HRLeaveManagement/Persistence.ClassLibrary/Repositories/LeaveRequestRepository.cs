using Application.ClassLibrary.Persistence.Contracts;
using Domain.ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ClassLibrary.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestsWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                //cannot use Include in FindAsync
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }
    }
}
