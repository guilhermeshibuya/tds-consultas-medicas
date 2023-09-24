using ConsultasMedicas.API.Data;
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
    }
}
