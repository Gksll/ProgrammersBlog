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
            builder.Property(c => c.Text).HasMaxLength(1000);
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

        }
    }
}
