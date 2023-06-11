using System;
using System.Collections.Generic;

namespace ProyectoLavadero.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string? Telefono { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
