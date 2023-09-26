using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Recepcionistas
{
    public class IndexModel : PageModel
    {
        public List<RecepcionistaModel> RecepcionistaList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Uri uri = new Uri("https://localhost:7220/api/Recepcionista");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                RecepcionistaList = JsonConvert.DeserializeObject<List<RecepcionistaModel>>(responseContent);
            }

            return Page();
        }
    }
}
