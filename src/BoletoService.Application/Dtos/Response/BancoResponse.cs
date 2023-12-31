﻿using Pe.Shared.Abstractions;

namespace BoletoService.Application.Dtos.Response
{
    /// <summary>
    /// Representa um banco a ser cadastrado.
    /// </summary>
    public class BancoResponse : BaseDtoResponse
    {

        /// <summary>
        /// Obtém ou define o nome do banco.
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// Obtém ou define o código do banco.
        /// </summary>
        public string? Codigo { get; set; }

        /// <summary>
        /// Obtém ou define o percentual de juros cobrado pelo banco.
        /// </summary>
        public decimal PercentualJuros { get; set; }

    }

}
