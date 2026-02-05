using Microsoft.AspNetCore.Mvc;
using StudentApi.Data;
using StudentApi.Models;
using System.Linq;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Students.ToList());

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            var s = _context.Students.Find(id);
            if (s == null)
                return NotFound("Student not found");

            s.Name = student.Name;
            s.Age = student.Age;
            s.Email = student.Email;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSt(int id)
        {
            var s = _context.Students.Find(id);
            if (s == null)
                return NotFound("Student not found");

            _context.Students.Remove(s);
            _context.SaveChanges();
            return NoContent();
        }
    }
}