using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Infra.Context;
using System.Threading.Tasks;


namespace BoletoService.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoletoContext _context;
        public UnitOfWork(BoletoContext context) => _context = context;

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
