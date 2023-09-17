using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConsultasMedicas.API.Models
{
    public class RecepcionistaModel
    {
        [DisplayName("Id")]
        public int? IdRecepcionista { get; set; }

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

        [DisplayName("Telefone")]
        [Required(AllowEmptyStrings = false,
           ErrorMessage = "O telefone obrigatório")]
        [RegularExpression(@"^(\d{2}9\d{8}|\d{10})$",
           ErrorMessage = "Número inválido")]
        public string? NumeroTelefone { get; set; }

        [DisplayName("Consultas Agendadas")]
        public List<ConsultaModel>? ConsultasAgendadas { get; set; }
    }
}
