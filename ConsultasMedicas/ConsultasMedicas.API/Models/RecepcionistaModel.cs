using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsultasMedicas.API.Models;

public class RecepcionistaModel
{
    [Required(ErrorMessage = "CPF é obrigatório")]
    [Display(Name = "CPF")]
    public string CPF { get; set; }

    public virtual ICollection<ConsultaModel> Consultas { get; set; }

    [Required(ErrorMessage = "Informe o nome")]
    [Display(Name = "Nome")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Nome informado e invalido")]
    public string PrimeiroNome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Sobrenome")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome informado e invalido")]
    public string Sobrenome { get; set; }

    [NotMapped]
    [Display(Name = "Nome completo")]
    public string FullName => PrimeiroNome + " " + Sobrenome;



    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Telefone")]
    [Phone(ErrorMessage = "Telefone inválido")]
    public string Telefone { get; set; }

    public RecepcionistaModel()
    {
        Consultas = new HashSet<ConsultaModel>();
    }
}