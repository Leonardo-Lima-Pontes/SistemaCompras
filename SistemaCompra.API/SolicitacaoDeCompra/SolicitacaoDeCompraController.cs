using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoDeCompraStack.Commands;

namespace SistemaCompra.API.SolicitacaoDeCompra
{
    public class SolicitacaoDeCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoDeCompraController(IMediator mediator) => _mediator = mediator;

        [HttpPut, Route("teste/atualiza-preco")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult AtualizarPreco([FromBody] RegistrarCompraCommand atualizarPrecoCommand)
        {
            _mediator.Send(atualizarPrecoCommand);
            return Ok();
        }
    }
}