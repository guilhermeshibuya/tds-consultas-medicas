using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Especialidades
{
    public class DeleteModel : PageModel
    {
        public EspecialidadeModel Especialidade { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Especialidade/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Especialidade = JsonConvert.DeserializeObject<EspecialidadeModel>(responseContent);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"{baseUri}Especialidade/{id}");


            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Especialidades/Index");
            }

            return Page();
        }
    }
}
