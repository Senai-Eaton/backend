using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eaton.agir.repository.Migrations
{
    public partial class semifinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaAtuacaos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
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
                    Nome = table.Column<string>(nullable: false)
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
                    Bairro = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Logradouro = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voluntarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Profissao = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    areaId = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    foto = table.Column<string>(nullable: false),
                    senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voluntarios_AreaInteresses_areaId",
                        column: x => x.areaId,
                        principalTable: "AreaInteresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaAtuacaoId = table.Column<int>(nullable: false),
                    AreaInteresseId = table.Column<int>(nullable: false),
                    Cnpj = table.Column<string>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    endeId = table.Column<int>(nullable: false),
                    enderecoId = table.Column<int>(nullable: false),
                    foto = table.Column<string>(nullable: false),
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
                        name: "FK_Empresas_enderecos_endeId",
                        column: x => x.endeId,
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
                    Descricao = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    localId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_enderecos_localId",
                        column: x => x.localId,
                        principalTable: "enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariosEventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    eventoId = table.Column<int>(nullable: false),
                    voluntarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariosEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoluntariosEventos_Eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoluntariosEventos_Voluntarios_voluntarioId",
                        column: x => x.voluntarioId,
                        principalTable: "Voluntarios",
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
                name: "IX_Empresas_endeId",
                table: "Empresas",
                column: "endeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_localId",
                table: "Eventos",
                column: "localId");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntarios_areaId",
                table: "Voluntarios",
                column: "areaId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariosEventos_eventoId",
                table: "VoluntariosEventos",
                column: "eventoId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariosEventos_voluntarioId",
                table: "VoluntariosEventos",
                column: "voluntarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "VoluntariosEventos");

            migrationBuilder.DropTable(
                name: "AreaAtuacaos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Voluntarios");

            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "AreaInteresses");
        }
    }
}
