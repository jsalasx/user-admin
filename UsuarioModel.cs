using System.ComponentModel.DataAnnotations.Schema;
namespace user_admin.Models
{
    

    [Table("users")]
    public class UsuarioModel
	{
        
        public int? Id { get; set; }

        
        public string? Usuario { get; set; }

        public string? Email { get; set; }


        public string? PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; }

        public int IdDepartamento { get; set; }

        public int IdCargo { get; set; }

        public Cargo? Cargo { get; set; }
        public Departamento? Departamento { get; set; }

    }
}