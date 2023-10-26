using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Infra.Context;

namespace BoletoService.Infra.Services
{
    public class BoletoRepository : BaseRepository<Boleto>, IBoletoRepository
    {
        public BoletoRepository(BoletoContext context) : base(context)
        {
        }
    }
}
