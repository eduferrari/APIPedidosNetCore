using APIPedidosNetCore.Domain.Entities;

namespace APIPedidosNetCore.Application.Interfaces;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ListarTodosAsync();
    Task<bool> VerificaSeClienteJaCadastradoAsync(string email);
    Task<Cliente> BuscarPorIdAsync(int id);
    Task AdicionarAsync(Cliente produto);
    Task AtualizarAsync(Cliente produto);
    Task DeletarAsync(int id);
}