using AutoMapper;
using BoletoService.Application.Dtos.Response;
using BoletoService.Domain.Entities;

namespace BoletoService.Application.AutoMapper
{
    public class DomainToResponseMapper : Profile
    {
        public DomainToResponseMapper()
        {
            CreateMap<Boleto, BoletoResponse>(MemberList.Destination);
            CreateMap<Boleto, BoletoResumoResponse>(MemberList.Destination);
            CreateMap<Banco, BancoResponse>(MemberList.Destination);
        }
    }
}
