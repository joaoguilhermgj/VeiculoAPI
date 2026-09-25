
using Veiculo.Domain.Enums;

namespace Veiculo.Domain.Entities
{
    public class Carro
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Quilometragem { get; set; }
        public StatusManutencao Status { get; set; }
    }
}
