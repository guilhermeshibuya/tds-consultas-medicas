using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ConsultasMedicas.API.Models
{
    public class EspecialidadeModel
    {
        [DisplayName("Id")]
        public int? IdEspecialidade { get; set; }

        [DisplayName("Especialidade")]
        [Required(AllowEmptyStrings = false,
            ErrorMessage = "O nome é obrigatório")]
        [StringLength(40, MinimumLength = 2,
            ErrorMessage = "O nome deve ter no mínimo 2 letras e no máximo 40")]
        public string? NomeEspecialidade { get; set; }

        [DisplayName("Descrição")]
        [Required(AllowEmptyStrings = false,
            ErrorMessage = "A descrição é obrigatória")]
        public string? Descricao { get; set; }
    }
}
