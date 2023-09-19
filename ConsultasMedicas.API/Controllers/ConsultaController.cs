using ConsultasMedicas.API.Data;
using ConsultasMedicas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultasMedicas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        [HttpGet]//Mostra todas as consulta
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var consulta = await context.Consultas.ToListAsync();

            if (consulta == null) return NotFound();
            
            return Ok(consulta);
        }

        [HttpGet("{id:int}")]//Mostra consulta expecifica
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var consulta = await context.Consultas.FindAsync(id);

            if (consulta == null) return NotFound();

            return Ok(consulta);
        }

        [HttpPost]//Cadastra uma consulta
        public async Task<IActionResult> PostAsync(
            [FromBody] ConsultaModel consulta,
            [FromServices] AppDbContext context
        )
        {
            context.Consultas.Add(consulta);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{consulta.IdConsulta}", consulta);
        }

        [HttpPut("{id:int}")]//Atualiza a Consulta
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] ConsultaModel consulta,
            [FromServices] AppDbContext context
        )
        {
            var consultaToUpdate = await context.Consultas.FindAsync(id);

            if (consultaToUpdate == null) return NotFound();

            consultaToUpdate.IdMedico = consulta.IdMedico;
            consultaToUpdate.IdPaciente = consulta.IdPaciente;
            consultaToUpdate.DataHoraConsulta = consulta.DataHoraConsulta;
            consultaToUpdate.TipoConsulta = consulta.TipoConsulta;
            consultaToUpdate.Observacoes = consulta.Observacoes;
            consultaToUpdate.IdRecepcionista = consulta.IdRecepcionista;

            context.Consultas.Update(consultaToUpdate);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]//Deleta a consulta
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var consultaToRemove = await context.Consultas.FindAsync(id);

            if (consultaToRemove == null) return NotFound();

            context.Consultas.Remove(consultaToRemove);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(result);
        }
    }
}
