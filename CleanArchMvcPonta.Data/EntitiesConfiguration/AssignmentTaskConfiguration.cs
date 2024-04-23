using CleanArchMvcPonta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvcPonta.Infra.Data.EntitiesConfiguration
{
    public class AssignmentTaskConfiguration : IEntityTypeConfiguration<AssignmentTask>
    {
        public void Configure(EntityTypeBuilder<AssignmentTask> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.CreatedBy).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
        }
    }
}
