using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Pacientes
{
    public class CreateModel : PageModel
    {
        public PacienteModel Paciente { get; set; } = new();

        public async Task<IActionResult> OnPostAsync(PacienteModel paciente)
        {
            if (!ModelState.IsValid) return Page();

            Uri uri = new Uri("https://localhost:7220/api/Paciente");
            HttpClient client = new();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(paciente),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                return RedirectToPage("/Pacientes/Index");
            }

            return Page();
        }
    }
}
