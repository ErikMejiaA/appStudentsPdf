
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class CourseController : BaseApiController
{
    //creamos el constructor
    private readonly IUnitOfWorkInterface _UnitOfWork;
    
    public CourseController(IUnitOfWorkInterface UnitOfWork)
    {
       _UnitOfWork = UnitOfWork;
    }

    //Metodo GET para traer todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Course>>> Get()
    {
         var courses = await _UnitOfWork.Courses.GetAllAsync();
         return Ok(courses);
    }

    // Metodo GET para obtener un unico registro 
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
         var course = await _UnitOfWork.Courses.GetByIdAsync(id);
         return Ok(course);
    } 

    //Metodo POST para eviar registros a la Db
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Course>>> Post(Course course)
    {
        this._UnitOfWork.Courses.Add(course);
        await _UnitOfWork.SaveAsync();
        if (course == null) {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = course.IdCourse}, course);
    }

        
}
