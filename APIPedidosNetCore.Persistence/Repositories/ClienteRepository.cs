using APIPedidosNetCore.Application.Interfaces;
using APIPedidosNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIPedidosNetCore.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> ListarTodosAsync()
    {
        return await _context.Clientes.Where(x => x.Status != Status.Deletado).ToListAsync();
    }

    public async Task<Cliente> BuscarPorIdAsync(int id)
    {
        return await _context.Clientes.Where(x => x.Status != Status.Deletado && x.Id == id).FirstOrDefaultAsync();
    }

    public async Task AdicionarAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public Task DeletarAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task DeletarAsync(Cliente id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente is null)
        {
            cliente.Status = Status.Deletado;

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<bool> VerificaSeClienteJaCadastradoAsync(string email)
    {
        return await _context.Clientes.Where(r=> r.Email == email && r.Status != Status.Deletado).AnyAsync();
    }
}