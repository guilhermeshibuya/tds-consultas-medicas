using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Consultas.API.Models
{
    public class RecepcionistaModel
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

        
        [RegularExpression(@"^(\d{2}9\d{8}|\d{10})$")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        public virtual ICollection<ConsultaModel>? Consultas { get; set; }

        public RecepcionistaModel()
        {
            Consultas = new List<ConsultaModel>();
        }
    }
}
