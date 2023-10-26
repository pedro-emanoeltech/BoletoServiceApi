using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Infra.Context;

namespace BoletoService.Infra.Services
{
    public class BancoRepository : BaseRepository<Banco>, IBancoRepository
    {
        public BancoRepository(BoletoContext context) : base(context)
        {
        }
    }
}
