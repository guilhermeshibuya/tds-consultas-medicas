using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Consultas.API.Models
{
    public class EspecialidadeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int? Id { get; set; }

        [DisplayName("Especialidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome informado e muito grande")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        public virtual ICollection<MedicoModel>? Medicos { get; set; }

        public EspecialidadeModel()
        {
            Medicos = new List<MedicoModel>();
        }
    }
}
