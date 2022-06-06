using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).IsRequired(true);
            builder.Property(c => c.Text).HasMaxLength(100000);
            builder.Property(c => c.CreatedByName).IsRequired(true);
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired(true);
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.IsDeleted).IsRequired(true);
            builder.Property(c => c.Note).HasMaxLength(2000);
            builder.HasOne<Article>(navigationExpression:c=>c.Article).WithMany(a=>a.Comments).HasForeignKey(c=>c.ArticleId);
            builder.ToTable("Comments");
            builder.HasData(new Comment {
            Id=1,
            ArticleId=1,
            Text= "Pellentesque luctus egestas eleifend. Mauris tempor velit vitae leo facilisis porttitor. Praesent turpis nulla, cursus vitae sem sed, placerat commodo mi. Nam vitae leo quis orci lacinia tincidunt ut nec nibh. Vestibulum tellus nisi, dapibus vel volutpat ut, facilisis sit amet mauris. Duis eu egestas lacus. Nullam rutrum porttitor justo, at volutpat urna venenatis id. Nullam luctus, ligula sit amet mollis tincidunt, dui ligula imperdiet magna, sed scelerisque nulla nibh et metus. Maecenas tempor porttitor nunc vel consequat. Sed nisi nisi, condimentum id posuere et, sodales eget augue. Suspendisse potenti. Phasellus purus lorem, suscipit vel eleifend eu, venenatis vel libero. Aenean pretium quam ac leo sodales varius.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# blok yorumu"
            },
            new Comment
            {
                Id = 2,
                ArticleId = 2,
                Text = "Pellentesque luctus egestas eleifend. Mauris tempor velit vitae leo facilisis porttitor. Praesent turpis nulla, cursus vitae sem sed, placerat commodo mi. Nam vitae leo quis orci lacinia tincidunt ut nec nibh. Vestibulum tellus nisi, dapibus vel volutpat ut, facilisis sit amet mauris. Duis eu egestas lacus. Nullam rutrum porttitor justo, at volutpat urna venenatis id. Nullam luctus, ligula sit amet mollis tincidunt, dui ligula imperdiet magna, sed scelerisque nulla nibh et metus. Maecenas tempor porttitor nunc vel consequat. Sed nisi nisi, condimentum id posuere et, sodales eget augue. Suspendisse potenti. Phasellus purus lorem, suscipit vel eleifend eu, venenatis vel libero. Aenean pretium quam ac leo sodales varius.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Java blok yorumu"
            }, new Comment
            {
                Id = 3,
                ArticleId = 3,
                Text = "Pellentesque luctus egestas eleifend. Mauris tempor velit vitae leo facilisis porttitor. Praesent turpis nulla, cursus vitae sem sed, placerat commodo mi. Nam vitae leo quis orci lacinia tincidunt ut nec nibh. Vestibulum tellus nisi, dapibus vel volutpat ut, facilisis sit amet mauris. Duis eu egestas lacus. Nullam rutrum porttitor justo, at volutpat urna venenatis id. Nullam luctus, ligula sit amet mollis tincidunt, dui ligula imperdiet magna, sed scelerisque nulla nibh et metus. Maecenas tempor porttitor nunc vel consequat. Sed nisi nisi, condimentum id posuere et, sodales eget augue. Suspendisse potenti. Phasellus purus lorem, suscipit vel eleifend eu, venenatis vel libero. Aenean pretium quam ac leo sodales varius.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Vue blok yorumu"
            });

        }
    }
}
