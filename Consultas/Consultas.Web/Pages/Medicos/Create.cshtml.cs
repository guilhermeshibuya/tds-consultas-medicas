using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Medicos
{
    public class CreateModel : PageModel
    {
        public MedicoModel Medico { get; set; } = new();
        public List<EspecialidadeModel> Especialidades { get; set; } = new();
        
        public List<SelectListItem> EspecialidadesList { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Uri uri = new Uri("https://localhost:7220/api/Especialidade");
        
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(uri);
       
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

        public async Task<IActionResult> OnPostAsync(MedicoModel medico)
        {
            if (!ModelState.IsValid) return Page();

            Uri uri = new Uri("https://localhost:7220/api/Medico");
            HttpClient client = new();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(medico),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                return RedirectToPage("/Medicos/Index");
            }

            return Page();
        }
    }
}
