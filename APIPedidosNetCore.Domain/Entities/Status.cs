namespace APIPedidosNetCore.Domain.Entities;

public enum Status
{
    Ativo = 1,
    Inativo = 2,
    Deletado = 3,
    Recebido = 4,
    AguardandoPagamento = 5,
    Pago = 6,
    Processando = 7,
    Cancelado = 8
}