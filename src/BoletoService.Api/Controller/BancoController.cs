using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Entities;
using BoletoService.Shared.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoletoService.Api.Controllers
{
    public class BancoController : BaseController<Banco, BancoRequest, BancoResponse>
    {
        private readonly IBancoServiceApp _serviceApp;
        public BancoController(IBancoServiceApp serviceApp) : base(serviceApp)
        {
            _serviceApp = serviceApp;
        }

        /// <summary>
        /// Obtém uma lista bancos.
        /// </summary>
        /// <remarks>
        /// Retorna uma lista de bancos.
        /// </remarks>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BancoResponse>), 400)]
        [ProducesResponseType(typeof(IEnumerable<BancoResponse>), 500)]
        public async Task<ActionResult<ResultListSucess<BancoResponse>>> ListarBancos()
        {
            Shared.Messages.IResult result = await _serviceApp.ListarBancos();
            if (result is ResultFailed resultFail)
            {
                return BadRequest(resultFail.Message);
            }

            return Ok(result);
        }

        /// <summary>
        /// Obtém um registro Banco pelo seu codigo.
        /// </summary>
        /// <remarks>
        /// Obtém um registro Banco
        /// </remarks>
        /// <param name="codigoBanco">Codigo do banco</param>
        [HttpGet("{codigoBanco}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(Banco), 400)]
        [ProducesResponseType(typeof(Banco), 500)]
        public virtual async Task<ActionResult<BancoResponse>> GetByCodigoBanco(string codigoBanco)
        {
            Shared.Messages.IResult result = await _serviceApp.GetByCodigoBanco(codigoBanco);
            if (result is ResultFailed resultFail)
            {
                return BadRequest(resultFail.Message);
            }

            if (result is ResultSucess<BancoResponse> resultSucess && resultSucess.Data == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
