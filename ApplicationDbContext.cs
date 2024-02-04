using Microsoft.EntityFrameworkCore;
using user_admin.Models;
namespace user_admin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasOne(u => u.Departamento)
                .WithMany()
                .HasForeignKey(u => u.IdDepartamento);




            modelBuilder.Entity<UsuarioModel>()
               .HasOne(c => c.Cargo)
               .WithMany()
               .HasForeignKey(u => u.IdCargo);



            // Configuraciones adicionales aquí

            modelBuilder.Entity<Cargo>().HasData(
           new Cargo { Id = 1, Nombre = "Desarrollador" },
           new Cargo { Id = 2, Nombre = "Analista" },
           new Cargo { Id = 3, Nombre = "Project Manager" },
           new Cargo { Id = 4, Nombre = "Product Owner" },
           new Cargo { Id = 5, Nombre = "QA" }
       );

            // Insertar datos de prueba para Departamento
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nombre = "TI" },
                new Departamento { Id = 2, Nombre = "Recursos Humanos" },
                new Departamento { Id = 3, Nombre = "Redes" },
                new Departamento { Id = 4, Nombre = "NOC" },
                new Departamento { Id = 5, Nombre = "Soporte" }
            );

            // Insertar datos de prueba para UsuarioModel
            //modelBuilder.Entity<UsuarioModel>().HasData(
            //    new UsuarioModel
            //    {
            //        Id = 1,
            //        Usuario = "juanperez1",
            //        PrimerNombre = "Juan",
            //        SegundoNombre = "Pedro",
            //        PrimerApellido = "Perez",
            //        SegundoApellido = "Salas",
            //        IdDepartamento = 1,
            //        IdCargo = 5
            //    },
            //     new UsuarioModel
            //     {
            //         Id = 2,
            //         Usuario = "alejosalas1",
            //         PrimerNombre = "Ale",
            //         SegundoNombre = "Pepe",
            //         PrimerApellido = "Salazar",
            //         SegundoApellido = "Gonzales",
            //         IdDepartamento = 2,
            //         IdCargo = 3
            //     }
            //);


            DataGenerator dataGenerator = new DataGenerator();
            var usuarios = dataGenerator.GenerateUsers(50); // Genera los datos de prueba
            modelBuilder.Entity<UsuarioModel>().HasData(usuarios);
        }
    }
}