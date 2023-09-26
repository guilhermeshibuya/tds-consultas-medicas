using Consultas.API.Data;
using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext context;

        public PacienteController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pacientes = await context.Pacientes
                .Select(p => new
                {
                    p.Id,
                    p.PrimeiroNome,
                    p.Sobrenome,
                    p.CPF,
                    Consultas = p.Consultas.Select(c => new
                    {
                        c.Id,
                        Medico = new
                        {
                            c.IdMedico,
                            c.Medico!.Nome,
                            c.Medico.Sobrenome,
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
                    }).ToList()
                })
                .ToListAsync();

            if (pacientes == null || pacientes.Count == 0)
                return NotFound();

            return Ok(pacientes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paciente = await context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PacienteModel paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();

            return Created($"/{paciente.Id}", paciente);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateByIdAsync([FromRoute] int? id, [FromBody] PacienteModel paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pacienteToUpdate = await context.Pacientes.FindAsync(id);

            if (pacienteToUpdate == null) return NotFound();

            pacienteToUpdate.PrimeiroNome = paciente.PrimeiroNome;
            pacienteToUpdate.Sobrenome = paciente.Sobrenome;
            pacienteToUpdate.CPF = paciente.CPF;

            context.Pacientes.Update(pacienteToUpdate);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(pacienteToUpdate);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paciente = await context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            context.Pacientes.Remove(paciente);

            var result =  await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(paciente);
        }

        private bool PacienteExists(int id)
        {
            return context.Pacientes.Any(e => e.Id == id);
        }
    }
}
