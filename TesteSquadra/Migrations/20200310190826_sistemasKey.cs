using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSquadra.Migrations
{
    public partial class sistemasKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sistemas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    URL = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 9, nullable: false),
                    UsuarioResponsavel = table.Column<string>(maxLength: 100, nullable: true),
                    DataEdicao = table.Column<DateTime>(nullable: false),
                    Justificativa = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistemas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sistemas");
        }
    }
}
