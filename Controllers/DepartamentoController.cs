using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_admin.Data;

namespace user_admin.Controllers
{
    [ApiController]
    [Route("departamentos")]
    public class DepartamentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartamentoController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            return await _context.Departamentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var Departamento = await _context.Departamentos.FindAsync(id);

            if (Departamento == null)
            {
                return NotFound();
            }

            return Departamento;
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento Departamento)
        {
            _context.Departamentos.Add(Departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamento", new { id = Departamento.Id }, Departamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento Departamento)
        {
            if (id != Departamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(Departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var Departamento = await _context.Departamentos.FindAsync(id);
            if (Departamento == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(Departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.Id == id);
        }
    }
}
