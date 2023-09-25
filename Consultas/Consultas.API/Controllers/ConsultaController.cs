using Consultas.API.Data;
using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] AppDbContext context
        )
        {
            var consultas = await context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .Include(c => c.Recepcionista)
                .Select(c => new
                {
                    c.Id,
                    Medico = new 
                    {
                        c.IdMedico,
                        c.Medico!.Nome,
                        c.Medico.Sobrenome
                    },
                    Paciente = new
                    {
                        c.IdPaciente,
                        c.Paciente!.PrimeiroNome,
                        c.Paciente.Sobrenome
                    },
                    Recepcionista = new
                    {
                        c.IdRecepcionista,
                        c.Recepcionista!.PrimeiroNome,
                        c.Recepcionista.Sobrenome
                    },
                    c.Data,
                    c.Descricao,
                    TipoConsulta = c.TipoConsulta.ToString(),
                })
                .ToListAsync();

            if (consultas == null) return NotFound();

            return Ok(consultas);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
             [FromRoute] int id,
             [FromServices] AppDbContext context
        )
        {
            var consulta = await context.Consultas.FindAsync(id);

            if (consulta == null) return NotFound("Médico não encontrado!");

            return Ok(consulta);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] ConsultaModel consulta,
            [FromServices] AppDbContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recepcionista = await context.Recepcionistas.FindAsync(consulta.IdRecepcionista);
            var medico = await context.Medicos.FindAsync(consulta.IdMedico);
            var paciente = await context.Pacientes.FindAsync(consulta.IdPaciente);

            if (recepcionista == null || medico == null || paciente == null) return NotFound();

            recepcionista.Consultas!.Add(consulta);
            medico.Consultas!.Add(consulta);
            paciente.Consultas!.Add(consulta);

            context.Recepcionistas.Update(recepcionista);
            context.Medicos.Update(medico);
            context.Pacientes.Update(paciente);

            context.Consultas.Add(consulta);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{consulta.Id}", consulta);
        }
    }
}
