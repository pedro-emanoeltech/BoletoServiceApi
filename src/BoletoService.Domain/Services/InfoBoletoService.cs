using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;

namespace BoletoService.Domain.Services
{
    public class InfoBoletoService : BaseService<Boleto>, IInfoBoletoService
    {
        private readonly IBoletoRepository _repository;
        private readonly IBancoService _bancoService;
        public InfoBoletoService(IBoletoRepository repository, IUnitOfWork unitOfWork, IBancoService bancoService) : base(repository, unitOfWork)
        {
            _repository = repository;
            _bancoService = bancoService;
        }
        public async Task<IEnumerable<Boleto>?> ListaBoletosAsync()
        {
            return await _repository.GetToList(orderBy: x => x.DataVencimento!);
        }
        public override async Task<Boleto?> Get(Guid id)
        {
            return await CalculaAcrecimoVencimentoBoleto(await base.Get(id));
        }
        private async Task<Boleto?> CalculaAcrecimoVencimentoBoleto(Boleto? boleto)
        {
            if (boleto is not null && BoletoVencido(boleto))
            {
                var banco = await _bancoService.Get(boleto.BancoId);
                decimal taxaDeJuros = banco!.PercentualJuros / 100;
                boleto.Valor *= (1 + taxaDeJuros);
            }
            return boleto;
        }
        private static bool BoletoVencido(Boleto boleto)
        {
            var dataAtual = DateTime.Now;
            return dataAtual > boleto.DataVencimento;
        }
    }
}
