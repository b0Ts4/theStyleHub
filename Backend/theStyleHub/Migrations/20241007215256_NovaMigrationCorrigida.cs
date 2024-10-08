using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace theStyleHub.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigrationCorrigida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Clerk_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Clerk_id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Clerk_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_Clerk_user_id",
                        column: x => x.Clerk_user_id,
                        principalTable: "Usuarios",
                        principalColumn: "Clerk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    Valor = table.Column<float>(type: "float", nullable: false),
                    Promocao = table.Column<float>(type: "float", nullable: false),
                    PedidosId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Conteudo = table.Column<string>(type: "varchar(300)", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Clerk_user_id = table.Column<int>(type: "integer", nullable: false),
                    Id_produto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Produtos_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_Clerk_user_id",
                        column: x => x.Clerk_user_id,
                        principalTable: "Usuarios",
                        principalColumn: "Clerk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCarrinho",
                columns: table => new
                {
                    CarrinhoId = table.Column<int>(type: "integer", nullable: false),
                    UsuariosCarrinhoClerk_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCarrinho", x => new { x.CarrinhoId, x.UsuariosCarrinhoClerk_id });
                    table.ForeignKey(
                        name: "FK_UsuarioCarrinho_Produtos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioCarrinho_Usuarios_UsuariosCarrinhoClerk_id",
                        column: x => x.UsuariosCarrinhoClerk_id,
                        principalTable: "Usuarios",
                        principalColumn: "Clerk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioWishlist",
                columns: table => new
                {
                    UsuariosWishlistClerk_id = table.Column<int>(type: "integer", nullable: false),
                    WishlistId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioWishlist", x => new { x.UsuariosWishlistClerk_id, x.WishlistId });
                    table.ForeignKey(
                        name: "FK_UsuarioWishlist_Produtos_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioWishlist_Usuarios_UsuariosWishlistClerk_id",
                        column: x => x.UsuariosWishlistClerk_id,
                        principalTable: "Usuarios",
                        principalColumn: "Clerk_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Caminho = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoImagem = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id_produto = table.Column<int>(type: "integer", nullable: true),
                    Id_avaliacao = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Avaliacoes_Id_avaliacao",
                        column: x => x.Id_avaliacao,
                        principalTable: "Avaliacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Imagens_Produtos_Id_produto",
                        column: x => x.Id_produto,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_Clerk_user_id",
                table: "Avaliacoes",
                column: "Clerk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_Id_produto",
                table: "Avaliacoes",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_Id_avaliacao",
                table: "Imagens",
                column: "Id_avaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_Id_produto",
                table: "Imagens",
                column: "Id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Clerk_user_id",
                table: "Pedidos",
                column: "Clerk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidosId",
                table: "Produtos",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCarrinho_UsuariosCarrinhoClerk_id",
                table: "UsuarioCarrinho",
                column: "UsuariosCarrinhoClerk_id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioWishlist_WishlistId",
                table: "UsuarioWishlist",
                column: "WishlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "UsuarioCarrinho");

            migrationBuilder.DropTable(
                name: "UsuarioWishlist");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
