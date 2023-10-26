using AutoMapper;
using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Entities;

namespace BoletoService.Api.Controllers
{
    public class BoletoController : BaseController<Boleto, BoletoRequest, BoletoResponse>
    {
        public BoletoController(IBoletoServiceApp serviceApp, IMapper mapper) : base(serviceApp, mapper)
        {
        }
    }
}
