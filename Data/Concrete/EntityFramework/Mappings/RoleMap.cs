using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).IsRequired(true);
            builder.Property(r => r.Name).HasMaxLength(50);
            builder.Property(r => r.Description).IsRequired(true);
            builder.Property(r => r.Description).HasMaxLength(250);
            builder.Property(r => r.CreatedByName).IsRequired(true);
            builder.Property(r => r.CreatedByName).HasMaxLength(50);
            builder.Property(r => r.ModifiedByName).IsRequired(true);
            builder.Property(r => r.ModifiedByName).HasMaxLength(50);
            builder.Property(r => r.CreatedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.IsActive).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired(true);
            builder.Property(r => r.Note).HasMaxLength(2000);
            builder.ToTable("Roles");

        }
    }
}
