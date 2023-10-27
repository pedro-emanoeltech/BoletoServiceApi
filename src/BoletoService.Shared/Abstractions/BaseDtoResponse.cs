using BoletoService.Shared.Messages;
using Newtonsoft.Json;
using System;


namespace BoletoService.Shared.Abstractions
{
    public abstract class BaseDtoResponse : IDtoResponse
    {
        /// <summary>
        /// Obtém ou define o ID do registro.
        /// </summary>
        [JsonProperty(Order = 1)]
        public Guid? Id { get; set; }

    }
}



