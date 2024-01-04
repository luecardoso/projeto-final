using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendamentoConsultaVeterinaria.Migrations
{
    public partial class versao002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioFuncionamento",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "DataConsulta",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "HoraConsulta",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "UnidadeModelId",
                table: "Unidade",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "HoraId",
                table: "Unidade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorarioFuncionamentoId",
                table: "Unidade",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StatusConsulta",
                table: "Consulta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DataConsultaId",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TipoAnimal",
                table: "Animal",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Peso",
                table: "Animal",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "DataHoraModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataHoraModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoraAtivaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraAtivaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoraAtivaModel_DataHoraModel_DataHoraId",
                        column: x => x.DataHoraId,
                        principalTable: "DataHoraModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_HorarioFuncionamentoId",
                table: "Unidade",
                column: "HorarioFuncionamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_DataConsultaId",
                table: "Consulta",
                column: "DataConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraAtivaModel_DataHoraId",
                table: "HoraAtivaModel",
                column: "DataHoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_DataHoraModel_DataConsultaId",
                table: "Consulta",
                column: "DataConsultaId",
                principalTable: "DataHoraModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_HoraAtivaModel_HorarioFuncionamentoId",
                table: "Unidade",
                column: "HorarioFuncionamentoId",
                principalTable: "HoraAtivaModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_DataHoraModel_DataConsultaId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_HoraAtivaModel_HorarioFuncionamentoId",
                table: "Unidade");

            migrationBuilder.DropTable(
                name: "HoraAtivaModel");

            migrationBuilder.DropTable(
                name: "DataHoraModel");

            migrationBuilder.DropIndex(
                name: "IX_Unidade_HorarioFuncionamentoId",
                table: "Unidade");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_DataConsultaId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "HoraId",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "HorarioFuncionamentoId",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "DataConsultaId",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Unidade",
                newName: "UnidadeModelId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HorarioFuncionamento",
                table: "Unidade",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusConsulta",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConsulta",
                table: "Consulta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraConsulta",
                table: "Consulta",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "TipoAnimal",
                table: "Animal",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Peso",
                table: "Animal",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
