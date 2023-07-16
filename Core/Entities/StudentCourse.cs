namespace Core.Entities;

public class StudentCourse
{
    //definimos las llaves foranes 
    public string ? IdStudent { get; set; }
    public string ? IdCourse { get; set; }

    //definimos la referencas a las entidades
    public Course ? Course { get; set; }
    public Student ? Student { get; set; }
    
        
}
