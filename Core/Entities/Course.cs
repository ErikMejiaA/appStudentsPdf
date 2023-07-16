using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Course
{
    //definios los atributos de la entidad
    [Key]
    public string ? IdCourse { get; set; }
    public string ? Description { get; set; }
    public int NumerStudents { get; set; }
        
    //definimos la ICollection
    public ICollection<StudentCourse> ? StudentsCourses { get; set;}
}
