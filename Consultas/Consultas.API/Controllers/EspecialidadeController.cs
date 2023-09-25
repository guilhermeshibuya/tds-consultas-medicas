using Consultas.API.Data;
using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] AppDbContext context
        )
        {
            var especialidades = await context.Especialidades
                .Include(e => e.Medicos)
                .ToListAsync();

            if (especialidades == null) return NotFound();

            return Ok(especialidades);
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

            return Created($"/{especialidade.Id}", especialidade);
        }

        [HttpGet("{id:int}/")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidade = await context.Especialidades.Include(e => e.Medicos)
                .FirstOrDefaultAsync(e => e.Id == id);
            
            return Ok(especialidade);
        }

        [HttpDelete("{id:int}/")]
        public async Task<IActionResult> DeleteByIdAsync(
            [FromRoute] int id,
            [FromServices] AppDbContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidade = await context.Especialidades.FindAsync(id);

            if (especialidade == null)
            {
                return NotFound();
            }

            context.Especialidades.Remove(especialidade);
            await context.SaveChangesAsync();

            return NoContent(); // Indica que a deleção foi bem-sucedida e não há conteúdo para retornar
        }

        [HttpPut("{id:int}/")]
        public async Task<IActionResult> UpdateByIdAsync(
            [FromRoute] int id,
            [FromBody] EspecialidadeModel updatedEspecialidade,
            [FromServices] AppDbContext context
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especialidade = await context.Especialidades.FindAsync(id);

            if (especialidade == null)
            {
                return NotFound();
            }

            // Atualizar os dados da especialidade com base nos dados fornecidos
            especialidade.Nome = updatedEspecialidade.Nome;  // Substitua com os campos apropriados

            // Marcar a entidade como modificada e salvar as alterações
            context.Entry(especialidade).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!context.Especialidades.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Indica que a atualização foi bem-sucedida e não há conteúdo para retornar
        }
    }
}
