using APIPedidosNetCore.Application.Interfaces;
using APIPedidosNetCore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIPedidosNetCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Usuario>> ListarTodos()
    {
        return await _usuarioRepository.ListarTodosAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Usuario> BuscarPorId(int id)
    {
        return await _usuarioRepository.BuscarPorIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Usuario usuario)
    {
        var validaUsuarioExistente = await _usuarioRepository.VerificaSeUsuarioJaCadastradoAsync(usuario.Email);
        if (validaUsuarioExistente) return BadRequest();

        await _usuarioRepository.AdicionarAsync(usuario);
        return Ok(usuario);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, Usuario usuario)
    {
        if (id != usuario.Id) return BadRequest();

        await _usuarioRepository.AtualizarAsync(usuario);
        return Ok(usuario);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Deletar(int id)
    {
        await _usuarioRepository.DeletarAsync(id);
        return Ok();
    }
}