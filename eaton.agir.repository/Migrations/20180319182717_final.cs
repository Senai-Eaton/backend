using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eaton.agir.repository.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoiId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_enderecos_EnderecoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_enderecos_EnderecoId",
                table: "Voluntarios");

            migrationBuilder.DropIndex(
                name: "IX_Voluntarios_EnderecoId",
                table: "Voluntarios");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_AreaAtuacaoiId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_EnderecoId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Voluntarios");

            migrationBuilder.DropColumn(
                name: "AreaAtuacaoiId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Empresas");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_AreaAtuacaoId",
                table: "Empresas",
                column: "AreaAtuacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                table: "Empresas",
                column: "AreaAtuacaoId",
                principalTable: "AreaAtuacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_AreaAtuacaoId",
                table: "Empresas");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Voluntarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AreaAtuacaoiId",
                table: "Empresas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Voluntarios_EnderecoId",
                table: "Voluntarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_AreaAtuacaoiId",
                table: "Empresas",
                column: "AreaAtuacaoiId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_EnderecoId",
                table: "Empresas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoiId",
                table: "Empresas",
                column: "AreaAtuacaoiId",
                principalTable: "AreaAtuacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_enderecos_EnderecoId",
                table: "Empresas",
                column: "EnderecoId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntarios_enderecos_EnderecoId",
                table: "Voluntarios",
                column: "EnderecoId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
