using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Medicos
{
    public class EditModel : PageModel
    {
        public MedicoModel Medico { get; set; } = new();

        public List<EspecialidadeModel> Especialidades { get; set; } = new();

        public List<SelectListItem> EspecialidadesList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id, MedicoModel medico)
        {
            if (id == null) return NotFound();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Medico/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Medico = JsonConvert.DeserializeObject<MedicoModel>(responseContent);
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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, MedicoModel medico)
        {
            if (id == null || medico == null) return NotFound();

            if (!ModelState.IsValid) return Page();

            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(medico),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PutAsync($"{baseUri}Medico/{id}", content);

            if (response.IsSuccessStatusCode) 
            {
                return RedirectToPage("/Medicos/Index");
            }

            return Page();
        }
    }
}
