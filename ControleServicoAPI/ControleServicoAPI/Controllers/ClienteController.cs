using ControleServicoAPI.Models;
using ControleServicoAPI.services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/clientes")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> GetAllClientes()
    {
        var clientes = await _clienteService.GetAllClientes();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetSingleCliente(int id)
    {
        var cliente = await _clienteService.GetSingleCliente(id);

        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<List<Cliente>>> AddCliente([FromBody] Cliente cliente)
    {
        await _clienteService.AddCliente(cliente);
        var clientes = await _clienteService.GetAllClientes();
        return Ok(clientes);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Cliente>>> UpdateCliente(int id, [FromBody] Cliente clienteAtualizado)
    {
        var clienteExistente = await _clienteService.GetSingleCliente(id);

        if (clienteExistente == null)
            return NotFound();

        await _clienteService.UpdateCliente(id, clienteAtualizado);
        var clientes = await _clienteService.GetAllClientes();
        return Ok(clientes);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Cliente>>> DeleteCliente(int id)
    {
        var clienteExistente = await _clienteService.GetSingleCliente(id);

        if (clienteExistente == null)
            return NotFound();

        await _clienteService.DeleteCliente(id);
        var clientes = await _clienteService.GetAllClientes();
        return Ok(clientes);
    }
}
