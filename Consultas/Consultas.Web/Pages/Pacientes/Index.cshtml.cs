using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Pacientes
{
    public class IndexModel : PageModel
    {
        public List<PacienteModel> PacienteList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Uri uri = new Uri("https://localhost:7220/api/Paciente");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                PacienteList = JsonConvert.DeserializeObject<List<PacienteModel>>(responseContent);
            }

            return Page();
        }
    }
}
