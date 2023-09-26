using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Pacientes
{
    public class DeleteModel : PageModel
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"{baseUri}Paciente/{id}");


            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Pacientes/Index");
            }

            return Page();
        }
    }
}
