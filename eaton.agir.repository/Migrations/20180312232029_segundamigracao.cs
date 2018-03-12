using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eaton.agir.repository.Migrations
{
    public partial class segundamigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaInteresses_AreaInteresseId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_enderecos_EnderecoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_enderecos_LocalId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_AreaInteresses_AreaId",
                table: "Voluntarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_enderecos_EnderecoId",
                table: "Voluntarios");

            migrationBuilder.AlterColumn<string>(
                name: "foto",
                table: "Voluntarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Voluntarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Profissao",
                table: "Voluntarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Voluntarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Voluntarios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Voluntarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Voluntarios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "enderecos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "foto",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaInteresseId",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaAtuacaoId",
                table: "Empresas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AreaInteresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AreaAtuacaos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                table: "Empresas",
                column: "AreaAtuacaoId",
                principalTable: "AreaAtuacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AreaInteresses_AreaInteresseId",
                table: "Empresas",
                column: "AreaInteresseId",
                principalTable: "AreaInteresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_enderecos_EnderecoId",
                table: "Empresas",
                column: "EnderecoId",
                principalTable: "enderecos",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntarios_enderecos_EnderecoId",
                table: "Voluntarios",
                column: "EnderecoId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_AreaInteresses_AreaInteresseId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_enderecos_EnderecoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_enderecos_LocalId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_AreaInteresses_AreaId",
                table: "Voluntarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Voluntarios_enderecos_EnderecoId",
                table: "Voluntarios");

            migrationBuilder.AlterColumn<string>(
                name: "foto",
                table: "Voluntarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Voluntarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Profissao",
                table: "Voluntarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Voluntarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Voluntarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Voluntarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Voluntarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Eventos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Eventos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Eventos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "enderecos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "enderecos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "enderecos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "enderecos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "foto",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RazaoSocial",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AreaInteresseId",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AreaAtuacaoId",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AreaInteresses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AreaAtuacaos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                table: "Empresas",
                column: "AreaAtuacaoId",
                principalTable: "AreaAtuacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_AreaInteresses_AreaInteresseId",
                table: "Empresas",
                column: "AreaInteresseId",
                principalTable: "AreaInteresses",
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
                name: "FK_Eventos_enderecos_LocalId",
                table: "Eventos",
                column: "LocalId",
                principalTable: "enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voluntarios_AreaInteresses_AreaId",
                table: "Voluntarios",
                column: "AreaId",
                principalTable: "AreaInteresses",
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
