using Microsoft.EntityFrameworkCore;
using Veiculo.Application.Interfaces;
using Veiculo.Domain.Entities;
using Veiculo.Infrastructure.Context;

namespace Veiculo.Infrastructure.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly CarroDbContext _context;

        public CarroRepository(CarroDbContext context)
        {
            _context = context; 
        }

        public async Task AdicionarAsync(Carro carro) =>
            await _context.Carros.AddAsync(carro);
        
        public void Atualizar(Carro carro) => 
            _context.Carros.Update(carro);

        public async Task<Carro?> ObterPorIdAsync(int id) =>
            await _context.Carros.FindAsync(id);

        public async Task<IEnumerable<Carro>> ObterTodosAsync() =>
            await _context.Carros.AsNoTracking().ToListAsync();

        public void Remover(Carro carro) =>
            _context.Carros.Remove(carro);

        public async Task<bool> SalvarAlteracoesAsync() =>
            await _context.SaveChangesAsync() > 0;
       
    }
}
