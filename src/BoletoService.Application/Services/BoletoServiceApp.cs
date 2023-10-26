using AutoMapper;
using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;
using FluentValidation;

namespace BoletoService.Application.Services
{
    public class BoletoServiceApp : BaseServiceApp<Boleto, BoletoRequest, BoletoResponse>, IBoletoServiceApp
    {
        public BoletoServiceApp(IInfoBoletoService service, IUnitOfWork unitOfWork, IMapper mapper, IValidator<BoletoRequest> validator) : base(service, mapper, unitOfWork, validator)
        {
        }

    }
}
