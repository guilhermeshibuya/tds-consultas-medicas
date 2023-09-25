using Consultas.API.Data;
using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] AppDbContext context
        )
        {
            var especialidades = await context.Especialidades
                .Include(e => e.Medicos)
                .ToListAsync();

            if (especialidades == null) return NotFound();

            return Ok(especialidades);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] EspecialidadeModel especialidade,
            [FromServices] AppDbContext context
        )
        {
            context.Especialidades.Add(especialidade);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{especialidade.Id}", especialidade);
        }
    }
}
