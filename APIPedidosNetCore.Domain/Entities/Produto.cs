using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APIPedidosNetCore.Domain.Entities;

public class Produto
{
    [Key]
    public long Id { get; set; }
    [Required]
    [MaxLength(90)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(50000)]
    public string Descricao { get; set; }
    [Required]
    [Precision(14, 2)]
    public decimal Valor { get; set; }
    [Required]
    public Status Status { get; set; } = Status.Ativo;
}