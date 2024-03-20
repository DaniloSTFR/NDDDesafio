
using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Cliente.Application.ClientesApp.Commands;
using Cliente.Application.ClientesApp.Queries;

using MediatR;

namespace Cliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
            private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var query = new GetClientesQuery();
            var cliente = await _mediator.Send(query);
            return cliente != null ? Ok(cliente) : NotFound("Sem Clientes");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientes(string id)
        {
            var query = new GetClienteByIdQuery{ Id = id };
            var cliente = await _mediator.Send(query);
            return cliente != null ? Ok(cliente) : NotFound("Cliente não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(CreateClienteCommand command)
        {
            if(command == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var createdCliente = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetClientes), new { id = createdCliente.Id }, createdCliente);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(string id, UpdateClienteCommand command)
        {
            command.Id = id;
            var updatedCliente = await _mediator.Send(command);
            return updatedCliente != null ?  Ok(updatedCliente) : NotFound("Cliente não encontrado.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            var command = new DeleteClienteCommand { Id = id };
            var deletedMember = await _mediator.Send(command);

            return deletedMember != null ? Ok(deletedMember) : NotFound("Cliente não encontrado.");
        }
    }
}