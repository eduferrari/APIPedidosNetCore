namespace APIPedidosNetCore.Domain.Entities;

public enum FormaPagamento
{
    SemPagamento = 0,
    Pix = 1,
    Boleto = 2,
    CartaoCredido = 3,
    CartaoDebito = 4
}