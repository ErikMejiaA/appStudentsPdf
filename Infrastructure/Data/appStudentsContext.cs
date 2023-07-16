using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class appStudentsContext : DbContext
{
    public appStudentsContext(DbContextOptions<appStudentsContext> options) : base(options)
    {

    }

    //aqui van los DbSet<>
    public DbSet<Course> ? Courses { get; set; }
    public DbSet<Student> ? Students { get; set; }
    public DbSet<StudentCourse> ? StudentsCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //definimos la llasves primarias compuestas de la entidad StudentsCouerses
        modelBuilder.Entity<StudentCourse>().HasKey(p => new { p.IdCourse, p.IdStudent});
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    internal void SaveAsync()
    {
        throw new NotImplementedException();
    }
}
