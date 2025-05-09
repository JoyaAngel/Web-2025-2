using ProyectoWebApi.Data;
using ProyectoWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoWebApi.Controllers
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlumnosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlumnosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
