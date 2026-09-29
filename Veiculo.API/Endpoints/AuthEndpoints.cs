using Microsoft.AspNetCore.Identity;
using Veiculo.Application.Interfaces;
using Veiculo.Infrastructure.Identity;

namespace Veiculo.API.Endpoints
{
     public record RegistrarUsuarioDto(string Email, string Senha);
     public record LoginDto(string Email, string Senha);
    
    public static class AuthEndpoints
    { 
      public static void MapAuthEndpoints(this WebApplication app)
        {
            var grupo = app.MapGroup("/api/auth").WithTags("Autenticação");

            grupo.MapPost("/registrar", async (RegistrarUsuarioDto dto, UserManager<ApplicationUser> userManager) =>
            {
                var usuario = new ApplicationUser { UserName = dto.Email, Email = dto.Email, };
                var resultado = await userManager.CreateAsync(usuario, dto.Senha);

                return resultado.Succeeded
                ? Results.Created(string.Empty, new { usuario.Id, usuario.Email })
                : Results.BadRequest(resultado.Errors.Select(e => e.Description));
            });

            grupo.MapPost("/login", async (LoginDto dto, UserManager<ApplicationUser> userManager, ITokenService tokenService) =>
            {
                var usuario = await userManager.FindByEmailAsync(dto.Email);
                if (usuario is null || !await userManager.CheckPasswordAsync(usuario, dto.Senha))
                    return Results.Unauthorized();

                var roles = await userManager.GetRolesAsync(usuario);
                var token = tokenService.GerarToken(usuario.Id, usuario.Email!, roles);

                return Results.Ok(new { token });


            });
        }  
    }
}
