using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSquadra.Models
{
    public class Sistemas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(10)]
        public string Sigla { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string URL { get; set; }
        [Required]
        [StringLength(9)]
        public string Status { get; set; }
        [StringLength(100)]
        public string UsuarioResponsavel { get; set; }
        [Required]
        public DateTime DataEdicao { get; set; }

        [Required]
        [StringLength(500)]
        public String Justificativa { get; set; }
    }
}
