namespace theStyleHub.Models;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Produtos> Produtos { get; set; }
    public DbSet<Avaliacoes> Avaliacoes { get; set; }
    public DbSet<Imagens> Imagens { get; set; }
    public DbSet<Pedidos> Pedidos { get; set; }
    public DbSet<ItensCarrinho> ItensCarrinho { get; set; }
    public DbSet<ItensWishlist> ItensWishlist { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensCarrinho>()
            .HasOne(ci => ci.Usuario)
            .WithMany(u => u.ItensCarrinho)
            .HasForeignKey(ci => ci.UsuarioId);

        modelBuilder.Entity<ItensCarrinho>()
            .HasOne(ci => ci.Produto)
            .WithMany(p => p.ItensCarrinho)
            .HasForeignKey(ci => ci.ProdutoId);

        modelBuilder.Entity<ItensWishlist>()
            .HasOne(wi => wi.Usuario)
            .WithMany(u => u.ItensWishlist)
            .HasForeignKey(wi => wi.UsuarioId);

        modelBuilder.Entity<ItensWishlist>()
            .HasOne(wi => wi.Produto)
            .WithMany(p => p.ItensWishlist)
            .HasForeignKey(wi => wi.ProdutoId);
    }
}
