using AutoMapper;
using BoletoService.Application.Dtos.Request;
using BoletoService.Domain.Entities;

namespace BoletoService.Application.AutoMapper
{
    public class RequestToDomainMapper : Profile
    {
        public RequestToDomainMapper()
        {
            CreateMap<BancoRequest, Banco>(MemberList.Destination);
            CreateMap<BoletoRequest, Boleto>(MemberList.Destination);
        }
    }
}
