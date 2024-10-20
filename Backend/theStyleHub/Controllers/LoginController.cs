using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;
using theStyleHub.Models;
using theStyleHub.Services;

namespace theStyleHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly TokenService _tokenService;

    public LoginController(ApplicationDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var usuario = _context.Usuarios.FirstOrDefault(p => p.Email == request.Email);

        if (usuario == null)
        {
            return Unauthorized(new { message = "Email ou senha incorretos"});
        }

        bool CheckPassword = BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Hash_senha);

        if (!CheckPassword)
        {
            return Unauthorized(new { message = "Senha incorreta" });
        }

        var token = _tokenService.gerarTokenJWT(usuario);

        return Ok(new {message = "Login realizado com sucesso"});
    }
}
public class LoginRequest
{
public string Email { get; set; }
public string Senha { get; set; }
}
