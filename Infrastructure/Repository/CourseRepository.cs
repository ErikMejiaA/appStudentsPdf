
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CourseRepository : ICourseInterface
{
    //varibale de context
    protected readonly appStudentsContext _context;

    //constructor
    public CourseRepository(appStudentsContext context)
    {
        _context = context;
    }

    public void Add(Course entity)
    {
        _context.Set<Course>().Add(entity);
    }

    public void AddRange(IEnumerable<Course> entities)
    {
        _context.Set<Course>().AddRange(entities);
    }

    public IEnumerable<Course> Find(Expression<Func<Course, bool>> expression)
    {
        return _context.Set<Course>().Where(expression);
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Set<Course>().ToListAsync();
    }

    public Task GetByIdAsycn(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> GetByIdAsync(string id)
    {
        return await _context.Set<Course>().FindAsync(id);
    }

    public void Remove(Course entity)
    {
        _context.Set<Course>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<Course> entities)
    {
        _context.Set<Course>().RemoveRange(entities);
    }

    public void Update(Course entity)
    {
        _context.Set<Course>().Update(entity);
    }
}
