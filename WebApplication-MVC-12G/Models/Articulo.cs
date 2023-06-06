using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_MVC_12G.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Usuario autor { get; set; }
        public string contenido { get; set; }
        [Display(Name = "Fecha Publicacion")]
        public DateTime FechaPublicacion { get; set; }
        [EnumDataType(typeof(Seccion))]
        public Seccion seccion { get; set; }
        [EnumDataType(typeof(EstadoArticulo))]
        public EstadoArticulo estado { get; set; }
        public string observaciones { get; set; }
    }
}
