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
    public class EditModel : PageModel
    {
        public EspecialidadeModel Especialidade { get; set; } = new();
        public List<EspecialidadeModel> Especialidades { get; set; } = new();
        public List<SelectListItem> EspecialidadesList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{baseUri}Especialidade/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Especialidade = JsonConvert.DeserializeObject<EspecialidadeModel>(responseContent);
                }

                response = await client.GetAsync($"{baseUri}Especialidade");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Especialidades = JsonConvert.DeserializeObject<List<EspecialidadeModel>>(responseContent);

                    Especialidades.ForEach(especialidade =>
                    {
                        EspecialidadesList.Add(new SelectListItem
                        {
                            Text = especialidade.Nome,
                            Value = especialidade.Id.ToString(),
                        });
                    });
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, EspecialidadeModel especialidade )
        {
            if (id == null || especialidade == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            using (HttpClient client = new HttpClient())
            {
                string especialidadeJson = JsonConvert.SerializeObject(especialidade);
                HttpContent content = new StringContent(especialidadeJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"{baseUri}Especialidade/{id}", content);

                if (response.IsSuccessStatusCode)
                    return RedirectToPage("/Especialidades/Index");
            }

            return Page();
        }
    }
}
