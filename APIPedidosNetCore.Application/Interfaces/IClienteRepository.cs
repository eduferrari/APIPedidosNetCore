using APIPedidosNetCore.Domain.Entities;

namespace APIPedidosNetCore.Application.Interfaces;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ListarTodosAsync();
    Task<Cliente> BuscarPorIdAsync(int id);
    Task AdicionarAsync(Cliente produto);
    Task AtualizarAsync(Cliente produto);
    Task DeletarAsync(Cliente id);
}