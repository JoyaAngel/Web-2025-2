using WebAPI.Models;
using WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DoctoresController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/<DoctoresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> Get()
        {
            return await _context.Doctores.ToListAsync();
        }

        // GET api/<DoctoresController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> Get(int id)
        {
            var doctor = await _context.Doctores.FindAsync(id);
            if (doctor == null) return NotFound();
            return doctor;
        }

        // POST api/<DoctoresController>
        [HttpPost]
        public async Task<ActionResult<Doctor>> Post([FromBody] Doctor doctor)
        {
            _context.Doctores.Add(doctor);
            await _context.SaveChangesAsync();
            
            return Ok(doctor);
        }

        // PUT api/<DoctoresController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Doctor>> Put(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id) 
                return BadRequest();
            
            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Doctores.Any(a => a.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return Ok();
        }

        // DELETE api/<DoctoresController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctores.FindAsync(id);
            if (doctor == null) 
                return NotFound();

            _context.Doctores.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
