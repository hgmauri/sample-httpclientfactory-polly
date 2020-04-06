namespace Api.Juros.Domain.Entities
{
    public class TaxaJuros
    {
        public double Taxa { get; }

        public TaxaJuros() { }
        public TaxaJuros(double taxa) => Taxa = taxa;
    }
}
