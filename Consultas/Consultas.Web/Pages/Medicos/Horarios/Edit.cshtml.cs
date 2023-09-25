using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Medicos.Horarios
{
    public class EditModel : PageModel
    {
        public DateTime DataHorario { get; set; }

        public async Task<IActionResult> OnPostAsync(int? idMedico, int? idHorario, DateTime? dataHorario)
        {
            if (idMedico == null || idHorario == null || dataHorario == null) return Page();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(dataHorario),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PutAsync($"{baseUri}Medico/{idMedico}/horarios/{idHorario}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Medicos/Index");
            }

            return Page();
        }
    }
}
