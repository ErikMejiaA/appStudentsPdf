
namespace Core.Interfaces;

public interface IUnitOfWorkInterface
{
    //agregamos las interfaces creadas 
    ICourseInterface Courses { get; set; }
    IStudentInterface Students { get; set; }

    Task<int> SaveAsync();
}
