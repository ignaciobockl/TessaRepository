using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure.Repository;
using ECommerceTessa.Service.Implementation;
using ECommerceTessa.Service.Implementation.Address;
using ECommerceTessa.Service.Implementation.Brand;
using ECommerceTessa.Service.Implementation.Category;
using ECommerceTessa.Service.Implementation.Client;
using ECommerceTessa.Service.Implementation.Location;
using ECommerceTessa.Service.Implementation.Movement;
using ECommerceTessa.Service.Implementation.Person;
using ECommerceTessa.Service.Implementation.Price;
using ECommerceTessa.Service.Implementation.Product;
using ECommerceTessa.Service.Implementation.Province;
using ECommerceTessa.Service.Implementation.User;
using ECommerceTessa.Service.Implementation.Waist;
using ECommerceTessa.Service.Interface.Address;
using ECommerceTessa.Service.Interface.Brand;
using ECommerceTessa.Service.Interface.Category;
using ECommerceTessa.Service.Interface.Client;
using ECommerceTessa.Service.Interface.Colour;
using ECommerceTessa.Service.Interface.Location;
using ECommerceTessa.Service.Interface.Movement;
using ECommerceTessa.Service.Interface.Person;
using ECommerceTessa.Service.Interface.Price;
using ECommerceTessa.Service.Interface.Product;
using ECommerceTessa.Service.Interface.Province;
using ECommerceTessa.Service.Interface.User;
using ECommerceTessa.Service.Interface.Voucher;
using ECommerceTessa.Service.Interface.Waist;
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
            
            //Category
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            //Client
            services.AddTransient<IClientRepository, ClientRepository>();

            //Colour
            services.AddTransient<IColourRepository, ColourRepository>();
            
            //Location
            services.AddTransient<ILocationRepository, LocationRepository>();

            //Movement
            services.AddTransient<IMovementRepository, MovementRepository>();

            //Price
            services.AddTransient<IPriceRepository, PriceRepository>();

            //Product
            services.AddTransient<IProductRepository, ProductRepository>();

            //Province
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            
            //Stock
            services.AddTransient<IUserRepository, UserRepository>();

            //User
            services.AddTransient<IUserRepository, UserRepository>();

            //Voucher
            services.AddTransient<IVoucherRepository, VoucherRepository>();

            //Waist
            services.AddTransient<IWaistRepository, WaistRepository>();
        }
    }
}
