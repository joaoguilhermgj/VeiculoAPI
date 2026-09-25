using Veiculo.Application.DTOs;
using Veiculo.Application.Services;

namespace Veiculo.API.Endpoints
{
    public static class CarroEndpoints
    {
        public static void MapCarroEndpoints(this WebApplication app)
        {
            var grupo = app.MapGroup("/api/veiculos")
                .WithTags("Veículos");
                //.RequireAutorization();
               

            grupo.MapGet("/", async (CarroService service) =>
                Results.Ok(await service.ListarAsync()));

            grupo.MapGet("/{id:int}", async (int id, CarroService service) =>
            {
                var carro = await service.ObterPorIdAsync(id);
                return carro is null ? Results.NotFound() : Results.Ok(carro);
            });

            grupo.MapPost("/", async (CriarCarroDto dto, CarroService service) =>
            {
                var criado = await service.CriarAsync(dto);
                return Results.Created($"/api/veiculos/{criado.Id}", criado);
            });

            grupo.MapPut("/{id:int}", async (int id, AtualizarCarroDto dto, CarroService service) =>
            {
                var atualizado = await service.AtualizarAsync(id, dto);
                return atualizado ? Results.NoContent() : Results.NotFound();
            });

            grupo.MapDelete("/{id:int}", async (int id, CarroService service) => 
            {
                var removido = await service.RemoverAsync(id);
                return removido ? Results.NoContent() : Results.NotFound();
            });

            }
        }
    }
