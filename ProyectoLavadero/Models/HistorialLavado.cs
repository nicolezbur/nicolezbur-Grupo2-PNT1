using System;
using System.Collections.Generic;

namespace ProyectoLavadero.Models
{
    public partial class HistorialLavado
    {
        public int IdLavado { get; set; }
        public string Matricula { get; set; } = null!;
        public int? IdTipoLavado { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaLavado { get; set; }

        public virtual TipoLavado? IdTipoLavadoNavigation { get; set; }
        public virtual Vehiculo MatriculaNavigation { get; set; } = null!;
    }
}
