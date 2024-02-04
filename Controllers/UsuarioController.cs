using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_admin.Data;

using user_admin.Models;
namespace user_admin.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetUsuarios(int departamentoId = 0, int cargoId = 0, int pageNumber = 1, int pageSize = 10)
        {
            var usersQuery = _context.Usuarios.Include(u => u.Cargo)
                .Include(u => u.Departamento).AsQueryable(); // Asegúrate de ajustar esto a tu contexto y entidad


            if (departamentoId != 0) {
                usersQuery = usersQuery.Where(u => u.IdDepartamento == departamentoId);
            }
            if (cargoId != 0)
            {
                usersQuery = usersQuery.Where(u => u.IdCargo == cargoId);
            }

            var pagedUsers = await usersQuery.GetPagedAsync(pageNumber, pageSize);

            return Ok(pagedUsers);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.Include(u => u.Cargo)
                .Include(u => u.Departamento)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuario(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioModel usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var usuarioActualizado = await _context.Usuarios.FindAsync(id);
            // Devolver el usuario actualizado
            return Ok(usuarioActualizado);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

    }
}
