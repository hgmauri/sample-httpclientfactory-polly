namespace Api.Juros.Application.Query.TaxaJuros
{

    public class TaxaJurosQueryResult
    {
        public TaxaJurosQueryResult(double taxa) => Taxa = taxa;

        public double Taxa{ get; set; }
    }
}