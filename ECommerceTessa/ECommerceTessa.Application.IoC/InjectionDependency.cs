using ECommerceTessa.Service.Implementation.Province;
using ECommerceTessa.Service.Interface.Province;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Implementation.Address;
using ECommerceTessa.Service.Implementation.Location;
using ECommerceTessa.Service.Implementation.Person;
using ECommerceTessa.Service.Implementation.User;
using ECommerceTessa.Service.Interface.Address;
using ECommerceTessa.Service.Interface.Location;
using ECommerceTessa.Service.Interface.Person;
using ECommerceTessa.Service.Interface.User;

namespace ECommerceTessa.Application.IoC
{
    public class InjectionDependency
    {
        public static void ConfigurationServices(IServiceCollection service)
        {
            //////////////////// EJEMPLO ////////////////////

            //Scoped es cuando queremos servir la misma instancia dentro del mismo contexto de una peticion de HTTP
            //Transient es cuando queremos servir una nueva instancia cada vez q aparesca como dependencia
            //Singleton es cuando queremos servir la misma instancia siempre


            //services.AddTransient<IProvinceRepository, ProvinceRepository>();


            //version generica
            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            ////services.AddTransient<IRepository<Domain.Entities.Province>, Repository<Domain.Entities.Province>>();

            service.AddTransient<IAddressRepository, AddressRepository>();
            service.AddTransient<ILocationRepository, LocationRepository>();
            service.AddTransient<IPersonRepository, PersonRepository>();
            service.AddTransient<IProvinceRepository, ProvinceRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
