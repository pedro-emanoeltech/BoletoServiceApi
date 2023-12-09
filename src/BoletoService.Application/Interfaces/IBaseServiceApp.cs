using Pe.Shared.Abstractions;
using Pe.Shared.Messages;
using System;
using System.Threading.Tasks;

namespace BoletoService.Application.Interfaces
{
    public interface IBaseServiceApp<TEntity, TEntityRequest, TEntityResponse>
        where TEntity : BaseEntity, IEntity
        where TEntityRequest : IDtoRequest
        where TEntityResponse : IDtoResponse
    {
        Task<IResult> Add(TEntityRequest entityRequest);
        Task<IResult> Get(Guid id);

    }
}
