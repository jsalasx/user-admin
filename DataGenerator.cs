using Bogus;
using user_admin.Models;

namespace user_admin
{
    public class DataGenerator
    {
        public List<UsuarioModel> GenerateUsers(int numberOfUsers)
        {
            var id = 100;
            var departamentosIds = new List<int> { 1, 2, 3, 4, 5 };
            var cargosIds = new List<int> { 1, 2, 3, 4, 5 };
            var userFaker = new Faker<UsuarioModel>()
                .RuleFor(u => u.Id, f =>id++)
                .RuleFor(u => u.Usuario, (f, u) => f.Internet.UserName(u.PrimerNombre, u.PrimerApellido))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
                .RuleFor(u => u.PrimerNombre, f => f.Name.FirstName())
                .RuleFor(u => u.SegundoNombre, f => f.Name.FirstName())
                .RuleFor(u => u.PrimerApellido, f => f.Name.LastName())
                .RuleFor(u => u.SegundoApellido, f => f.Name.LastName())
                .RuleFor(u => u.IdDepartamento, f => f.PickRandom(departamentosIds))
                .RuleFor(u => u.IdCargo, f => f.PickRandom(cargosIds));

            return userFaker.Generate(numberOfUsers);
        }
    }
}
