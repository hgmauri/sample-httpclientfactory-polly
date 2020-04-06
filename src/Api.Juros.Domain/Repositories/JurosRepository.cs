using System;
using Api.Juros.Domain.Entities;

namespace Api.Juros.Domain.Repositories
{
    public class JurosRepository : IJurosRepository
    {
        public CalculoJuros PostCalculaJuros(decimal valorInicial, int meses, double taxaJuros)
        {
            try
            {
                var mesesDouble = (double)meses;
                var taxa = taxaJuros;

                var potencia = Math.Pow(1 + taxa, mesesDouble);

                var resultado = valorInicial * (decimal)potencia;

                var result = new CalculoJuros($"{resultado:N2}");

                return result;
            }
            catch
            {
                return null;
            }
        }

        public TaxaJuros GetTaxaDeJuros()
        {
            return new TaxaJuros(.01);
        }
    }
}
