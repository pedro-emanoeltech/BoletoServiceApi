using BoletoService.Domain.Entities;

namespace BoletoService.Domain.Interfaces.Services
{
    public interface IBancoService : IBaseService<Banco>
    {
        Task<IEnumerable<Banco>?> ListarBancos();
        Task<Banco?> GetByCodigoBanco(string codigoBanco);
    }
}
