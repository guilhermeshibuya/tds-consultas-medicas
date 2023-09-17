using ConsultasMedicas.API.Data;
using ConsultasMedicas.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultasMedicas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        [HttpGet("/")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var pacientes = await context.Pacientes.ToListAsync();

            if (pacientes == null) return NotFound();

            return Ok(pacientes);
        }

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var paciente = await context.Pacientes.FirstOrDefaultAsync(x => x.IdPaciente == id);

            if (paciente == null) return NotFound();

            return Ok(paciente);
        }

        [HttpPost("/")]
        public async Task<IActionResult> PostAsync(
            [FromBody] PacienteModel paciente,
            [FromServices] AppDbContext context
        )
        {
            context.Pacientes.Add(paciente);
            
            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{paciente.IdPaciente}", paciente);
        }

        [HttpPut("/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] PacienteModel paciente,
            [FromServices] AppDbContext context
        )
        {
            var pacienteToUpdate = await context.Pacientes.FirstOrDefaultAsync(x => x.IdPaciente == id);

            if (pacienteToUpdate == null) return NotFound();

            pacienteToUpdate.Nome = paciente.Nome;
            pacienteToUpdate.Sobrenome = paciente.Sobrenome;
            pacienteToUpdate.CPF = paciente.CPF;
            pacienteToUpdate.HistoricoMedico = paciente.HistoricoMedico;
            pacienteToUpdate.Consultas = paciente.Consultas;

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(pacienteToUpdate);
        }

        [HttpDelete("/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var pacienteToDelete = await context.Pacientes.FirstOrDefaultAsync(x => x.IdPaciente == id);

            if (pacienteToDelete == null) return NotFound();

            context.Pacientes.Remove(pacienteToDelete);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(pacienteToDelete);
        }
    }
}
