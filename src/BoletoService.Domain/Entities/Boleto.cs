using BoletoService.Shared.Abstractions;

namespace BoletoService.Domain.Entities
{
    public class Boleto : BaseEntity
    {
        /// <summary>
        /// Obtém ou define o ID do banco.
        /// </summary>
        public Guid BancoId { get; set; }

        /// <summary>
        /// Obtém ou define o nome do pagador. 
        /// </summary>
        public string? NomePagador { get; set; }

        /// <summary>
        /// Obtém ou define o CPF ou CNPJ do pagador.
        /// </summary>
        public string? CPFCNPJPagador { get; set; }

        public Banco? Banco { get; set; }
    }
}
