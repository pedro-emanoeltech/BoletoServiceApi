﻿using BoletoService.Shared.Messages;
using FluentValidation;

namespace BoletoService.Application.Dtos.Request
{
    /// <summary>
    /// Representa um banco a ser cadastrado.
    /// </summary>
    public class BancoRequest : IDtoRequest
    {
        /// <summary>
        /// Obtém ou define o nome do banco.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o código do banco.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Obtém ou define o percentual de juros cobrado pelo banco.
        /// </summary>
        public decimal PercentualJuros { get; set; }

        public class BancoRequestValidator : AbstractValidator<BancoRequest>
        {
            public BancoRequestValidator()
            {
                RuleFor(banco => banco.Nome)
                    .NotEmpty().WithMessage("O nome do banco é obrigatório.");

                RuleFor(banco => banco.Codigo)
                    .NotEmpty().WithMessage("O código do banco é obrigatório.");

                RuleFor(banco => banco.PercentualJuros)
                    .NotEmpty().WithMessage("O percentual de juros é obrigatório.");
            }
        }
    }

}
