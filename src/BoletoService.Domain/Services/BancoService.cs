using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;

namespace BoletoService.Domain.Services
{
    public class BancoService : BaseService<Banco>, IBancoService
    {
        private readonly IBancoRepository _repository;
        public BancoService(IBancoRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Banco>?> ListarBancos()
        {
            return await _repository.GetToList();
        }
        public async Task<Banco?> GetByCodigoBanco(string codigoBanco)
        {
            return await _repository.GetFirstOrDefault(p => p.Codigo == codigoBanco);
        }
    }
}
