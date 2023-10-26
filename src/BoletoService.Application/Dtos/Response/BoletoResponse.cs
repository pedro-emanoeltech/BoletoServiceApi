using BoletoService.Shared.Messages;
using System;

namespace BoletoService.Application.Dtos.Response
{
    public class BoletoResponse : IDtoResponse
    {
        /// <summary>
        /// Obtém ou define o nome do pagador. 
        /// </summary>
        public string NomePagador { get; set; }

        /// <summary>
        /// Obtém ou define o CPF ou CNPJ do pagador.
        /// </summary>
        public string CpfCnpjPagador { get; set; }

        /// <summary>
        /// Obtém ou define o nome do Beneficiário. 
        /// </summary>
        public string NomeBeneficiario { get; set; }

        /// <summary>
        /// Obtém ou define o CPF ou CNPJ do Beneficiário.
        /// </summary>
        public string CpfCnpjBeneficiario { get; set; }

        /// <summary>
        /// Obtém ou define as observações do boleto.
        /// </summary>
        public string Observacoes { get; set; }

        /// <summary>
        /// Obtém ou define o valor para o boleto.
        /// </summary>
        public decimal Valor { get; set; } = decimal.Zero;

        /// <summary>
        /// Obtém ou define a data de vencimento do boleto.
        /// </summary>
        public DateTime DataVencimento { get; set; }

        public BancoResponse Banco { get; set; }
    }
}
