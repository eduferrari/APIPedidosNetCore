using System.ComponentModel.DataAnnotations;

namespace APIPedidosNetCore.Domain.Entities;

public class Usuario
{
    [Key]
    public long Id { get; set; }
    [Required]
    [MaxLength(90)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(120)]
    public string Email { get; set; }
    [Required]
    [MaxLength(90)]
    public string Senha { get; set; }
    [Required]
    [MaxLength(500)]
    public string RegrasAcesso { get; set; }
    [Required]
    public Status Status { get; set; } = Status.Ativo;
}