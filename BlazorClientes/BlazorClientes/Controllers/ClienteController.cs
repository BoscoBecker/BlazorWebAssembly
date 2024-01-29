using BlazorClientes.Shared.Entities;
using BlazorClientes.Shared.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace BlazorClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("Clientes")]
        public async Task<ActionResult<List<Cliente>>> GetAllClientesAsync() {
            var clientes = await _clienteRepository.GetAllCLientesAsync();
            return Ok(clientes);
        }
        [HttpGet("Cliente/{id}")]
        public async Task<ActionResult<List<Cliente>>> GetSingleClienteAsync(int id) {
            var cliente = await _clienteRepository.GetCLienteByID(id);
            return Ok(cliente);
        }
        [HttpPost("Add-Cliente")]
        public async Task<ActionResult<List<Cliente>>> AddClienteAsyc(Cliente model) {
            var cliente = await _clienteRepository.AddClienteAsync(model);
            return Ok(cliente);
        }

        [HttpPut("Update-Cliente")]
        public async Task<ActionResult<List<Cliente>>> UpdateClienteAsync(Cliente model){
            var cliente = await _clienteRepository.UpdateClienteAsync(model);
            return Ok(cliente);
        }
        [HttpDelete("Delete-Cliente/{id}")]
        public async Task<ActionResult<List<Cliente>>> DeleteClienteAsync(int id) {
            var cliente = await _clienteRepository.DeleteClienteAsync(id);
            return Ok(cliente);
        }

    }
}
