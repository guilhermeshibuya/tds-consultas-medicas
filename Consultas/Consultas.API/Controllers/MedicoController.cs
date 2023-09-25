using Consultas.API.Data;
using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] AppDbContext context
        )
        {
            var medicos = await context.Medicos
                .Include(m => m.Especialidade)
                .Select(m => new
                {
                    m.Id,
                    m.Nome,
                    m.Sobrenome,
                    m.Email,
                    m.CRM,
                    Especialidade = new
                    {
                        m.Especialidade!.Nome,
                    },
                    HorariosDisponiveis = m.HorariosDisponiveis.Select(h => new
                    {
                        h.DataHorario
                    }).ToList(),
                })
                .ToListAsync();

            if (medicos == null) return NotFound();

            return Ok(medicos);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] MedicoModel medico,
            [FromServices] AppDbContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidade = await context.Especialidades.FindAsync(medico.IdEspecialidade);

            if (especialidade == null) return NotFound("Especialidade não encontrada!");

            var newMedico = new MedicoModel
            {
                Nome = medico.Nome,
                Sobrenome = medico.Sobrenome,
                Email = medico.Email,
                CRM = medico.CRM,
                IdEspecialidade = medico.IdEspecialidade,
            };

            especialidade!.Medicos!.Add(newMedico);

            context.Medicos.Add(newMedico);

            context.Especialidades.Update(especialidade);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{newMedico.Id}", newMedico);
        }

        [HttpPost("{id:int}/horarios")]
        public async Task<IActionResult> AddHorarioAsync(
            [FromRoute] int id,
            [FromBody] HorarioModel horario,
            [FromServices] AppDbContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicoToUpdate = await context.Medicos.FindAsync(id);

            if (medicoToUpdate == null) return NotFound("Médico não encontrado!");

            medicoToUpdate.HorariosDisponiveis!.Add(horario);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(medicoToUpdate);
        }
    }
}
