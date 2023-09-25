using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Recepcionistas
{
    public class EditModel : PageModel
    {
        public RecepcionistaModel Recepcionista { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Recepcionista/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Recepcionista = JsonConvert.DeserializeObject<RecepcionistaModel>(responseContent);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, RecepcionistaModel recepcionista)
        {
            if (id == null || recepcionista == null) return NotFound();

            if (!ModelState.IsValid) return Page();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(recepcionista),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PutAsync($"{baseUri}Recepcionista/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Recepcionistas/Index");
            }

            return Page();
        }
    }
}
