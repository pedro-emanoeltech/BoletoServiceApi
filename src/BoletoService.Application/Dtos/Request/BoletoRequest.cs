using BoletoService.Shared.Messages;
using FluentValidation;
using System;

namespace BoletoService.Application.Dtos.Request
{
    public class BoletoRequest : IDtoRequest
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
        public string? CpfCnpjPagador { get; set; }

        /// <summary>
        /// Obtém ou define o nome do Beneficiário. 
        /// </summary>
        public string? NomeBeneficiario { get; set; }

        /// <summary>
        /// Obtém ou define o CPF ou CNPJ do Beneficiário.
        /// </summary>
        public string? CpfCnpjBeneficiario { get; set; }

        /// <summary>
        /// Obtém ou define as observações do boleto.
        /// </summary>
        public string? Observacoes { get; set; }

        /// <summary>
        /// Obtém ou define o valor para o boleto.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Obtém ou define a data de vencimento do boleto.
        /// </summary>
        public DateTime DataVencimento { get; set; }

        public class BancoRequestValidator : AbstractValidator<BoletoRequest>
        {
            public BancoRequestValidator()
            {
                RuleFor(banco => banco.BancoId)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar Id do banco");

                RuleFor(banco => banco.NomePagador)
                    .NotNull().NotEmpty().WithMessage("O nome do pagador é obrigatório.");

                RuleFor(banco => banco.CpfCnpjPagador)
                    .NotNull().NotEmpty().WithMessage("O documento do pagador é obrigatório.");

                RuleFor(banco => banco.NomeBeneficiario)
                    .NotNull().NotEmpty().WithMessage("O nome do Beneficiário é obrigatório.");

                RuleFor(banco => banco.CpfCnpjBeneficiario)
                    .NotNull().NotEmpty().WithMessage("O documento do Beneficiário é obrigatório.");

                RuleFor(banco => banco.Valor).NotNull()
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar valor do Boleto.");

                RuleFor(banco => banco.DataVencimento)
                    .NotNull().NotEmpty().WithMessage("É obrigatório informar data Vencimento do boleto");


            }
        }
    }
}
