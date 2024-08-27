using APIPedidosNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIPedidosNetCore.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ApiPedidos.db");
    }
}