using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure.Repository;
using ECommerceTessa.Service.Implementation.Address;
using ECommerceTessa.Service.Implementation.Brand;
using ECommerceTessa.Service.Implementation.Client;
using ECommerceTessa.Service.Implementation.Location;
using ECommerceTessa.Service.Implementation.Person;
using ECommerceTessa.Service.Implementation.Province;
using ECommerceTessa.Service.Implementation.User;
using ECommerceTessa.Service.Interface.Address;
using ECommerceTessa.Service.Interface.Brand;
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

            //Address
            services.AddTransient<IAddressRepository, AddressRepository>();
            
            //Brand
            services.AddTransient<IBrandRepository, BrandRepository>();
            
            //Client
            services.AddTransient<IClientRepository, ClientRepository>();
            
            //Location
            services.AddTransient<ILocationRepository, LocationRepository>();

            //Province
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            
            //User
            services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
