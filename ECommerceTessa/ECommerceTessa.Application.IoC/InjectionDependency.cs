using ECommerceTessa.Service.Implementation.Province;
using ECommerceTessa.Service.Interface.Province;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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

            service.AddTransient<IProvinceRepository, ProvinceRepository>();
        }
    }
}
