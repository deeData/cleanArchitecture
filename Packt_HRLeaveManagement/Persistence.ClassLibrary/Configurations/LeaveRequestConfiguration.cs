using Application.ClassLibrary.DTOs.LeaveRequest;
using Domain.ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ClassLibrary.Configurations
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        //implement interface
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
        }
    }
}
