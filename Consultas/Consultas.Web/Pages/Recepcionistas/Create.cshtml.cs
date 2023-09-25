using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Recepcionistas
{
    public class CreateModel : PageModel
    {
        public RecepcionistaModel Recepcionista { get; set; } = new();

        public async Task<IActionResult> OnPostAsync(RecepcionistaModel recepcionista)
        {
            if (!ModelState.IsValid) return Page();

            Uri uri = new Uri("https://localhost:7220/api/Recepcionista");
            HttpClient client = new();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(recepcionista),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                return RedirectToPage("/Recepcionistas/Index");
            }

            return Page();
        }
    }
}
