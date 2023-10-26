using AutoMapper;
using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;
using BoletoService.Shared.Messages;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace BoletoService.Application.Services
{
    public class BoletoServiceApp : BaseServiceApp<Boleto, BoletoRequest, BoletoResponse>, IBoletoServiceApp
    {
        public BoletoServiceApp(IInfoBoletoService service, IUnitOfWork unitOfWork, IMapper mapper, IValidator<BoletoRequest> validator) : base(service, mapper, unitOfWork, validator)
        {
        }
        public override async Task<IResult> Get(Guid id)
        {
            await base.Get(id);
            return
        }
    }
}
