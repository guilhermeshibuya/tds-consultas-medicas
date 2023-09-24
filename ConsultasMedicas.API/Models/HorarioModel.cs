using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultasMedicas.API.Models
{
    public class HorarioModel
    {
        [DisplayName("Id")]
        public int IdHorario { get; set; }

        [DisplayName("Horário Disponível")]
        public DateTime HorarioDisponivel { get; set; }
    }
}
