using Veiculo.Domain.Entities;

namespace Veiculo.Application.Interfaces
{
    public interface ICarroRepository
    {
        Task<Carro?> ObterPorIdAsync(int id);
        Task<IEnumerable<Carro>> ObterTodosAsync();
        Task AdicionarAsync(Carro carro);
        void Atualizar(Carro carro);
        void Remover(Carro carro);
        Task<bool> SalvarAlteracoesAsync();
    }
}
