using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ConsultasMedicas.API.Attributes;

namespace ConsultasMedicas.API.Models
{
    public class MedicoModel
    {
        [DisplayName("Id")]
        public int? IdMedico { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "O nome é obrigatório")]
        [StringLength(80, MinimumLength = 2,
            ErrorMessage = "O nome deve ter no mínimo 2 letras")]
        public string? Nome { get; set; }

        //[Required(ErrorMessage = "A especialidade é obrigatória")]
        public int? IdEspecialidade { get; set; }
        
        //public EspecialidadeModel? Especialidade { get; set; }

        [Required(ErrorMessage = "O CRM é obrigatório")]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        public string? CRM { get; set; }

        [DisplayName("Horários Disponíveis")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}")]
        //[DateTimeValidator(ErrorMessage = "A data não pode ser no passado")]
        public List<HorarioModel> HorariosDisponiveis { get; set; } = new();

        [DisplayName("Consultas Agendadas")]
        public List<ConsultaModel> Consultas { get; set; } = new();
    }
}
