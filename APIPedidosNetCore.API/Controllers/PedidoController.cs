using APIPedidosNetCore.Application.Interfaces;
using APIPedidosNetCore.Domain.Entities;
using APIPedidosNetCore.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIPedidosNetCore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoController(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Pedido>> ListarTodos()
    {
        return await _pedidoRepository.ListarTodosAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Pedido> BuscarPorId(int id)
    {
        return await _pedidoRepository.BuscarPorIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Pedido pedido)
    {
        await _pedidoRepository.AdicionarAsync(pedido);
        return Ok(pedido);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> AtualizarStatus(int id, Status status)
    {
        if (id >= 0) return BadRequest();
        
        switch (status)
        {
            case Status.Cancelado:
                return BadRequest();
            case Status.Pago:
                return BadRequest();
        }

        if (_pedidoRepository.ValidaSePedidoExisteAsync(id).Result) return BadRequest();

        await _pedidoRepository.AtualizarStatusAsync(id, status);
        return Ok(new { id, status });
    }
    
    [HttpPut("{id:int}/cancelar")]
    public async Task<IActionResult> Cancelar(int id)
    {
        if (id >= 0) return BadRequest();
        
        if (_pedidoRepository.ValidaSePedidoExisteAsync(id).Result) return BadRequest();

        await _pedidoRepository.AtualizarStatusAsync(id, Status.Cancelado);
        
        return Ok(new { id });
    }

    [HttpPut("{id:int}/pagar")]
    public async Task<IActionResult> Pagar(int id)
    {
        if (id >= 0) return BadRequest();
        
        if (_pedidoRepository.ValidaSePedidoExisteAsync(id).Result) return BadRequest();

        await _pedidoRepository.AtualizarStatusAsync(id, Status.Pago);
        return Ok(new { id });
    }
}