using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Medicos.Horarios
{
    public class HorariosContainer
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public List<HorarioModel> HorariosDisponiveis { get; set; } = new();
    }

    public class IndexModel : PageModel
    {
        public HorariosContainer Horarios { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Medico/{id}/horarios");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Horarios = JsonConvert.DeserializeObject<HorariosContainer>(responseContent);
            }

            return Page();
        }
    }
}
