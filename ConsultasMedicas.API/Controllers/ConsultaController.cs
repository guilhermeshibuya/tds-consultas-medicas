using ConsultasMedicas.API.Data;
using ConsultasMedicas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultasMedicas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context
        )
        {
            var especialidades = await context.Especialidades.ToListAsync();

            if (especialidades == null) return NotFound();
            
            return Ok(especialidades);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var especialidade = await context.Especialidades.FindAsync(id);

            if (especialidade == null) return NotFound();

            return Ok(especialidade);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] EspecialidadeModel especialidade,
            [FromServices] AppDbContext context
        )
        {
            context.Especialidades.Add(especialidade);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Created($"/{especialidade.IdEspecialidade}", especialidade);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EspecialidadeModel especialidade,
            [FromServices] AppDbContext context
        )
        {
            var especialidadeToUpdate = await context.Especialidades.FindAsync(id);

            if (especialidadeToUpdate == null) return NotFound();

            especialidadeToUpdate.NomeEspecialidade = especialidade.NomeEspecialidade;
            especialidadeToUpdate.Descricao = especialidade.Descricao;

            context.Especialidades.Update(especialidadeToUpdate);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            var especialidadeToRemove = await context.Especialidades.FindAsync(id);

            if (especialidadeToRemove == null) return NotFound();

            context.Especialidades.Remove(especialidadeToRemove);

            var result = await context.SaveChangesAsync();

            if (result == 0) return BadRequest();

            return Ok(result);
        }
    }
}
