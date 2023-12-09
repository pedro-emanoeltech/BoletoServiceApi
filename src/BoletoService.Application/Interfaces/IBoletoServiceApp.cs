using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Domain.Entities;
using Pe.Shared.Messages;
using System.Threading.Tasks;

namespace BoletoService.Application.Interfaces
{
    public interface IBoletoServiceApp : IBaseServiceApp<Boleto, BoletoRequest, BoletoResponse>
    {
        Task<IResult> ListarBoletos();
    }
}
