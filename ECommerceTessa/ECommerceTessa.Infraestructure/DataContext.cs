using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerceTessa.Domain.Entities;
using ECommerceTessa.Domain.Entities.Cloudinary;
using ECommerceTessa.Domain.MetaData;
using static ECommerceTessa.Application.Connection.ConnectionSqlServer;

namespace ECommerceTessa.Infraestructure
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configure SQL Server Connection
            optionsBuilder.UseSqlServer(GetSQLConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entidad in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted
                            && x.OriginalValues.Properties
                                .Any(p => p.Name.Contains("ErasedState"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["ErasedState"] = true;
            }

            return base.SaveChangesAsync();
        }


        //Creating Model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Address
            modelBuilder.Entity<Address>()
                .HasOne(x => x.Location)
                .WithMany(y => y.Addresses)
                .HasForeignKey(z => z.LocationId);

            modelBuilder.Entity<Address>()
                .HasOne(x => x.Person)
                .WithMany(y => y.Addresses)
                .HasForeignKey(z => z.PersonId);

            //Brand
            modelBuilder.Entity<Brand>()
                .HasMany(x => x.Products)
                .WithOne(y => y.Brand);

            //Category
            modelBuilder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(y => y.Category);

            //Colour
            modelBuilder.Entity<Colour>()
                .HasOne(x => x.Product)
                .WithMany(y => y.Colour)
                .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Colour>()
                .HasMany(x => x.Waists)
                .WithOne(y => y.Colour);

            //Cliente
            //Corroborar
            /*modelBuilder.Entity<Client>()
                .HasOne(x => x.Person)
                .WithOne(y => y.Client)
                .HasPrincipalKey<Person>(p => p.Id)
                .HasForeignKey<Client>(c => c.PersonId);*/

            //Location
            modelBuilder.Entity<Location>()
                .HasOne(x => x.Province)
                .WithMany(y => y.Locations)
                .HasForeignKey(z => z.ProvinceId);

            modelBuilder.Entity<Location>()
                .HasMany(x => x.Addresses)
                .WithOne(y => y.Location);

            //Movement
            modelBuilder.Entity<Movement>()
                .HasOne(x => x.Voucher)
                .WithMany(y => y.Movements)
                .HasForeignKey(v => v.VoucherId);

            //Person
            modelBuilder.Entity<Person>()
                .HasMany(x => x.Addresses)
                .WithOne(y => y.Person)
                .IsRequired(false); //Relacion opcional (0.1 a *)

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Users)
                .WithOne(y => y.Person);
            //Corroborar
            /*modelBuilder.Entity<Person>()
                .HasOne(x => x.Client)
                .WithOne(y => y.Person)
                .HasPrincipalKey<Person>(p => p.Id);*/

            //Price
            // one to one relationship price
            modelBuilder.Entity<Price>()
                .HasOne(x => x.Product)
                .WithOne(y => y.Price)
                .HasForeignKey<Product>(p => p.Id);

            //Product
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Brand)
                .WithMany(y => y.Products)
                .HasForeignKey(b => b.BrandId);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(c => c.CategoryId);

                     // one to one relationship price
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Price)
                .WithOne(y => y.Product)
                .HasForeignKey<Price>(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Colour)
                .WithOne(y => y.Product);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.ProductPhotos)
                .WithOne(y => y.Product);

            //Product Photo
            modelBuilder.Entity<ProductPhoto>()
                .HasOne(x => x.Product)
                .WithMany(y => y.ProductPhotos)
                .HasForeignKey(p => p.ProductId);

            //Province
            modelBuilder.Entity<Province>()
                .HasMany(x => x.Locations)
                .WithOne(y => y.Province);

            //Stock
                     // one to one relationship
            modelBuilder.Entity<Stock>()
                .HasOne(x => x.Waist)
                .WithOne(y => y.Stock)
                .HasForeignKey<Waist>(w => w.Id);

            //User
            modelBuilder.Entity<User>()
                .HasOne(x => x.Person)
                .WithMany(y => y.Users)
                .HasForeignKey(z => z.PersonId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Vouchers)
                .WithOne(y => y.User);

            //Voucher
            modelBuilder.Entity<Voucher>()
                .HasOne(x => x.User)
                .WithMany(y => y.Vouchers)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Voucher>()
                .HasMany(x => x.Movements)
                .WithOne(y => y.Voucher);

            //Waist
            modelBuilder.Entity<Waist>()
                .HasOne(x => x.Colour)
                .WithMany(y => y.Waists)
                .HasForeignKey(w => w.ColourId);

                    // one to one relationship
            modelBuilder.Entity<Waist>()
                .HasOne(x => x.Stock)
                .WithOne(y => y.Waist)
                .HasForeignKey<Stock>(s => s.Id);



            //Entity Configuration
            modelBuilder.ApplyConfiguration<Address>(new AddressMetaData());

            modelBuilder.ApplyConfiguration<Brand>(new BrandMetaData());

            modelBuilder.ApplyConfiguration<Category>(new CategoryMetaData());

            modelBuilder.ApplyConfiguration<Colour>(new ColourMetaData());

            modelBuilder.ApplyConfiguration<Location>(new LocationMetaData());

            modelBuilder.ApplyConfiguration<Movement>(new MovementMetaData());

            modelBuilder.ApplyConfiguration<Person>(new PersonMetaData());

            modelBuilder.ApplyConfiguration<Price>(new PriceMetaData());

            modelBuilder.ApplyConfiguration<Product>(new ProductMetaData());

            modelBuilder.ApplyConfiguration<ProductPhoto>(new ProductPhotoMetaData());

            modelBuilder.ApplyConfiguration<Province>(new ProvinceMetaData());

            modelBuilder.ApplyConfiguration<Stock>(new StockMetaData());

            modelBuilder.ApplyConfiguration<User>(new UserMetaData());

            modelBuilder.ApplyConfiguration<Voucher>(new VoucherMetaData());

            modelBuilder.ApplyConfiguration<Waist>(new WaistMetaData());

            base.OnModelCreating(modelBuilder);


            //Seed Province
            modelBuilder.Entity<Province>().HasData(
                new Province() { Id = 1, Description = @"Jujuy", ErasedState = false},
                new Province() { Id = 2, Description = @"Salta", ErasedState = false},
                new Province() { Id = 3, Description = @"Formosa", ErasedState = false },
                new Province() { Id = 4, Description = @"Chaco", ErasedState = false },
                new Province() { Id = 5, Description = @"Catamarca", ErasedState = false },
                new Province() { Id = 6, Description = @"Tucuman", ErasedState = false },
                new Province() { Id = 7, Description = @"Santiago del Estero", ErasedState = false },
                new Province() { Id = 8, Description = @"Corrientes", ErasedState = false },
                new Province() { Id = 9, Description = @"Misiones", ErasedState = false },
                new Province() { Id = 10, Description = @"San Juan", ErasedState = false },
                new Province() { Id = 11, Description = @"La Rioja", ErasedState = false },
                new Province() { Id = 12, Description = @"Cordoba", ErasedState = false },
                new Province() { Id = 13, Description = @"Santa Fe", ErasedState = false },
                new Province() { Id = 14, Description = @"Mendoza", ErasedState = false },
                new Province() { Id = 15, Description = @"San Luis", ErasedState = false },
                new Province() { Id = 16, Description = @"Neuquen", ErasedState = false },
                new Province() { Id = 17, Description = @"La Pampa", ErasedState = false },
                new Province() { Id = 18, Description = @"Buenos Aires", ErasedState = false },
                new Province() { Id = 19, Description = @"Rio Negro", ErasedState = false },
                new Province() { Id = 20, Description = @"Chubut", ErasedState = false },
                new Province() { Id = 21, Description = @"Santa Cruz", ErasedState = false },
                new Province() { Id = 22, Description = @"Tierra del Fuego", ErasedState = false },
                new Province() { Id = 23, Description = @"Entre Rios", ErasedState = false }
            );

            //Seed Location
            modelBuilder.Entity<Location>().HasData(
                new Location() { Id = 1, Description = @"San Salvador de Jujuy", ProvinceId = 1, ErasedState = false},
                new Location() { Id = 2, Description = @"Humahuaca", ProvinceId = 1, ErasedState = false },
                new Location() { Id = 3, Description = @"Salta", ProvinceId = 2, ErasedState = false },
                new Location() { Id = 4, Description = @"Rosario de la Frontera", ProvinceId = 2, ErasedState = false },
                new Location() { Id = 5, Description = @"Formosa", ProvinceId = 3, ErasedState = false },
                new Location() { Id = 6, Description = @"Bermejo", ProvinceId = 3, ErasedState = false },
                new Location() { Id = 7, Description = @"Resistencia", ProvinceId = 4, ErasedState = false },
                new Location() { Id = 8, Description = @"Almirante Brown", ProvinceId = 4, ErasedState = false },
                new Location() { Id = 9, Description = @"San Fernando del Valle de Catamarca", ProvinceId = 5, ErasedState = false },
                new Location() { Id = 10, Description = @"Andalgala", ProvinceId = 5, ErasedState = false },
                new Location() { Id = 11, Description = @"San Miguel de Tucuman", ProvinceId = 6, ErasedState = false },
                new Location() { Id = 12, Description = @"Yerba Buena", ProvinceId = 6, ErasedState = false },
                new Location() { Id = 13, Description = @"Santiago del Estero", ProvinceId = 7, ErasedState = false },
                new Location() { Id = 14, Description = @"La Banda", ProvinceId = 7, ErasedState = false },
                new Location() { Id = 15, Description = @"Corrientes", ProvinceId = 8, ErasedState = false },
                new Location() { Id = 16, Description = @"Bella Vista", ProvinceId = 8, ErasedState = false },
                new Location() { Id = 17, Description = @"Posadas", ProvinceId = 9, ErasedState = false },
                new Location() { Id = 18, Description = @"Iguazu", ProvinceId = 9, ErasedState = false },
                new Location() { Id = 19, Description = @"San Juan", ProvinceId = 10, ErasedState = false },
                new Location() { Id = 20, Description = @"Valle Fertil", ProvinceId = 10, ErasedState = false },
                new Location() { Id = 21, Description = @"La Rioja", ProvinceId = 11, ErasedState = false },
                new Location() { Id = 22, Description = @"Arauco", ProvinceId = 11, ErasedState = false },
                new Location() { Id = 23, Description = @"Cordoba", ProvinceId = 12, ErasedState = false },
                new Location() { Id = 24, Description = @"Cruz del Eje", ProvinceId = 12, ErasedState = false },
                new Location() { Id = 25, Description = @"Santa Fe", ProvinceId = 13, ErasedState = false },
                new Location() { Id = 26, Description = @"Santo Tome", ProvinceId = 13, ErasedState = false },
                new Location() { Id = 27, Description = @"Mendoza", ProvinceId = 14, ErasedState = false },
                new Location() { Id = 28, Description = @"Uspallata", ProvinceId = 14, ErasedState = false },
                new Location() { Id = 29, Description = @"San Luis", ProvinceId = 15, ErasedState = false },
                new Location() { Id = 30, Description = @"Chacabuco", ProvinceId = 15, ErasedState = false },
                new Location() { Id = 31, Description = @"Neuquen", ProvinceId = 16, ErasedState = false },
                new Location() { Id = 32, Description = @"Los Lagos", ProvinceId = 16, ErasedState = false },
                new Location() { Id = 33, Description = @"Santa Rosa", ProvinceId = 17, ErasedState = false },
                new Location() { Id = 34, Description = @"Trenel", ProvinceId = 17, ErasedState = false },
                new Location() { Id = 35, Description = @"CABA", ProvinceId = 18, ErasedState = false },
                new Location() { Id = 36, Description = @"La Plata", ProvinceId = 18, ErasedState = false },
                new Location() { Id = 37, Description = @"Viedma", ProvinceId = 19, ErasedState = false },
                new Location() { Id = 38, Description = @"Las Grutas", ProvinceId = 19, ErasedState = false },
                new Location() { Id = 39, Description = @"Rawson", ProvinceId = 20, ErasedState = false },
                new Location() { Id = 40, Description = @"Sarmiento", ProvinceId = 20, ErasedState = false },
                new Location() { Id = 41, Description = @"Rio Gallegos", ProvinceId = 21, ErasedState = false },
                new Location() { Id = 42, Description = @"Rio Chico", ProvinceId = 21, ErasedState = false },
                new Location() { Id = 43, Description = @"Usuahia", ProvinceId = 2, ErasedState = false },
                new Location() { Id = 44, Description = @"Rio Grande", ProvinceId = 2, ErasedState = false },
                new Location() { Id = 45, Description = @"Parana", ProvinceId = 23, ErasedState = false },
                new Location() { Id = 46, Description = @"Concordia", ProvinceId = 23, ErasedState = false }
            );
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Waist> Waists { get; set; }
    }
}
