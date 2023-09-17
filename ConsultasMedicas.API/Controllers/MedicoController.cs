using ConsultasMedicas.API.Data;
using ConsultasMedicas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultasMedicas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        [HttpGet("/")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var medicos = await context.Medicos.ToListAsync();

            if (medicos == null) return NotFound();

            return Ok(medicos);
        }

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var medico = await context.Medicos.FirstOrDefaultAsync(x => x.IdMedico == id);

            if (medico == null) return NotFound();

            return Ok(medico);
        }

        [HttpPost("/")]
        public async Task<IActionResult> PostAsync(
            [FromBody] MedicoModel medico,
            [FromServices] AppDbContext context
        )
        {
            context.Medicos.Add(medico);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{medico.IdMedico}", medico);
        }

        [HttpPut("/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] MedicoModel medico,
            [FromServices] AppDbContext context
        )
        {
            var medicoToUpdate = await context.Medicos.FirstOrDefaultAsync(x => x.IdMedico == id);

            if (medicoToUpdate == null) return NotFound();

            medicoToUpdate.Nome = medico.Nome;
            medicoToUpdate.Especialidade = medico.Especialidade;
            medicoToUpdate.CRM = medico.CRM;
            medicoToUpdate.HorariosDisponiveis = medico.HorariosDisponiveis;
            medicoToUpdate.Consultas = medico.Consultas;

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(medicoToUpdate);
        }

        [HttpDelete("/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var medicoToDelete = await context.Medicos.FirstOrDefaultAsync(x => x.IdMedico == id);

            if (medicoToDelete == null) return NotFound();

            context.Medicos.Remove(medicoToDelete);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(medicoToDelete);
        }
    }
}
