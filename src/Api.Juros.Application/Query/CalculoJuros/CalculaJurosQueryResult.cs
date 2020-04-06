namespace Api.Juros.Application.Query.CalculoJuros
{

    public class CalculaJurosQueryResult
    {
        public CalculaJurosQueryResult(string resultado) => Resultado = resultado;

        public string Resultado { get; set; }
    }
}