﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using theStyleHub.Models;

#nullable disable

namespace theStyleHub.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProdutosUsuarios", b =>
                {
                    b.Property<int>("CarrinhoId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuariosCarrinhoClerk_id")
                        .HasColumnType("integer");

                    b.HasKey("CarrinhoId", "UsuariosCarrinhoClerk_id");

                    b.HasIndex("UsuariosCarrinhoClerk_id");

                    b.ToTable("UsuarioCarrinho", (string)null);
                });

            modelBuilder.Entity("ProdutosUsuarios1", b =>
                {
                    b.Property<int>("UsuariosWishlistClerk_id")
                        .HasColumnType("integer");

                    b.Property<int>("WishlistId")
                        .HasColumnType("integer");

                    b.HasKey("UsuariosWishlistClerk_id", "WishlistId");

                    b.HasIndex("WishlistId");

                    b.ToTable("UsuarioWishlist", (string)null);
                });

            modelBuilder.Entity("theStyleHub.Models.Avaliacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Clerk_user_id")
                        .HasColumnType("integer");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Id_produto")
                        .HasColumnType("integer");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Clerk_user_id");

                    b.HasIndex("Id_produto");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("theStyleHub.Models.Imagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int?>("Id_avaliacao")
                        .HasColumnType("integer");

                    b.Property<int?>("Id_produto")
                        .HasColumnType("integer");

                    b.Property<string>("TipoImagem")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Id_avaliacao");

                    b.HasIndex("Id_produto");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("theStyleHub.Models.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Clerk_user_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Valor")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Clerk_user_id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("theStyleHub.Models.Produtos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PedidosId")
                        .HasColumnType("integer");

                    b.Property<float>("Promocao")
                        .HasColumnType("float");

                    b.Property<float>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PedidosId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("theStyleHub.Models.Usuarios", b =>
                {
                    b.Property<int>("Clerk_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Clerk_id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Clerk_id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProdutosUsuarios", b =>
                {
                    b.HasOne("theStyleHub.Models.Produtos", null)
                        .WithMany()
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("theStyleHub.Models.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UsuariosCarrinhoClerk_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProdutosUsuarios1", b =>
                {
                    b.HasOne("theStyleHub.Models.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UsuariosWishlistClerk_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("theStyleHub.Models.Produtos", null)
                        .WithMany()
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("theStyleHub.Models.Avaliacoes", b =>
                {
                    b.HasOne("theStyleHub.Models.Usuarios", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("Clerk_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("theStyleHub.Models.Produtos", "Produto")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("Id_produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("theStyleHub.Models.Imagens", b =>
                {
                    b.HasOne("theStyleHub.Models.Avaliacoes", "avaliacoes")
                        .WithMany("Imagens")
                        .HasForeignKey("Id_avaliacao");

                    b.HasOne("theStyleHub.Models.Produtos", "Produto")
                        .WithMany("Imagens")
                        .HasForeignKey("Id_produto");

                    b.Navigation("Produto");

                    b.Navigation("avaliacoes");
                });

            modelBuilder.Entity("theStyleHub.Models.Pedidos", b =>
                {
                    b.HasOne("theStyleHub.Models.Usuarios", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("Clerk_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("theStyleHub.Models.Produtos", b =>
                {
                    b.HasOne("theStyleHub.Models.Pedidos", null)
                        .WithMany("Produtos")
                        .HasForeignKey("PedidosId");
                });

            modelBuilder.Entity("theStyleHub.Models.Avaliacoes", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("theStyleHub.Models.Pedidos", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("theStyleHub.Models.Produtos", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("theStyleHub.Models.Usuarios", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
