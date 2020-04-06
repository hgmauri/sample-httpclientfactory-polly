using System.Threading;
using System.Threading.Tasks;
using Api.Juros.Domain.Repositories;
using Api.Juros.Infrastructure.External;
using MediatR;

namespace Api.Juros.Application.Query.CalculoJuros
{
	public class CalculoJurosQueryHandler : IRequestHandler<CalculaJurosQuery, CalculaJurosQueryResult>
    {
        private readonly IJurosRepository _jurosRepository;
        private readonly ITaxaJurosExternalClient _taxaJurosExternalClient;

        public CalculoJurosQueryHandler(IJurosRepository jurosRepository, ITaxaJurosExternalClient taxaJurosExternalClient)
        {
            _jurosRepository = jurosRepository;
            _taxaJurosExternalClient = taxaJurosExternalClient;
        }

        public async Task<CalculaJurosQueryResult> Handle(CalculaJurosQuery request, CancellationToken cancellationToken)
        {
            var taxaJuros = await _taxaJurosExternalClient.GetTaxaJuros();

            var result = _jurosRepository.PostCalculaJuros(request.ValorInicial, request.Meses, taxaJuros);

            var query = new CalculaJurosQueryResult(result.Resultado);

            return query;
        }
    }
}
