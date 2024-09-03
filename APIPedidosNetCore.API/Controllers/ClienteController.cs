using APIPedidosNetCore.Application.Interfaces;
using APIPedidosNetCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIPedidosNetCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<Cliente>> ListarTodos()
    {
        return await _clienteRepository.ListarTodosAsync();
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<Cliente> BuscarPorId(int id)
    {
        return await _clienteRepository.BuscarPorIdAsync(id);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Adicionar(Cliente cliente)
    {
        var validaUsuarioExistente = await _clienteRepository.VerificaSeClienteJaCadastradoAsync(cliente.Email);
        if (validaUsuarioExistente) return BadRequest();

        await _clienteRepository.AdicionarAsync(cliente);
        return Ok(cliente);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateUser(int id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest();

        await _clienteRepository.AtualizarAsync(cliente);
        return Ok(cliente);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _clienteRepository.DeletarAsync(id);
        return Ok();
    }
}