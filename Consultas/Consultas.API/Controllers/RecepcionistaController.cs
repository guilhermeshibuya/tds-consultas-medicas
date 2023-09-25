using Consultas.API.Data;
using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecepcionistaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] AppDbContext context
        )
        {
            var recepcionistas = await context.Recepcionistas
                .Select(r => new
                {
                    r.Id,
                    r.PrimeiroNome,
                    r.Sobrenome,
                    r.CPF,
                    r.Telefone,
                    Consultas = r.Consultas!.Select(c => new
                    {
                        c.Id,
                        Paciente = new
                        {
                            c.IdPaciente,
                            c.Paciente!.PrimeiroNome,
                            c.Paciente.Sobrenome
                        },
                        Medico = new
                        {
                            c.IdMedico,
                            c.Medico!.Nome,
                            c.Medico.Sobrenome
                        },
                        c.Data,
                        c.Descricao,
                        TipoConsulta = c.TipoConsulta.ToString(),
                    }).ToList()
                })
                .ToListAsync();

            if (recepcionistas == null) return NotFound();

            return Ok(recepcionistas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
             [FromRoute] int id,
             [FromServices] AppDbContext context
        )
        {
            var recepcionista = await context.Recepcionistas.FindAsync(id);

            if (recepcionista == null) return NotFound("Médico não encontrado!");

            return Ok(recepcionista);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] RecepcionistaModel recepcionista,
            [FromServices] AppDbContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Recepcionistas.Add(recepcionista);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{recepcionista.Id}", recepcionista);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(
          [FromRoute] int id,
          [FromBody] RecepcionistaModel recepcionista,
          [FromServices] AppDbContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recepcionistaToUpdate = await context.Recepcionistas.FindAsync(id);

            if (recepcionistaToUpdate == null) return NotFound("Recepcionista não encontrado!");

            recepcionistaToUpdate.PrimeiroNome = recepcionista.PrimeiroNome;
            recepcionistaToUpdate.Sobrenome = recepcionista.Sobrenome;
            recepcionistaToUpdate.CPF = recepcionista.CPF;
            recepcionistaToUpdate.Telefone = recepcionista.Telefone;

            context.Recepcionistas.Update(recepcionistaToUpdate);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(recepcionistaToUpdate);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var recepcionistaToDelete = await context.Recepcionistas.FindAsync(id);

            if (recepcionistaToDelete == null) return NotFound("Recepcionista não encontrado!");

            context.Recepcionistas.Remove(recepcionistaToDelete);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(recepcionistaToDelete);
        }
    }
}
