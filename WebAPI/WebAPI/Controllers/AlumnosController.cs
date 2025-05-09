using WebAPI.Data;
using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public AlumnosController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<AlumnosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> Get()
        {
            return await _context.Alumnos.ToListAsync();
        }

        // GET api/<AlumnosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> Get(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return alumno;
        }

        // POST api/<AlumnosController>
        [HttpPost]
        public async Task<ActionResult<Alumno>> Post([FromBody] Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();

            return Ok(alumno);
        }

        // PUT api/<AlumnosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest("El ID del alumno no coincide");
            }

            _context.Entry(alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Alumnos.Any(a => a.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return Ok();
        }

        // DELETE api/<AlumnosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
                return NotFound();

            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
