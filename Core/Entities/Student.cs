using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Student
{
    //definimos los atribuctos de la entidad
    [Key]
    public string ? IdStudent { get; set; }
    public string ? Name { get; set; }
    public int Edad { get; set; }
    public string ? Email { get; set; }

    //definimos la ICollection
    public ICollection<StudentCourse> ? StudentsCourses { get; set;}

        
}
