using System.Threading.Tasks;

namespace Api.Juros.Infrastructure.External
{
    public interface ITaxaJurosExternalClient
    {
        Task<double> GetTaxaJuros();
    }
}
