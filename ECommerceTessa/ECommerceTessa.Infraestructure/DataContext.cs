using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECommerceTessa.Domain.Entities;
using ECommerceTessa.Domain.MetaData;

namespace ECommerceTessa.Infraestructure
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configure SQL Server Connection
            //optionsBuilder.UseSqlServer(GetWINDOWSConnectionString);

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

            //Location
            modelBuilder.Entity<Location>()
                .HasOne(x => x.Province)
                .WithMany(y => y.Locations)
                .HasForeignKey(z => z.ProvinceId);

            modelBuilder.Entity<Location>()
                .HasMany(x => x.Addresses)
                .WithOne(y => y.Location);

            //Province
            modelBuilder.Entity<Province>()
                .HasMany(x => x.Locations)
                .WithOne(y => y.Province);




            //Entity Configuration
            modelBuilder.ApplyConfiguration<Address>(new AddressMetaData());

            modelBuilder.ApplyConfiguration<Location>(new LocationMetaData());

            modelBuilder.ApplyConfiguration<Province>(new ProvinceMetaData());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}
