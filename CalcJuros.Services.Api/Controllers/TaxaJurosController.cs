using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalcJuros.Queries.Juros;

namespace CalcJuros.Services.Api.Controllers
{
    [Route("api/v1/[controller]"), ApiController]
    public class TaxaJurosController : ControllerBase
    {
        #region Private members
        private readonly ITaxaQueries _taxa;
        #endregion

        #region Constructor
        public TaxaJurosController(ITaxaQueries taxa)
            => _taxa = taxa; 
        #endregion

        /// <summary>
        /// Obtem taxa de juros
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("taxaJuros")]
        [ProducesResponseType(typeof(ResultMessageResponse<decimal>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterTaxaDeJuros()
        {
            ResultMessageResponse<decimal> result = await _taxa.ObterTaxaDeJuros();
            return Ok(result);
        }
    }
}