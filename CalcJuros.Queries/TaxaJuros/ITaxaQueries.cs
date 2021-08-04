using System.Threading.Tasks;

namespace CalcJuros.Queries.Juros
{
    public interface ITaxaQueries
    {
        Task<decimal> ObterTaxaDeJuros();
    }
}