using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        //definimos las propiedades de los atributos de la entidad

        builder.ToTable("Students");

        builder.Property(p => p.IdStudent)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Edad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Email)
        .IsUnique();

        
    }
}
