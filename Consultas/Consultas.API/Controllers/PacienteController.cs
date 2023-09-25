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
            var pacientes = await context.Pacientes.ToListAsync();

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
        public async Task<IActionResult> UpdateByIdAsync(int id, [FromBody] PacienteModel updatedPaciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedPaciente.Id)
            {
                return BadRequest("ID da URL não corresponde ao ID do paciente.");
            }

            context.Entry(updatedPaciente).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacienteExists(int id)
        {
            return context.Pacientes.Any(e => e.Id == id);
        }
    }
}
