using APIPedidosNetCore.Application.Interfaces;
using APIPedidosNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIPedidosNetCore.Persistence.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> ListarTodosAsync()
    {
        return await _context.Pedidos.Where(x => x.Status != Status.Deletado).ToListAsync();
    }

    public async Task<Pedido> BuscarPorIdAsync(int id)
    {
        return await _context.Pedidos.Where(x => x.Status != Status.Deletado && x.PedidoId == id).FirstOrDefaultAsync();
    }

    public async Task AdicionarAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarStatusAsync(int id, Status status)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido is null)
        {
            pedido.Status = status;

            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
    public async Task DeletarAsync(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido is null)
        {
            pedido.Status = Status.Deletado;

            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
    
    public Task<bool> ValidaSePedidoExisteAsync(int id)
    {
        return Task.FromResult(ListarTodosAsync().Result.Where(x => x.PedidoId == id).Any());
    }
}