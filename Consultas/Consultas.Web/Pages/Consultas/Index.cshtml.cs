using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Consultas
{
    public class IndexModel : PageModel
    {
        public List<ConsultaModel> ConsultaList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Uri uri = new Uri("https://localhost:7220/api/Consulta");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                ConsultaList = JsonConvert.DeserializeObject<List<ConsultaModel>>(responseContent);
            }

            return Page();
        }
    }
}
