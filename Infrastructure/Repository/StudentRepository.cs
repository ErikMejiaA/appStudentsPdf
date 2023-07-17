
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class StudentRepository : IStudentInterface
{
    //variable de contexto
    protected readonly appStudentsContext _context;

    //constructor
    public StudentRepository(appStudentsContext context)
    {
        _context = context;
    }

    public void Add(Student entity)
    {
        _context.Set<Student>().Add(entity);
    }

    public void AddRange(IEnumerable<Student> entities)
    {
        _context.Set<Student>().AddRange(entities);
    }

    public IEnumerable<Student> Find(Expression<Func<Student, bool>> expression)
    {
        return _context.Set<Student>().Where(expression);
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Set<Student>().ToListAsync();
    }

    public async Task<Student> GetByIdAsync(string id)
    {
        return await _context.Set<Student>().FindAsync(id);
    }

    public void Remove(Student entity)
    {
        _context.Set<Student>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Student> entities)
    {
        _context.Set<Student>().RemoveRange(entities);
    }

    public void Update(Student entity)
    {
        _context.Set<Student>().Update(entity);
    }
}
