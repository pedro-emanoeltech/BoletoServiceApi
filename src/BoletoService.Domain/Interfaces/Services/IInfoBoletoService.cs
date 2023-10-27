using BoletoService.Domain.Entities;

namespace BoletoService.Domain.Interfaces.Services
{
    public interface IInfoBoletoService : IBaseService<Boleto>
    {
        Task<IEnumerable<Boleto>?> ListaBoletosAsync();
    }
}
