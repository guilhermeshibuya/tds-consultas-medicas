using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConsultasMedicas.API.Models
{
    public class PacienteModel
    {
        [DisplayName("Id")]
        public int? IdPaciente { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "O nome é obrigatório")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = "O nome deve ter no mínimo 2 letras")]
        public string? Nome { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "O sobrenome é obrigatório")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = "O sobrenome deve ter no mínimo 2 letras")]
        public string? Sobrenome { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessage = "O CPF obrigatório")]
        [RegularExpression(@"^\d{11}$",
            ErrorMessage = "O CPF deve ter 11 números")]
        public string? CPF { get; set; }

        [DisplayName("Histórico Médico")]
        [Required(ErrorMessage = "O histórico médico do paciente é obrigatório")]
        public string? HistoricoMedico { get; set; }

        [DisplayName("Consultas Agendadas")]
        public List<ConsultaModel>? Consultas { get; set; }
    }
}
