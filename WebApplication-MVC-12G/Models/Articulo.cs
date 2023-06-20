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
        [Display(Name = "Escribí tu artículo")]
        public string contenido { get; set; }
        [Display(Name = "¿Sobre qué tema vas a hablar?")]
        [EnumDataType(typeof(Seccion))]
        public Seccion seccion { get; set; }
        [Display(Name = "Estado del Artículo")]
        [EnumDataType(typeof(EstadoArticulo))]
        public EstadoArticulo estado { get; set; }
        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
    }
}
