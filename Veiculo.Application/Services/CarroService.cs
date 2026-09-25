using Veiculo.Application.DTOs;
using Veiculo.Application.Interfaces;
using Veiculo.Domain.Entities;

namespace Veiculo.Application.Services
{
    public class CarroService
    {
        private readonly ICarroRepository _repository;

        public CarroService(ICarroRepository repository)
        {
            _repository = repository;
        }

        public async Task <IEnumerable<CarroDto>> ListarAsync()
        {
            var carros = await _repository.ObterTodosAsync();
            return carros.Select(MapToDto);
        }

        public async Task <CarroDto?> ObterPorIdAsync(int id)
        {
            var carro = await _repository.ObterPorIdAsync(id);
            return carro is null ? null : MapToDto(carro);
        }

        public async Task<CarroDto> CriarAsync(CriarCarroDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Placa))
                throw new ArgumentException("A placa do veículo é obrigatória. ");

            var carro = new Carro
            {
                Placa = dto.Placa,
                Modelo = dto.Modelo,
                Quilometragem = dto.Quilometragem,
                Status = dto.Status,
            };

            await _repository.AdicionarAsync(carro);
            await _repository.SalvarAlteracoesAsync();

            return MapToDto(carro);
        }

        public async Task<bool> AtualizarAsync(int id, AtualizarCarroDto dto)
        {
            var carro = await _repository.ObterPorIdAsync(id);
            if (carro is null) return false;

            carro.Placa = dto.Placa;
            carro.Modelo = dto.Modelo;
            carro.Quilometragem = dto.Quilometragem;
            carro.Status = dto.Status;

            _repository.Atualizar(carro);
            return await _repository.SalvarAlteracoesAsync();
        }

        public async Task <bool> RemoverAsync(int id)
        {
            var carro = await _repository.ObterPorIdAsync(id);
            if (carro is null) return false;

            _repository.Remover(carro);
            return await _repository.SalvarAlteracoesAsync();
        }
        private static CarroDto MapToDto(Carro c) =>
            new(c.Id, c.Placa, c.Modelo, c.Quilometragem, c.Status);

    }
}
