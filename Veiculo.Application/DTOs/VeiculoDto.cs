using Veiculo.Domain.Enums;

namespace Veiculo.Application.DTOs

{
      public record CriarCarroDto(string Placa, string Modelo, int Quilometragem, StatusManutencao Status);
      public record AtualizarCarroDto(string Placa, string Modelo, int Quilometragem, StatusManutencao Status);
      public record CarroDto(int Id, string Placa, string Modelo, int Quilometragem, StatusManutencao Status);
}
