using APIPedidosNetCore.Domain.Entities;

namespace APIPedidosNetCore.Application.Interfaces;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> ListarTodosAsync();
    Task<Pedido> BuscarPorIdAsync(int id);
    Task AdicionarAsync(Pedido produto);
    Task AtualizarStatusAsync(int id, Status status);
    Task DeletarAsync(int id);
    Task<bool> ValidaSePedidoExisteAsync(int id);
}