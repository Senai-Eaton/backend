using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eaton.agir.repository.Migrations
{
    public partial class semifinal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_enderecos_endeId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_endeId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "endeId",
                table: "Empresas");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_enderecoId",
                table: "Empresas",
                column: "enderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_enderecos_enderecoId",
                table: "Empresas",
                column: "enderecoId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_enderecos_enderecoId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_enderecoId",
                table: "Empresas");

            migrationBuilder.AddColumn<int>(
                name: "endeId",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_endeId",
                table: "Empresas",
                column: "endeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_enderecos_endeId",
                table: "Empresas",
                column: "endeId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
