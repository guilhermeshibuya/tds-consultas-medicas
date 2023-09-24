using ConsultasMedicas.API.Data;
using ConsultasMedicas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultasMedicas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var medico = await context.Medicos.ToListAsync();

            if (medico == null) return NotFound();

            return Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] MedicoModel medico,
            [FromServices] AppDbContext context
        )
        {
            context.Medicos.Add(medico);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{medico.}")

        }
    }
}
