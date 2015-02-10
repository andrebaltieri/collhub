using IdentityAccess.Core.Domain.Model;
using IdentityAccess.Data.Mapping;
using SharedKernel.Domain.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IdentityAccess.Data.Context
{
    public class IdentityAccessDataContext: DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public IdentityAccessDataContext():base("AppDataContext")
        {
            Database.SetInitializer<IdentityAccessDataContext>(new DropCreateDatabaseAlways<IdentityAccessDataContext>());
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
