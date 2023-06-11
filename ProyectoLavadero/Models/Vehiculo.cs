using System;
using System.Collections.Generic;

namespace ProyectoLavadero.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            HistorialLavados = new HashSet<HistorialLavado>();
        }

        public string Matricula { get; set; } = null!;
        public int? IdUsuario { get; set; }
        public string? Marca { get; set; }
        public string? Color { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<HistorialLavado> HistorialLavados { get; set; }
    }
}
