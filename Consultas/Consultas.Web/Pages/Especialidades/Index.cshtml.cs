using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Especialidades
{
    public class IndexModel : PageModel
    {
        public List<EspecialidadeModel> EspecialidadeList { get; set; } = new();
        
        public async Task<IActionResult> OnGetAsync()
        {
            Uri uri = new Uri("https://localhost:7220/api/Especialidade");

            HttpClient client= new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                EspecialidadeList = JsonConvert.DeserializeObject<List<EspecialidadeModel>>(responseContent);
            }

            return Page();
        }
    }
}
