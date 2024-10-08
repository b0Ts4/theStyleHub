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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração do relacionamento muitos-para-muitos
        modelBuilder.Entity<Usuarios>()
            .HasMany(u => u.Carrinho)
            .WithMany(p => p.UsuariosCarrinho)  // Certifique-se de que a classe Produtos tem essa lista
            .UsingEntity(j => j.ToTable("UsuarioCarrinho"));  // Nome da tabela intermediária

        modelBuilder.Entity<Usuarios>()
            .HasMany(u => u.Wishlist)
            .WithMany(p => p.UsuariosWishlist)  // Certifique-se de que a classe Produtos tem essa lista
            .UsingEntity(j => j.ToTable("UsuarioWishlist"));  // Nome da tabela intermediária
    }
}
