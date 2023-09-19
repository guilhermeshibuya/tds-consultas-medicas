using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ConsultasMedicas.API.Enums;

namespace ConsultasMedicas.API.Models
{
    public class ConsultaModel
    {
        [DisplayName("Id")]
        public int? IdConsulta{ get; set; }

        [DisplayName("Médico")]
        [Required(ErrorMessage = "O médico é obrigatório")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "O paciente é obrigatório")]
        public int? IdPaciente { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "A data e a hora são obrigatórias")]
        public DateTime DataHoraConsulta { get; set; }

        [DisplayName("Tipo da Consulta")]
        [Required(ErrorMessage = "O tipo da consulta é obrigatório")]
        public TipoConsulta TipoConsulta { get; set; }

        [DisplayName("Observações")]
        [Required(AllowEmptyStrings = false,
            ErrorMessage = "As observações são obrigatórias")]
        public string? Observacoes { get; set; }

        public int? IdRecepcionista { get; set; }
    }
}
