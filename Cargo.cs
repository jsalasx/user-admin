﻿using System.ComponentModel.DataAnnotations.Schema;
using user_admin.Models;

namespace user_admin
{
    [Table("cargos")]
    public class Cargo
    {

        public int Id { get; set; }

        public string? Codigo { get; set; }

        public string? Nombre { get; set; }

        public bool Activo { get; set; }

        public int IdUsuarioCreacion { get; set; }

        public virtual ICollection<UsuarioModel>? Usuarios { get; set; } = new List<UsuarioModel>();
    }
}
