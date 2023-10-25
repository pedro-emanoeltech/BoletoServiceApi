using System;

namespace BoletoService.Shared.Abstractions
{
    /// <summary>
    /// Entidade com a chave type <see cref="Guid"/>.
    /// </summary>
    public abstract class BaseEntity : IEntity
    {
        /// <summary>
        /// Obtém ou define o ID do registro.
        /// </summary>
        public Guid Id { get; private init; } = Guid.NewGuid();
    }
}



