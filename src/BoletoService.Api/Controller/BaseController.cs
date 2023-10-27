using BoletoService.Application.Interfaces;
using BoletoService.Shared.Abstractions;
using BoletoService.Shared.Messages;
using Microsoft.AspNetCore.Mvc;

namespace BoletoService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Consumes("application/json", new string[] { })]
    [Produces("application/json", new string[] { })]
    [ApiController]
    public abstract class BaseController<TEntity, TEntityRequest, TEntityResponse> : ControllerBase
        where TEntity : BaseEntity, IEntity
        where TEntityRequest : IDtoRequest
        where TEntityResponse : IDtoResponse
    {

        private readonly IBaseServiceApp<TEntity, TEntityRequest, TEntityResponse> _serviceApp;
        public BaseController(IBaseServiceApp<TEntity, TEntityRequest, TEntityResponse> serviceApp)
        {
            _serviceApp = serviceApp;
        }

        /// <summary>
        /// Cria uma registro.
        /// </summary>
        /// <remarks>
        /// Retorna uma lista paginada de lojas por filtros.
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(ResultFailed), 400)]
        [ProducesResponseType(typeof(ResultFailed), 500)]
        public virtual async Task<ActionResult<TEntityResponse>> Add([FromBody] TEntityRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Conteúdo não pode ser nulo");
                }

                var result = await _serviceApp.Add(request);
                if (result is ResultFailed)
                {
                    return BadRequest(result);
                }
                TEntityResponse? data = ((ResultSucess<TEntityResponse>)result).Data;

                return (ActionResult<TEntityResponse>)Ok(data);
            }
            catch (Exception e)
            {
                return (ActionResult<TEntityResponse>)BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Obtém um registro pelo seu Id.
        /// </summary>
        /// <remarks>
        /// Retorna uma registro por Id.
        /// </remarks>
        /// <param name="id">Id</param>
        [HttpGet("{id}", Name = "Get[Controller]")]
        [ProducesResponseType(typeof(ResultFailed), 400)]
        [ProducesResponseType(typeof(ResultFailed), 500)]
        public virtual async Task<ActionResult<TEntity>> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("id não pode ser nulo");
            }

            var result = await _serviceApp.Get(Guid.Parse(id));
            if (result == null)
            {
                return (ActionResult<TEntity>)BadRequest();
            }

            return (ActionResult<TEntity>)Ok(result);
        }

    }

}
