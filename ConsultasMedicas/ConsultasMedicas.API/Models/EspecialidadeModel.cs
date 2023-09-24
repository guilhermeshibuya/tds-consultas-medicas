﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ConsultasMedicas.API.Models
{
    public class EspecialidadeModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public virtual ICollection<MedicoModel> Medicos { get; set; }

        public EspecialidadeModel()
        {
            Medicos = new HashSet<MedicoModel>();
        }
    }
}