namespace Api.Juros.Domain.Entities
{
    public class CalculoJuros
    {
        public string Resultado { get; }

        public CalculoJuros() { }
        public CalculoJuros(string resultado) => Resultado = resultado;
    }
}
