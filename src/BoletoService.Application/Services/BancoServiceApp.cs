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
    public class BancoServiceApp : BaseServiceApp<Banco, BancoRequest, BancoResponse>, IBancoServiceApp
    {
        public BancoServiceApp(IBancoService service, IUnitOfWork unitOfWork, IMapper mapper, IValidator<BancoRequest> validator) : base(service, mapper, unitOfWork, validator)
        {
        }
    }
}
