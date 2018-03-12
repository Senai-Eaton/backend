using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eaton.agir.repository.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaAtuacaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaAtuacaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaInteresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaInteresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaAtuacaoId = table.Column<int>(nullable: true),
                    AreaInteresseId = table.Column<int>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    foto = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_AreaAtuacaos_AreaAtuacaoId",
                        column: x => x.AreaAtuacaoId,
                        principalTable: "AreaAtuacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_AreaInteresses_AreaInteresseId",
                        column: x => x.AreaInteresseId,
                        principalTable: "AreaInteresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresas_enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    LocalId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_enderecos_LocalId",
                        column: x => x.LocalId,
                        principalTable: "enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    EnderecoId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Profissao = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    foto = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voluntarios_AreaInteresses_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaInteresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voluntarios_enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_AreaAtuacaoId",
                table: "Empresas",
                column: "AreaAtuacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_AreaInteresseId",
                table: "Empresas",
                column: "AreaInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_EnderecoId",
                table: "Empresas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntarios_AreaId",
                table: "Voluntarios",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntarios_EnderecoId",
                table: "Voluntarios",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "AreaAtuacaos");

            migrationBuilder.DropTable(
                name: "AreaInteresses");

            migrationBuilder.DropTable(
                name: "enderecos");
        }
    }
}
