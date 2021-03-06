using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired(true);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Username).IsRequired(true);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Username).HasMaxLength(30);
            builder.Property(u => u.PasswordHash).IsRequired(true);
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(u => u.PasswordHash).HasMaxLength(1000);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);
            builder.Property(u => u.Description).HasMaxLength(500);
            builder.Property(u => u.CreatedByName).IsRequired(true);
            builder.Property(u => u.CreatedByName).HasMaxLength(150);
            builder.Property(u => u.ModifiedByName).IsRequired(true);
            builder.Property(u => u.ModifiedByName).HasMaxLength(150);
            builder.Property(u => u.CreatedDate).IsRequired(true);
            builder.Property(u => u.ModifiedDate).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true);
            builder.Property(u => u.IsDeleted).IsRequired(true);
            builder.Property(u => u.Note).HasMaxLength(2000);
            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.ToTable("Users");
            builder.HasData(new User
            {
                Id = 1,
                RoleId = 1,
                FirstName = "Göksel",
                LastName = "Doğan",
                Username = "HunterGksl",
                Email = "gokselgokseldogan.com.tr",
                Description = "İlk admin kullanıcısı",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Admin Rolünü ve yetkisini içerir",
                PasswordHash = Encoding.ASCII.GetBytes("e64b78fc3bc91bcbc7dc232ba8ec59e0"),
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQh6rPd9hx_fUGzorshx1fG5kzUM5FGCSYmm2YBuLU3uSFFI5BviIWd6hrHbw&s"

            }); ; 

        }
    }
}
