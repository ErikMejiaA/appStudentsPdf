
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWorkInterface, IDisposable
{
    private readonly appStudentsContext _context;

    //generamos las variables de cada repositorio creado 
    private CourseRepository ? _courses;
    private StudentRepository ? _students;

    public UnitOfWork(appStudentsContext context)
    {
        _context = context;
    }

    //generamos el constructor de las variables del repositorio
    //Courses
    public ICourseInterface Courses
    {
        get 
        {
            if (_courses == null) {
                _courses = new CourseRepository(_context);
            }
            return _courses;
        }

        set 
        {
            if (_courses == null) {
                _courses = new CourseRepository(_context);
            }
        }
    }

    //Students
    public IStudentInterface Students
    {
        get
        {
            if (_students == null) {
                _students = new StudentRepository(_context);
            }
            return _students;
        }

        set 
        {
             if (_students == null) {
                _students = new StudentRepository(_context);
            }
        }
    }

    public void Dispose()
    {
        _context.Dispose();  //destruir el contexto si no se esta Utilizando, liberar memoria
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync(); //guardar los datos enviados por el metodo Post en la Db
    }
}
