using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consultas.Web.Pages.Especialidades
{
    public class CreateModel : PageModel
    {
        public EspecialidadeModel Especialidade { get; set; } = new();
       

        public async Task<IActionResult> OnPostAsync(EspecialidadeModel especialidade)
        {
            if (!ModelState.IsValid)
                return Page();

            Uri uri = new Uri("https://localhost:7220/api/Especialidade");

            using (HttpClient client = new HttpClient())
            {
                string especialidadeJson = JsonConvert.SerializeObject(especialidade);
                HttpContent content = new StringContent(especialidadeJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    return RedirectToPage("/Especialidades/Index");
            }

            return Page();
        }
    }
}
