using System.Threading;
using System.Threading.Tasks;
using Api.Juros.Domain.Repositories;
using MediatR;

namespace Api.Juros.Application.Query.TaxaJuros
{
    public class TaxaJurosQueryHandler : IRequestHandler<TaxaJurosQuery, TaxaJurosQueryResult>
	{
        private readonly IJurosRepository _jurosRepository;

        public TaxaJurosQueryHandler(IJurosRepository jurosRepository)
        {
            _jurosRepository = jurosRepository;
        }

        public async Task<TaxaJurosQueryResult> Handle(TaxaJurosQuery request, CancellationToken cancellationToken)
        {
            var output = _jurosRepository.GetTaxaDeJuros();

            var map = new TaxaJurosQueryResult(output.Taxa);

            return map;
		}
	}
}
