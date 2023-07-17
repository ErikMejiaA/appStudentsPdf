using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class StudentController : BaseApiController
{
     //creamos el constructor de la clase
     private readonly IUnitOfWorkInterface _UnitOfWork;
     
     public StudentController(IUnitOfWorkInterface context)
     {
          _UnitOfWork = context;
     }

     //Metodo GET para listar todos los regitros de la entidad Student de la Db
     [HttpGet]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<IEnumerable<Student>>> Get()
     {
          var students = await _UnitOfWork.Students.GetAllAsync();
          return Ok(students);
     }

     //Metodo GET para traer un unico regitro de la entidad Student de la Db
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<IActionResult> Get(string id)
     {
          var student = await _UnitOfWork.Students.GetByIdAsync(id);
          return Ok(student);
     }

     //Metodo POST para eviar registros a la Db
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<IEnumerable<Student>>> Post(Student student)
     {
          this._UnitOfWork.Students.Add(student);
          await _UnitOfWork.SaveAsync();
          if (student == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = student.IdStudent}, student);
     }   

     //Metodo PUT permite editar un registro de la entidad
     [HttpPut("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<Student>> Put(string id, [FromBody]Student student)
     {
          if (student == null) {
               return NotFound();
          }
          _UnitOfWork.Students.Update(student);
          await _UnitOfWork.SaveAsync();
          return student;
     }  

     //Metodo DELETE permite eliminar un registro de la entidad
     [HttpDelete("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     public async Task<ActionResult> Delete(string id)
     {
          var student = await _UnitOfWork.Students.GetByIdAsync(id);
          if (student == null) {
               return NotFound();
          }
          _UnitOfWork.Students.Remove(student);
          await _UnitOfWork.SaveAsync();
          return NoContent();
     }
        
}
