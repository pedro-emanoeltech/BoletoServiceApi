using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Entities;
using BoletoService.Shared.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoletoService.Api.Controllers
{
    public class BoletoController : BaseController<Boleto, BoletoRequest, BoletoResponse>
    {
        private readonly IBoletoServiceApp _service;
        public BoletoController(IBoletoServiceApp serviceApp) : base(serviceApp)
        {
            _service = serviceApp;
        }

        /// <summary>
        /// Obtém uma lista boletos.
        /// </summary>
        /// <remarks>
        /// Retorna uma lista de boletos.
        /// </remarks>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BoletoResumoResponse>), 400)]
        [ProducesResponseType(typeof(IEnumerable<BoletoResumoResponse>), 500)]
        public async Task<ActionResult<ResultListSucess<BoletoResumoResponse>>> ListarBancos()
        {
            Shared.Messages.IResult result = await _service.ListarBoletos();
            if (result is ResultFailed resultFail)
            {
                return BadRequest(resultFail.Message);
            }

            return Ok(result);
        }
    }
}
