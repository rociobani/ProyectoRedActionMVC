using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_MVC_12G.Models
{
    public enum EstadoArticulo
    {
        BORRADOR,
        ESPERANDO_APROBACION,
        DESCARTADO,
        EN_REVISION,
        APROBADO,
        PROGRAMADO,
        PUBLICADO
    }
}
