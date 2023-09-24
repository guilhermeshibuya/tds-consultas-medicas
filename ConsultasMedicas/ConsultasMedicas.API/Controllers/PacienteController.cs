using ConsultasMedicas.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Healthy.Web.Controllers;



[ApiController]
[Route("api/[controller]")]
public class PacienteController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromServices] AppDbContext context
    )
    {
        var paciente = await context.Pacientes.ToListAsync();

        if (paciente == null) return NotFound();

        return Ok(paciente);
    }
}
