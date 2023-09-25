using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Consultas.API.Models
{
    public class HorarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int? Id { get; set; }

        [JsonIgnore]
        public int? IdMedico { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Data e horário")]
        public DateTime? DataHorario { get; set; }

        [JsonIgnore]
        public MedicoModel? Medico { get; set; }
    }
}
