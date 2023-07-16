using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        //definimos las propiedades de los atributos de la entidad

        builder.ToTable("Course");

        builder.Property(p => p.IdCourse)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Description)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.NumerStudents)
        .IsRequired()
        .HasColumnType("int");
        
    }
}
