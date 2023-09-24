using System.ComponentModel.DataAnnotations;

namespace ConsultasMedicas.API.Models
{
    public class MedicoModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Primeiro nome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sobrenome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CRM")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Especialidades")]
        public virtual ICollection<EspecialidadeModel> Especialidades { get; set; }

        public virtual ICollection<ConsultaModel> Consultas { get; set; }

        public DateTime Aniversario { get; set; }


        public MedicoModel() 
        {
            Consultas = new HashSet<ConsultaModel>();
            Especialidades = new HashSet<EspecialidadeModel>();
        }


    }
}
