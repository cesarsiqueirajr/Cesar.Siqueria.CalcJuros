using System.Threading.Tasks;

namespace CalcJuros.Queries.Juros
{
    public class TaxaQueries : ITaxaQueries
    {
        /// <summary>
        /// Leitura da base
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> ObterTaxaDeJuros()
            => 0.01M;
    }
}