using IdentityAccess.Core.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace IdentityAccess.Data.Mapping
{
    public class TenantMap : EntityTypeConfiguration<Tenant>
    {
        public TenantMap()
        {
            ToTable("Tenant");

            HasKey(x => x.Id);

            //Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Name).HasMaxLength(60).IsRequired();
        }
    }
}
