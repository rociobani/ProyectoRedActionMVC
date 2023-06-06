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
        public int dni { get; set; }
        public string nombreCompleto { get; set; }
        public string mail { get; set; }
        [EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario tipo { get; set; }
        public string nomUsuario { get; set; }
        public string pass { get; set; }
        [EnumDataType(typeof(Seccion))]
        public Seccion Seccion { get; set; }

    }
}
