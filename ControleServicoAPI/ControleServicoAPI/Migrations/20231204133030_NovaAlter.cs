using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleServicoAPI.Migrations
{
    /// <inheritdoc />
    public partial class NovaAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valor",
                table: "CadServicos",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "CadServicos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "CadServicos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "CadServicos",
                newName: "Descricao");

            migrationBuilder.AddColumn<bool>(
                name: "Concluido",
                table: "CadServicos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluido",
                table: "CadServicos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "CadServicos",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "CadServicos",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CadServicos",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "CadServicos",
                newName: "descricao");
        }
    }
}
