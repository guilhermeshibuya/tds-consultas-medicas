using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Healthy.Domain.Entities;

public class PacienteModel 
{
    [Required(ErrorMessage = "CPF é obrigatório")]
    [Display(Name = "CPF")]
    public string CPF { get; set; }
    
    public virtual ICollection<ConsultaModel> Appointments { get; set; }
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
    [Display(Name = "Data de nascimento")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date, ErrorMessage = "Data inválida")]
    public DateTime Aniversario { get; set; }

    [NotMapped][Display(Name = "Idade")] public int Age => (int)((DateTime.Now - Aniversario).TotalDays / 365.25);

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Telefone")]
    [Phone(ErrorMessage = "Telefone inválido")]
    public string Telefone { get; set; }

    public PacienteModel()
    {
        ConsultaModel = new HashSet<ConsultaModel>();
    }
}