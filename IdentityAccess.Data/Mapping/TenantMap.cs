using IdentityAccess.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
