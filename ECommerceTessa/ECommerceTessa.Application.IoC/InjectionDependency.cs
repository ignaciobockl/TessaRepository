using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure.Repository;
using ECommerceTessa.Service.Implementation.Address;
using ECommerceTessa.Service.Implementation.Client;
using ECommerceTessa.Service.Implementation.Location;
using ECommerceTessa.Service.Implementation.Person;
using ECommerceTessa.Service.Implementation.Province;
using ECommerceTessa.Service.Implementation.User;
using ECommerceTessa.Service.Interface.Address;
using ECommerceTessa.Service.Interface.Client;
using ECommerceTessa.Service.Interface.Location;
using ECommerceTessa.Service.Interface.Person;
using ECommerceTessa.Service.Interface.Province;
using ECommerceTessa.Service.Interface.User;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceTessa.Application.IoC
{
    public static class InjectionDependency
    {
        public static void ConfigurationServices(IServiceCollection services)
        {
            //version generica
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            ////services.AddTransient<IRepository<Domain.Entities.Province>, Repository<Domain.Entities.Province>>();

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            //services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
