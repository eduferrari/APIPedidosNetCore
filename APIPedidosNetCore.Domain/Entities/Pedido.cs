using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APIPedidosNetCore.Domain.Entities;

public class Pedido
{
    [Key] public long PedidoId { get; set; }
    [Required]
    public long ClienteId { get; set; }
    [Required]
    public List<Produto> Produtos { get; set; }
    [DataType(DataType.Date)]
    public DateTime DataCompra { get; set; } = DateTime.MinValue;
    [DataType(DataType.Date)]
    public DateTime DataPagamento { get; set; } = DateTime.MinValue;
    [Required]
    [Precision(14, 2)] 
    public decimal ValorPedido { get; set; } = 0;
    [Required]
    [Precision(14, 2)]
    public decimal ValorFrete { get; set; } = 0;
    [Required]
    [Precision(14, 2)]
    public decimal ValorTotal { get; set; } = 0;
    [Required]
    public FormaPagamento FormaPagamento { get; set; } = FormaPagamento.SemPagamento;
    [Required]
    public Status Status { get; set; } = Status.Processando;
}