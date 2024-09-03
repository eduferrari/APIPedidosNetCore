using APIPedidosNetCore.Application.Interfaces;
using APIPedidosNetCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIPedidosNetCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IEnumerable<Produto>> ListarTodos()
    {
        return await _produtoRepository.ListarTodosAsync();
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<Produto> BuscarPorId(int id)
    {
        return await _produtoRepository.BuscarPorIdAsync(id);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Adicionar(Produto produto)
    {
        await _produtoRepository.AdicionarAsync(produto);
        return Ok(produto);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Atualizar(int id, Produto produto)
    {
        if (id != produto.Id) return BadRequest();

        await _produtoRepository.AtualizarAsync(produto);
        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Deletar(int id)
    {
        await _produtoRepository.DeletarAsync(id);
        return Ok();
    }
}