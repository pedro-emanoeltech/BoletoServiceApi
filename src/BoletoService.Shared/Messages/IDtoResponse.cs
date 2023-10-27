using System;

namespace BoletoService.Shared.Messages
{
    /// <summary>
    /// interface base de respostas da API.
    /// </summary>
    public interface IDtoResponse
    {
        Guid? Id { get; }
    }
}
