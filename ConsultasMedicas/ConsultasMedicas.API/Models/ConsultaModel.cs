using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultasMedicas.API.Models;

public class ConsultaModel
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Código")] 
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Data e hora da consulta")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
    
    public DateTime Data { get; set; }

    [Display(Name = "Criado em")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
    public DateTime Criacao { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Médico")]
    public int MedicoId { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Paciente")]
    public int PacienteId { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Descrição")]
    [StringLength(500, MinimumLength = 0, ErrorMessage = "Descriçao muito longa")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Recepcionista")]
    public int RecepcionistaId { get; set; }

    [Display(Name = "Médico")] public MedicoModel Medico { get; set; }

    [Display(Name = "Paciente")] public PacienteModel Paciente { get; set; }

    [Display(Name = "Recepcionista")] public RecepcionistaModel Recepcionista { get; set; }

}