using System.Threading.Tasks;
using Api.Juros.Application.Query.ShowCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Juros.Calculo.WebApi.Controllers
{
    [Route("api")]
    public partial class ShowCodeController : Controller
    {
        private readonly IMediator _mediator;

        public ShowCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("showmethecode")]
        public async Task<IActionResult> GetCalculoJuros()
        {
            var query = new ShowCodeQuery();
            var calculoJuros = await _mediator.Send(query);

            return Json(calculoJuros);
        }

    }
}
