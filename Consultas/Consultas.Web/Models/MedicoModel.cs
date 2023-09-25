using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consultas.API.Models
{
    public class MedicoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome invalido")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sobrenome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome invalido")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CRM")]
        [RegularExpression(@"^[A-Z]{2}\d{5}$")]
        public string? CRM { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Especialidade")]
        public int? IdEspecialidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [Display(Name = "Horários Disponíveis")]
        [JsonIgnore]
        public ICollection<HorarioModel>? HorariosDisponiveis { get; set; }

        [JsonIgnore]
        public virtual ICollection<ConsultaModel>? Consultas { get; set; }

        [JsonIgnore]
        public EspecialidadeModel? Especialidade { get; set; }

        public MedicoModel()
        {
            Consultas = new List<ConsultaModel>();
            HorariosDisponiveis = new List<HorarioModel>();
        }

    }
}
