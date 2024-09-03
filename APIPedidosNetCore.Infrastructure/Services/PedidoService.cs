using APIPedidosNetCore.Application.Interfaces;

namespace APIPedidosNetCore.Infrastructure.Services;

public class PedidoService
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }
}