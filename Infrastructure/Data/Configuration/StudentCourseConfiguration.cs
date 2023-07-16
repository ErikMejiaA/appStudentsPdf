using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.ToTable("StdentsCourses");

        //Definimos las FOREIGN KEY
        builder.HasOne(p => p.Student)
        .WithMany(p => p.StudentsCourses)
        .HasForeignKey(p => p.IdStudent)
        .IsRequired();

        builder.HasOne(p => p.Course)
        .WithMany(p => p.StudentsCourses)
        .HasForeignKey(p => p.IdCourse)
        .IsRequired();

    }
}
