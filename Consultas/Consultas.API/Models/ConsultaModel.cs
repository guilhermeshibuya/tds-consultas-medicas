using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Consultas.API.Enums;

namespace Consultas.API.Models
{
    public class ConsultaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data e hora da consulta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Médico")]
        public int? IdMedico{ get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Paciente")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Recepcionista")]
        public int? IdRecepcionista { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Descriçao muito longa")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Tipo da Consulta")]
        public TipoConsultaEnum? TipoConsulta { get; set; }

        [Display(Name = "Médico")] 
        public MedicoModel? Medico { get; set; }

        [Display(Name = "Paciente")] 
        public PacienteModel? Paciente { get; set; }

        [Display(Name = "Recepcionista")] 
        public RecepcionistaModel? Recepcionista { get; set; }
    }
}
