
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IStudentInterface
{
    //Implematcion de los metodos del CRUD
    Task<Student> ? GetByIdAsync(string id);
    Task<IEnumerable<Student>> GetAllAsync();
    IEnumerable<Student> Find(Expression<Func<Student, bool>> expression);
    void Add(Student entity);
    void AddRange(IEnumerable<Student> entities);
    void Remove(Student entity);
    void RemoveRange(IEnumerable<Student> entities);
    void Update(Student entity);
        
}
