using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_MVC_12G.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        [Display(Name = "Nombre y Apellido")]
        public string nombreCompleto { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string mail { get; set; }
        [Display(Name = "Tipo De Usuario")]
        [EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario tipo { get; set; }
        [Display(Name = "Nombre De Usuario")]
        public string nomUsuario { get; set; }
        public string pass { get; set; }

    }
}
