using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CalcJuros.Services.Api.App.CalcularJuros;
using CalcJuros.Queries.Juros;

namespace CalcJuros.Services.Api.Controllers
{
    [Route("api/v1/[controller]"), ApiController]
    public class CalcularJurosController : ControllerBase
    {
        #region Private members
        private readonly IMediator _mediator;
        private readonly ITaxaQueries _taxaQueries;
        #endregion

        #region Constructor
        public CalcularJurosController(IMediator mediator, ITaxaQueries taxaQueries)
        {
            _mediator = mediator;
            _taxaQueries = taxaQueries;
        }
        #endregion

        /// <summary>
        /// Cálculo de juros compostos
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("calculajuros/{valorInicial:decimal}/{quantidadeMeses:int}")]
        [ProducesResponseType(typeof(ResultMessageResponse<decimal>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CalculaJuros(decimal valorInicial, int quantidadeMeses)
        {
            var taxaJuros = await _taxaQueries.ObterTaxaDeJuros();
            ResultMessageResponse<decimal> result = await _mediator.Send(CalculaJurosCommand.Factory.Create(valorInicial, quantidadeMeses, taxaJuros));
            return Ok(result);
        }

        /// <summary>
        /// Show me the code
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("showmethecode")]
        [ProducesResponseType(typeof(ResultMessageResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ShowMeTheCode()
            => Ok(new ResultMessageResponse<string>("https://github.com/cesarsiqueirajr/Cesar.Siqueria.CalcJuros"));
    }
}