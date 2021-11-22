using Application.ClassLibrary.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.ClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ClassLibrary
{
    public static class PersistenceServicesRegistration
    {
        //method
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("LeaveManagementDb")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}
