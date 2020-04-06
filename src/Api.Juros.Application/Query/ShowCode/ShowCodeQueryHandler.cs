using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Api.Juros.Application.Query.ShowCode
{
    public class ShowCodeQueryHandler : IRequestHandler<ShowCodeQuery, ShowCodeQueryResult>
	{
        public readonly IConfiguration _configuration;

        public ShowCodeQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ShowCodeQueryResult> Handle(ShowCodeQuery request, CancellationToken cancellationToken)
        {
            var url = _configuration.GetSection("UrlGitHub")?.Value;

            return new ShowCodeQueryResult{Url = url};
		}
	}
}
