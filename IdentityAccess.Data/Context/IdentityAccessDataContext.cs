using IdentityAccess.Core.Domain.Model;
using IdentityAccess.Data.Mapping;
using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Data.Context
{
    public class IdentityAccessDataContext: DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public IdentityAccessDataContext():base("AppDataContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TenantMap());
        }

        public void Commit()
        {
            this.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
