using System;

namespace BoletoService.Shared.Abstractions
{
    /// <summary>
    /// Interface para representar entidade.
    /// </summary>
    public interface IEntity
    {
        Guid? Id { get; }
    }
}
