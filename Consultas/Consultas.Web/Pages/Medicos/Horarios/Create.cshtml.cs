using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Medicos.Horarios
{
    public class CreateModel : PageModel
    {
        public HorarioModel DataHorario { get; set; } = new();

        public async Task<IActionResult> OnPostAsync(int? id, HorarioModel dataHorario)
        {
            Uri uri = new Uri($"https://localhost:7220/api/Medico/{id}/horarios");
            HttpClient client = new();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(dataHorario),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                return RedirectToPage("/Medicos/Index");
            }

            return Page();
        }
    }
}
