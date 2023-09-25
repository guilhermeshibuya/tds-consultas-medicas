using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Consultas.Web.Pages.Medicos
{
    public class IndexModel : PageModel
    {
        public List<MedicoModel> MedicoList { get; set; } = new();
        
        public async Task<IActionResult> OnGetAsync()
        {
            Uri uri = new Uri("https://localhost:7220/api/Medico");

            HttpClient client= new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                MedicoList = JsonConvert.DeserializeObject<List<MedicoModel>>(responseContent);
            }

            return Page();
        }
    }
}
