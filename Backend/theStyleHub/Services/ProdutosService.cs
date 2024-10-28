using theStyleHub.Models;

namespace theStyleHub.Services;

public class ProdutosService
{
    public void addWishlist(Produtos produto, Usuarios user)
    {
        user.Wishlist.Add(produto);
    }

    public void removeWishlist(Produtos produto, Usuarios user)
    {
        user.Wishlist.Remove(produto);
    }

    public void addCarrinho(Produtos produto, Usuarios user)
    {
        user.Carrinho.Add(produto);
    }

    public void removeCarrinho(Produtos produto, Usuarios user)
    {
        user.Carrinho.Remove(produto);
    }
}
