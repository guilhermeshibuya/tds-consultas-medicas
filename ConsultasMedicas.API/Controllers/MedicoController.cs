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
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var medicos = await context.Medicos
                .Join(
                    context.Especialidades,
                    medico => medico.IdEspecialidade,
                    especialidade => especialidade.IdEspecialidade,
                    (medico, especialidade) => new
                    {
                        Medico = medico,
                        Especialidade = especialidade
                    })
                .ToListAsync();

            if (medicos == null) return NotFound();

            return Ok(medicos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            //var medico = await context.Medicos.FindAsync(id);
            var medico = await context.Medicos
                .Where(m => m.IdMedico == id)
                .Join(
                    context.Especialidades,
                    medico => medico.IdEspecialidade,
                    especialidade => especialidade.IdEspecialidade,
                    (medico, especialidade) => new
                    {
                        Medico = medico,
                        Especialidade = especialidade
                    })
                .FirstOrDefaultAsync();

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

            return Created($"/{medico.IdMedico}", medico);
        }

        [HttpPost("{id:int}/horarios-disponiveis")]
        public async Task<IActionResult> AddHorarioAsync(
            [FromRoute] int id,
            [FromBody] DateTime horario,
            [FromServices] AppDbContext context
        )
        {
            var medicoToUpdate = await context.Medicos.FindAsync(id);

            if (medicoToUpdate == null) return NotFound();

            var horarioDisponivel = new HorarioModel
            {
                HorarioDisponivel = horario
            };

            medicoToUpdate.HorariosDisponiveis!.Add(horarioDisponivel);

            context.Medicos.Update(medicoToUpdate);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{id}/horarios-disponiveis", horarioDisponivel);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] MedicoModel medico,
            [FromServices] AppDbContext context
        )
        {
            var medicoToUpdate = await context.Medicos.FindAsync(id);

            if (medicoToUpdate == null) return NotFound();

            medicoToUpdate.Nome = medico.Nome;
            medicoToUpdate.IdEspecialidade = medico.IdEspecialidade;
            medicoToUpdate.CRM = medico.CRM;
            //medicoToUpdate.HorariosDisponiveis = medico.HorariosDisponiveis;
            medicoToUpdate.Consultas = medico.Consultas;

            context.Medicos.Update(medicoToUpdate);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(medicoToUpdate);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var medicoToDelete = await context.Medicos.FindAsync(id);

            if (medicoToDelete == null) return NotFound();

            context.Medicos.Remove(medicoToDelete);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(medicoToDelete);
        }
    }
}
