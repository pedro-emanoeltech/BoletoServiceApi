using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;

namespace BoletoService.Domain.Services
{
    public class InfoBoletoService : BaseService<Boleto>, IInfoBoletoService
    {
        public InfoBoletoService(IBoletoRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}
