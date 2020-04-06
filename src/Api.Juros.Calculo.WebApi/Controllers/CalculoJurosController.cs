using System.Threading.Tasks;
using Api.Juros.Application.Query.CalculoJuros;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Juros.Calculo.WebApi.Controllers
{
    [Route("api")]
    public partial class CalculoJurosController : Controller
    {
        private readonly IMediator _mediator;

        public CalculoJurosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("calculoJuros")]
        public async Task<IActionResult> GetCalculoJuros([FromQuery]CalculaJurosQuery calculo)
        {
            var query = new CalculaJurosQuery { Meses = calculo.Meses, ValorInicial = calculo.ValorInicial };
            var calculoJuros = await _mediator.Send(query);

            return Json(calculoJuros);
        }

    }
}
