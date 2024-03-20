
using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _unitOfWork.ClientesRepository.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientes(string id)
        {
            var clientes = await _unitOfWork.ClientesRepository.GetClienteById(id);
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(Clientes clientes)
        {
            if(clientes == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var createCliente = await _unitOfWork.ClientesRepository.AddCliente(clientes);
            await _unitOfWork.CommitAsync();

            return CreatedAtAction(nameof(GetClientes), new { id = createCliente.Id }, createCliente);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(string id, Clientes upCliente)
        {
            var existingCliente = await _unitOfWork.ClientesRepository.GetClienteById(id);

            if(existingCliente is null){
                return NotFound("Cliente não encontrado"); 
            }
            existingCliente.Update( upCliente.Nome, 
                                    upCliente.CPF, 
                                    upCliente.Sexo, 
                                    upCliente.Telefone, 
                                    upCliente.Email, 
                        upCliente.DataNascimento,  upCliente.Observacao) ;

            await _unitOfWork.CommitAsync();
            return Ok("Id:"+id+" atualizado com Sucesso!");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            var deleteCliente = await _unitOfWork.ClientesRepository.DeleteMember(id);
            
            if(deleteCliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            await _unitOfWork.CommitAsync();
            return Ok(deleteCliente);
        }
    }
}