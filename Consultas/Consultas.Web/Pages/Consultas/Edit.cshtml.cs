using Consultas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Consultas.Web.Pages.Consultas
{
    public class EditModel : PageModel
    {
        public ConsultaModel Consulta { get; set; } = new();

        public List<MedicoModel> Medicos { get; set; } = new();
        public List<SelectListItem> MedicosList { get; set; } = new();

        public List<PacienteModel> Pacientes { get; set; } = new();
        public List<SelectListItem> PacientesList { get; set; } = new();

        public List<RecepcionistaModel> Recepcionistas { get; set; } = new();
        public List<SelectListItem> RecepcionistasList { get; set; } = new();

        public List<SelectListItem> TipoConsulta { get; set; } = new List<SelectListItem>
        {
           new SelectListItem
           {
               Text = "Presencial",
               Value = "0"
           },
           new SelectListItem
           {
               Text = "Online",
               Value = "1"
           }
        };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Uri baseUri = new Uri("https://localhost:7220/api/");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}Medico");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Medicos = JsonConvert.DeserializeObject<List<MedicoModel>>(responseContent);

                Medicos.ForEach(medico =>
                {
                    MedicosList.Add(new SelectListItem
                    {
                        Text = $"{medico.Nome} {medico.Sobrenome}",
                        Value = medico.Id.ToString(),
                    });
                });
            }

            response = await client.GetAsync($"{baseUri}Paciente");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Pacientes = JsonConvert.DeserializeObject<List<PacienteModel>>(responseContent);

                Pacientes.ForEach(paciente =>
                {
                    PacientesList.Add(new SelectListItem
                    {
                        Text = $"{paciente.PrimeiroNome} {paciente.Sobrenome}",
                        Value = paciente.Id.ToString(),
                    });
                });
            }

            response = await client.GetAsync($"{baseUri}Recepcionista");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Recepcionistas = JsonConvert.DeserializeObject<List<RecepcionistaModel>>(responseContent);

                Recepcionistas.ForEach(recepcionista =>
                {
                    RecepcionistasList.Add(new SelectListItem
                    {
                        Text = $"{recepcionista.PrimeiroNome} {recepcionista.Sobrenome}",
                        Value = recepcionista.Id.ToString(),
                    });
                });
            }

            response = await client.GetAsync($"{baseUri}Consulta/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                Consulta = JsonConvert.DeserializeObject<ConsultaModel>(responseContent);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, ConsultaModel consulta)
        {
            if (!ModelState.IsValid) return Page();

            Uri uri = new Uri($"https://localhost:7220/api/Consulta/{id}");
            HttpClient client = new();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(consulta),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                return RedirectToPage("/Consultas/Index");
            }

            return Page();
        }
    }
}
