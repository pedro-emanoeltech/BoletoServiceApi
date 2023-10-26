using System.Collections.Generic;

namespace BoletoService.Shared.Messages
{
    /// <summary>
    /// interface base de requisição bem sucedida na API.
    /// </summary>
    public interface IResultListSucess<T> : IResult where T : IDtoResponse
    {
        IEnumerable<T?> Itens { get; set; }
    }
}
