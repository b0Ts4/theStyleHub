using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theStyleHub.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoWishlistUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCarrinho_Produtos_CarrinhoId",
                table: "UsuarioCarrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCarrinho_Usuarios_UsuariosCarrinhoClerk_id",
                table: "UsuarioCarrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioWishlist_Produtos_WishlistId",
                table: "UsuarioWishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioWishlist_Usuarios_UsuariosWishlistClerk_id",
                table: "UsuarioWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioWishlist",
                table: "UsuarioWishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioCarrinho",
                table: "UsuarioCarrinho");

            migrationBuilder.RenameTable(
                name: "UsuarioWishlist",
                newName: "Wishlist");

            migrationBuilder.RenameTable(
                name: "UsuarioCarrinho",
                newName: "Carrinho");

            migrationBuilder.RenameColumn(
                name: "UsuariosWishlistClerk_id",
                table: "Wishlist",
                newName: "Usuarios1Clerk_id");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioWishlist_WishlistId",
                table: "Wishlist",
                newName: "IX_Wishlist_WishlistId");

            migrationBuilder.RenameColumn(
                name: "UsuariosCarrinhoClerk_id",
                table: "Carrinho",
                newName: "UsuariosClerk_id");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioCarrinho_UsuariosCarrinhoClerk_id",
                table: "Carrinho",
                newName: "IX_Carrinho_UsuariosClerk_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist",
                columns: new[] { "Usuarios1Clerk_id", "WishlistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho",
                columns: new[] { "CarrinhoId", "UsuariosClerk_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Produtos_CarrinhoId",
                table: "Carrinho",
                column: "CarrinhoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Usuarios_UsuariosClerk_id",
                table: "Carrinho",
                column: "UsuariosClerk_id",
                principalTable: "Usuarios",
                principalColumn: "Clerk_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Produtos_WishlistId",
                table: "Wishlist",
                column: "WishlistId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Usuarios_Usuarios1Clerk_id",
                table: "Wishlist",
                column: "Usuarios1Clerk_id",
                principalTable: "Usuarios",
                principalColumn: "Clerk_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Produtos_CarrinhoId",
                table: "Carrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Usuarios_UsuariosClerk_id",
                table: "Carrinho");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Produtos_WishlistId",
                table: "Wishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Usuarios_Usuarios1Clerk_id",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlist",
                table: "Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrinho",
                table: "Carrinho");

            migrationBuilder.RenameTable(
                name: "Wishlist",
                newName: "UsuarioWishlist");

            migrationBuilder.RenameTable(
                name: "Carrinho",
                newName: "UsuarioCarrinho");

            migrationBuilder.RenameColumn(
                name: "Usuarios1Clerk_id",
                table: "UsuarioWishlist",
                newName: "UsuariosWishlistClerk_id");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlist_WishlistId",
                table: "UsuarioWishlist",
                newName: "IX_UsuarioWishlist_WishlistId");

            migrationBuilder.RenameColumn(
                name: "UsuariosClerk_id",
                table: "UsuarioCarrinho",
                newName: "UsuariosCarrinhoClerk_id");

            migrationBuilder.RenameIndex(
                name: "IX_Carrinho_UsuariosClerk_id",
                table: "UsuarioCarrinho",
                newName: "IX_UsuarioCarrinho_UsuariosCarrinhoClerk_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioWishlist",
                table: "UsuarioWishlist",
                columns: new[] { "UsuariosWishlistClerk_id", "WishlistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioCarrinho",
                table: "UsuarioCarrinho",
                columns: new[] { "CarrinhoId", "UsuariosCarrinhoClerk_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCarrinho_Produtos_CarrinhoId",
                table: "UsuarioCarrinho",
                column: "CarrinhoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCarrinho_Usuarios_UsuariosCarrinhoClerk_id",
                table: "UsuarioCarrinho",
                column: "UsuariosCarrinhoClerk_id",
                principalTable: "Usuarios",
                principalColumn: "Clerk_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioWishlist_Produtos_WishlistId",
                table: "UsuarioWishlist",
                column: "WishlistId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioWishlist_Usuarios_UsuariosWishlistClerk_id",
                table: "UsuarioWishlist",
                column: "UsuariosWishlistClerk_id",
                principalTable: "Usuarios",
                principalColumn: "Clerk_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
