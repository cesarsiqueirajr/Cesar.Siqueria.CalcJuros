using MediatR;

namespace CalcJuros.Services.Api.App.CalcularJuros
{
    public class CalculaJurosCommand : IRequest<decimal>
    {
        public decimal ValorInicial { get; private set; }

        public int QuantidadeMeses { get; private set; }

        public decimal TaxaJuros { get; private set; }

        #region Factory

        public static class Factory
        {
            public static CalculaJurosCommand Create(decimal valorInicial, int quantidadeMeses, decimal taxaJuros)
                => new CalculaJurosCommand()
                {
                    ValorInicial = valorInicial,
                    QuantidadeMeses = quantidadeMeses,
                    TaxaJuros = taxaJuros
                };
        }

        #endregion

    }
}