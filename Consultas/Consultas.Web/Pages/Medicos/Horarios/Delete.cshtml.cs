using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Medicos.Horarios
{
    public class DeleteModel : PageModel
    {
        public HorarioModel DataHorario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? idHorario)
        {
            if (idHorario == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Medico/horarios/{idHorario}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                DataHorario = JsonConvert.DeserializeObject<HorarioModel>(responseContent);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? idHorario, int? idMedico)
        {
            if(idHorario == null || idMedico == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"{baseUri}Medico/{idMedico}/horarios/{idHorario}");


            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Medicos/Index");
            }

            return Page();
        }
    }
}
