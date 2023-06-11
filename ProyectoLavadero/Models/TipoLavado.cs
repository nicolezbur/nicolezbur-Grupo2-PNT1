using System;
using System.Collections.Generic;

namespace ProyectoLavadero.Models
{
    public partial class TipoLavado
    {
        public TipoLavado()
        {
            HistorialLavados = new HashSet<HistorialLavado>();
        }

        public int IdTipoLavado { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<HistorialLavado> HistorialLavados { get; set; }
    }
}
