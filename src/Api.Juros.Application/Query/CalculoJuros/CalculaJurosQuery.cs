using MediatR;

namespace Api.Juros.Application.Query.CalculoJuros
{
    public class CalculaJurosQuery : IRequest<CalculaJurosQueryResult>
    {
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }

        public CalculaJurosQuery() { }

        public CalculaJurosQuery(decimal valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
        }
    }
}
