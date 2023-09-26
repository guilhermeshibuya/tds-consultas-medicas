using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Consultas
{
    public class DetailsModel : PageModel
    {
        public ConsultaModel Consulta { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Consulta/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Consulta = JsonConvert.DeserializeObject<ConsultaModel>(responseContent);
            }

            return Page();
        }

    }
}
