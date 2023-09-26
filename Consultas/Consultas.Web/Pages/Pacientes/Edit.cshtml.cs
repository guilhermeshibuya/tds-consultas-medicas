using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Pacientes
{
    public class EditModel : PageModel
    {
        public PacienteModel Paciente { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Paciente/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Paciente = JsonConvert.DeserializeObject<PacienteModel>(responseContent);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, PacienteModel paciente)
        {
            if (id == null || paciente == null) return NotFound();

            if (!ModelState.IsValid) return Page();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(paciente),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PutAsync($"{baseUri}Paciente/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Pacientes/Index");
            }

            return Page();
        }
    }
}
