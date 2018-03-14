using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eaton.agir.repository.Migrations
{
    public partial class Terceiraversao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_enderecos_LocalId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_AreaInteresses_AreaId",
                table: "Voluntarios");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_AreaAtuacaoId",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Voluntarios",
                newName: "areaId");

            migrationBuilder.RenameIndex(
                name: "IX_Voluntarios_AreaId",
                table: "Voluntarios",
                newName: "IX_Voluntarios_areaId");

            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "Eventos",
                newName: "localId");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos",
                newName: "IX_Eventos_localId");

            migrationBuilder.AddColumn<int>(
                name: "AreaAtuacaoiId",
                table: "Empresas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_AreaAtuacaoiId",
                table: "Empresas",
                column: "AreaAtuacaoiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoiId",
                table: "Empresas",
                column: "AreaAtuacaoiId",
                principalTable: "AreaAtuacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_enderecos_localId",
                table: "Eventos",
                column: "localId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntarios_AreaInteresses_areaId",
                table: "Voluntarios",
                column: "areaId",
                principalTable: "AreaInteresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoiId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_enderecos_localId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_AreaInteresses_areaId",
                table: "Voluntarios");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_AreaAtuacaoiId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "AreaAtuacaoiId",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "areaId",
                table: "Voluntarios",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Voluntarios_areaId",
                table: "Voluntarios",
                newName: "IX_Voluntarios_AreaId");

            migrationBuilder.RenameColumn(
                name: "localId",
                table: "Eventos",
                newName: "LocalId");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_localId",
                table: "Eventos",
                newName: "IX_Eventos_LocalId");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_enderecos_LocalId",
                table: "Eventos",
                column: "LocalId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntarios_AreaInteresses_AreaId",
                table: "Voluntarios",
                column: "AreaId",
                principalTable: "AreaInteresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
