using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Consultas.API.Models
{
    public class PacienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nome informado e invalido")]
        public string? PrimeiroNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sobrenome")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome informado e invalido")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CPF")]
        public string? CPF { get; set; }

        public virtual ICollection<ConsultaModel>? Consultas { get; set; }

        public PacienteModel()
        {
            Consultas = new List<ConsultaModel>();
        }
    }
}
