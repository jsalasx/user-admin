using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace user_admin.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    IdCargo = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "cargos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_users_cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_users_departamentos_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cargos",
                columns: new[] { "Id", "Activo", "Codigo", "IdUsuarioCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, false, null, 0, "Desarrollador" },
                    { 2, false, null, 0, "Analista" },
                    { 3, false, null, 0, "Project Manager" },
                    { 4, false, null, 0, "Product Owner" },
                    { 5, false, null, 0, "QA" }
                });

            migrationBuilder.InsertData(
                table: "departamentos",
                columns: new[] { "Id", "Activo", "Codigo", "IdUsuarioCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, false, null, 0, "TI" },
                    { 2, false, null, 0, "Recursos Humanos" },
                    { 3, false, null, 0, "Redes" },
                    { 4, false, null, 0, "NOC" },
                    { 5, false, null, 0, "Soporte" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CargoId", "DepartamentoId", "Email", "IdCargo", "IdDepartamento", "PrimerApellido", "PrimerNombre", "SegundoApellido", "SegundoNombre", "Usuario" },
                values: new object[,]
                {
                    { 100, null, null, "Savion_Johnson33@hotmail.com", 1, 5, "Turcotte", "Bernadette", "Christiansen", "Camila", "Hermann9" },
                    { 101, null, null, "Dariana.Windler@yahoo.com", 5, 2, "Moore", "Shanny", "Bechtelar", "Morton", "Francisco94" },
                    { 102, null, null, "Aryanna12@yahoo.com", 2, 1, "Boyer", "Clarabelle", "Dach", "Esteban", "Freida47" },
                    { 103, null, null, "Zetta.Brown@hotmail.com", 1, 1, "Okuneva", "Erling", "Runolfsson", "Nathanial", "Cooper51" },
                    { 104, null, null, "Mireille39@yahoo.com", 3, 1, "Kreiger", "Orin", "Hauck", "Cesar", "Catherine_Kling28" },
                    { 105, null, null, "Hubert27@yahoo.com", 4, 2, "Bogan", "Yolanda", "Bruen", "Felix", "Abe78" },
                    { 106, null, null, "Jordyn97@hotmail.com", 5, 2, "Bins", "Gregory", "Lesch", "Scot", "Gust.Mante31" },
                    { 107, null, null, "Ernie54@hotmail.com", 5, 3, "Ritchie", "Arvid", "Daniel", "Jerald", "Ilene.Olson" },
                    { 108, null, null, "Trey_Bode@hotmail.com", 2, 5, "Beatty", "Camren", "Auer", "Willis", "Tania.Batz9" },
                    { 109, null, null, "Kenya83@yahoo.com", 5, 4, "Strosin", "Roslyn", "Bergnaum", "Rhoda", "Marcellus.Murphy47" },
                    { 110, null, null, "Tyshawn.Braun33@gmail.com", 4, 1, "Gerhold", "Peter", "Walter", "Jayne", "Erik_Denesik87" },
                    { 111, null, null, "Brody.Olson0@yahoo.com", 1, 1, "Bergstrom", "Jennings", "Christiansen", "Nicolas", "Janis99" },
                    { 112, null, null, "Kailee.Homenick@gmail.com", 5, 1, "Nitzsche", "Coleman", "Stamm", "Alexandro", "Viva10" },
                    { 113, null, null, "Rosina36@yahoo.com", 1, 3, "Lang", "Sebastian", "Frami", "Gerard", "Percy93" },
                    { 114, null, null, "Orie_DuBuque@gmail.com", 5, 1, "Nicolas", "Cordelia", "Bayer", "Duane", "Kurtis.Emmerich" },
                    { 115, null, null, "Martina_Cronin@gmail.com", 1, 2, "Ebert", "Nathen", "Hudson", "Yolanda", "Jamison94" },
                    { 116, null, null, "Karen.Nienow@yahoo.com", 4, 4, "Wilderman", "Laurie", "Hintz", "Christ", "Isabell.Block56" },
                    { 117, null, null, "Eldred.Buckridge@yahoo.com", 1, 5, "Kerluke", "Tremaine", "Gleason", "Nico", "Jermain.Schowalter" },
                    { 118, null, null, "Mercedes.Brekke91@hotmail.com", 4, 2, "Torphy", "Bertram", "Gleichner", "Sylvan", "Derek_Yundt84" },
                    { 119, null, null, "Tiara0@hotmail.com", 1, 5, "Lockman", "Emily", "Wisozk", "Rebeca", "Burley27" },
                    { 120, null, null, "Reginald.Yost@gmail.com", 1, 1, "Morissette", "Harry", "Beahan", "Bailey", "Dorothy_Mayert" },
                    { 121, null, null, "Ivory_Gaylord16@gmail.com", 3, 3, "Bartoletti", "Emmalee", "Purdy", "Deanna", "Danielle.Satterfield2" },
                    { 122, null, null, "Reta.Kautzer76@gmail.com", 2, 5, "Cartwright", "Charlie", "Goyette", "Carolina", "Sadye_Luettgen" },
                    { 123, null, null, "Dereck6@yahoo.com", 2, 1, "Doyle", "Rupert", "Ryan", "Sallie", "Cicero47" },
                    { 124, null, null, "Hilma69@yahoo.com", 5, 2, "Jacobson", "Waylon", "Smith", "Terence", "Rose.Kuphal23" },
                    { 125, null, null, "Ophelia.Swaniawski66@hotmail.com", 1, 5, "Mertz", "Bobby", "Murazik", "Paolo", "Chelsea.DuBuque93" },
                    { 126, null, null, "Ruthie_Barton@yahoo.com", 3, 5, "Fisher", "Roderick", "Hagenes", "Ike", "Estelle46" },
                    { 127, null, null, "Anderson.Walker@hotmail.com", 4, 1, "Will", "Naomi", "Kuhic", "Gardner", "Leila31" },
                    { 128, null, null, "Walker.Farrell@yahoo.com", 2, 5, "Lakin", "Susana", "Mueller", "Angelina", "Jay.Gutmann87" },
                    { 129, null, null, "Precious.Dooley@yahoo.com", 5, 3, "Fay", "Monroe", "Ritchie", "Rahsaan", "Juwan46" },
                    { 130, null, null, "Emelie_Gorczany@yahoo.com", 1, 4, "Abbott", "Cole", "Dooley", "Carmela", "Marcos.Kuhic19" },
                    { 131, null, null, "Hellen_Prohaska@gmail.com", 4, 3, "Rolfson", "Berneice", "Rempel", "Adrianna", "Jacinto_Lowe" },
                    { 132, null, null, "Dejon_Huels@yahoo.com", 2, 5, "Zieme", "Wilson", "Homenick", "Heidi", "Aric57" },
                    { 133, null, null, "Imogene_Heathcote@yahoo.com", 4, 2, "Greenfelder", "Margaretta", "Bayer", "Citlalli", "Dandre_Marks28" },
                    { 134, null, null, "May60@yahoo.com", 5, 4, "Haley", "Lupe", "Ferry", "Marietta", "Violet.Hartmann" },
                    { 135, null, null, "Javonte.Farrell@hotmail.com", 5, 4, "Olson", "Greg", "O'Keefe", "Clotilde", "Abdiel_Orn" },
                    { 136, null, null, "Coleman.Emmerich5@hotmail.com", 3, 1, "Rutherford", "Maeve", "Kihn", "Mckayla", "Allen8" },
                    { 137, null, null, "Lavern.Quigley98@hotmail.com", 5, 5, "Oberbrunner", "Sylvester", "Bernier", "Chandler", "Lesly.Barton" },
                    { 138, null, null, "Summer99@hotmail.com", 2, 1, "Towne", "Dylan", "Emmerich", "Quentin", "Antonio68" },
                    { 139, null, null, "Nigel_McGlynn@gmail.com", 3, 2, "Hintz", "Kamren", "Mohr", "Dena", "Darren24" },
                    { 140, null, null, "Lonie.OConner34@yahoo.com", 1, 5, "Lowe", "Genoveva", "Lueilwitz", "Aurelie", "Curt37" },
                    { 141, null, null, "Nash_Welch@hotmail.com", 3, 4, "Pfeffer", "Polly", "Stracke", "Elena", "Lucius.Quitzon84" },
                    { 142, null, null, "Hosea.Batz@hotmail.com", 2, 5, "Wiegand", "Cornell", "Watsica", "Rafael", "Tressie30" },
                    { 143, null, null, "Harrison64@gmail.com", 2, 4, "Kuvalis", "Raleigh", "Feest", "Beau", "Patrick54" },
                    { 144, null, null, "Damaris98@gmail.com", 2, 3, "Rodriguez", "Milo", "Ratke", "Vince", "Amalia.Emmerich77" },
                    { 145, null, null, "Martin.Kuhlman78@gmail.com", 5, 2, "Ebert", "Lily", "Schneider", "Skylar", "Armand52" },
                    { 146, null, null, "Heath.Nienow99@hotmail.com", 4, 4, "Lakin", "Torey", "Ziemann", "Deshawn", "Kasey74" },
                    { 147, null, null, "Tyson12@gmail.com", 1, 3, "Dickinson", "Bridie", "Schultz", "Myrna", "Jonathan6" },
                    { 148, null, null, "Jana90@gmail.com", 4, 5, "Nienow", "Drew", "Stamm", "Ward", "Timmy_Green" },
                    { 149, null, null, "Clement_Stiedemann28@hotmail.com", 5, 2, "Heller", "Adam", "Mann", "Sigmund", "Consuelo_Hegmann6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_CargoId",
                table: "users",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_users_DepartamentoId",
                table: "users",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_users_IdCargo",
                table: "users",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_users_IdDepartamento",
                table: "users",
                column: "IdDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "departamentos");
        }
    }
}
