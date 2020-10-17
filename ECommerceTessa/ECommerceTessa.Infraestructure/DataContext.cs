using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerceTessa.Domain.Entities;
using ECommerceTessa.Domain.MetaData;
using static ECommerceTessa.Application.Connection.ConnectionSqlServer;

namespace ECommerceTessa.Infraestructure
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configure SQL Server Connection
            optionsBuilder.UseSqlServer(GetWINDOWSConnectionString);

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

            //Client 
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
                .HasForeignKey(c => c.Category);

                     // one to one relationship price
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Price)
                .WithOne(y => y.Product)
                .HasForeignKey<Price>(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Colour)
                .WithOne(y => y.Product);

            //Province
            modelBuilder.Entity<Province>()
                .HasMany(x => x.Locations)
                .WithOne(y => y.Province);

            //User
            modelBuilder.Entity<User>()
                .HasOne(x => x.Person)
                .WithMany(y => y.Users)
                .HasForeignKey(z => z.PersonId);

            //Waist
            modelBuilder.Entity<Waist>()
                .HasOne(x => x.Colour)
                .WithMany(y => y.Waists)
                .HasForeignKey(w => w.ColourId);



            //Entity Configuration
            modelBuilder.ApplyConfiguration<Address>(new AddressMetaData());

            modelBuilder.ApplyConfiguration<Brand>(new BrandMetaData());

            modelBuilder.ApplyConfiguration<Category>(new CategoryMetaData());

            modelBuilder.ApplyConfiguration<Colour>(new ColourMetaData());

            modelBuilder.ApplyConfiguration<Location>(new LocationMetaData());

            modelBuilder.ApplyConfiguration<Person>(new PersonMetaData());

            modelBuilder.ApplyConfiguration<Price>(new PriceMetaData());

            modelBuilder.ApplyConfiguration<Product>(new ProductMetaData());

            modelBuilder.ApplyConfiguration<Province>(new ProvinceMetaData());

            modelBuilder.ApplyConfiguration<User>(new UserMetaData());

            modelBuilder.ApplyConfiguration<Waist>(new WaistMetaData());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Waist> Waists { get; set; }
    }
}
