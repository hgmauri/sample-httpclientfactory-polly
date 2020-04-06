using System.Threading.Tasks;
using Api.Juros.Application.Query.TaxaJuros;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Juros.Taxa.WebApi.Controllers
{
    [Route("api")]
    public partial class TaxaJurosController : Controller
    {
        private readonly IMediator _mediator;

        public TaxaJurosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("taxaJuros")]
        public async Task<IActionResult> GetTaxaJuros()
        {
            var query = new TaxaJurosQuery();
            var taxa = await _mediator.Send(query);

            return Json(taxa);
        }

    }
}
