using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid? Id { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}



