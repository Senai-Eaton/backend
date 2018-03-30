using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eaton.agir.repository.Migrations
{
    public partial class Atualizacao_Tabela_Endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Voluntarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Voluntarios_EnderecoId",
                table: "Voluntarios",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntarios_Enderecos_EnderecoId",
                table: "Voluntarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_Enderecos_EnderecoId",
                table: "Voluntarios");

            migrationBuilder.DropIndex(
                name: "IX_Voluntarios_EnderecoId",
                table: "Voluntarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Voluntarios");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
