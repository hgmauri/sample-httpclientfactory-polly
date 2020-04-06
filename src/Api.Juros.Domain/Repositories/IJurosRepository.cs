using Api.Juros.Domain.Entities;

namespace Api.Juros.Domain.Repositories
{
    public interface IJurosRepository
    {
        CalculoJuros PostCalculaJuros(decimal valorInicial, int meses, double taxaJuros);
        TaxaJuros GetTaxaDeJuros();
    }
}
