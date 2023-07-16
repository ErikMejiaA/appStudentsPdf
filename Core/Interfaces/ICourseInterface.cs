
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface ICourseInterface
{
    //Implemtacion de los metodos de CRUD
    Task<Course> ? GetByIdAsync(string id);
    Task<IEnumerable<Course>> GetAllAsync();
    IEnumerable<Course> Find(Expression<Func<Course, bool>> expression);
    void Add(Course entity);
    void AddRange(IEnumerable<Course> entities);
    void Remove(Course entity);
    void RemoveRange(IEnumerable<Course> entities);
    void Update(Course entity);
       
}
