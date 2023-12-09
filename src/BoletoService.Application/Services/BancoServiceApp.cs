using AutoMapper;
using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;
using FluentValidation;
using Pe.Shared.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoService.Application.Services
{
    public class BancoServiceApp : BaseServiceApp<Banco, BancoRequest, BancoResponse>, IBancoServiceApp
    {
        private readonly IBancoService _service;
        private readonly IMapper _mapper;
        public BancoServiceApp(IBancoService service, IUnitOfWork unitOfWork, IMapper mapper, IValidator<BancoRequest> validator) : base(service, mapper, unitOfWork, validator)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IResult> ListarBancos()
        {
            var result = await _service.ListarBancos();
            if (result is null || !result.Any())
            {
                return ResultFailed.New("Não existe bancos registrados");
            }

            return ResultListSucess<BancoResponse>.New(_mapper.Map<IEnumerable<BancoResponse>>(result));
        }
        public async Task<IResult> GetByCodigoBanco(string codigoBanco)
        {
            if (string.IsNullOrWhiteSpace(codigoBanco))
            {
                return ResultFailed.New("codigo do banco não pode ser vazio");
            }
            var banco = await _service.GetByCodigoBanco(codigoBanco);
            return ResultSucess<BancoResponse>.New(_mapper.Map<BancoResponse>(banco));
        }
    }
}
