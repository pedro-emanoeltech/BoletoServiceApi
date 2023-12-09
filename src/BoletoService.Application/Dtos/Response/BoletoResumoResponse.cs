using Pe.Shared.Abstractions;
using System;

namespace BoletoService.Application.Dtos.Response
{
    public class BoletoResumoResponse : BaseDtoResponse
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
        /// Obtém ou define o nome do Beneficiário. 
        /// </summary>
        public string? NomeBeneficiario { get; set; }

        /// <summary>
        /// Obtém ou define o valor para o boleto.
        /// </summary>
        public decimal Valor { get; set; } = decimal.Zero;

        /// <summary>
        /// Obtém ou define a data de vencimento do boleto.
        /// </summary>
        public DateTime? DataVencimento { get; set; }

    }
}
