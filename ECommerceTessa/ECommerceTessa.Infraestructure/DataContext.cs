using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
    }
}
