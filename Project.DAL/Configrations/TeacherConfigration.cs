using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Entities;

namespace Project.DAL.Configrations
{
    public class TeacherConfigration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
           builder.Property(x=>x.FullName).IsRequired().HasMaxLength(20);
           
        }
    }
}
