using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultasMedicas.API.Models
{
    public class MedicoModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Primeiro nome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome invalido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sobrenome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome invalido")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CRM")]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Especialidades")]
        public virtual EspecialidadeModel Especialidade { get; set; }

        public virtual ICollection<ConsultaModel> Consultas { get; set; }

        public DateTime Aniversario { get; set; }


        public MedicoModel() 
        {
            Consultas = new HashSet<ConsultaModel>();
        }


    }
}
