using AutoMapper;
using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;
using BoletoService.Shared.Messages;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoService.Application.Services
{
    public class BoletoServiceApp : BaseServiceApp<Boleto, BoletoRequest, BoletoResponse>, IBoletoServiceApp
    {
        private readonly IInfoBoletoService _service;
        private readonly IMapper _mapper;
        public BoletoServiceApp(IInfoBoletoService service, IUnitOfWork unitOfWork, IMapper mapper, IValidator<BoletoRequest> validator) : base(service, mapper, unitOfWork, validator)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IResult> ListarBoletos()
        {
            var result = await _service.ListaBoletosAsync();
            if (result is null || !result.Any())
            {
                return ResultFailed.New("Não existe boletos registrados");
            }

            return ResultListSucess<BoletoResumoResponse>.New(_mapper.Map<IEnumerable<BoletoResumoResponse>>(result));
        }

    }
}
