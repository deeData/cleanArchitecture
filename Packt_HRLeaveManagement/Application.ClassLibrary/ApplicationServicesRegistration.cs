using Application.ClassLibrary.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace Application.ClassLibrary
{
    public static class ApplicationServicesRegistration
    {
        //abstracting services to just this project
        //call this method to register DI
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services) 
        {
            //will need to every mapping profile
            //services.AddAutoMapper(typeof(MappingProfile));
            //below will reference every mapping profile that inherits AutoMapper's 'Profile' class. Automapper is already set up as DI in assembly build
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }


    }
}
