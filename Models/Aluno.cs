using System.ComponentModel.DataAnnotations;

namespace MVCteste.Models;

public class Aluno
{
    [Key] 
    public int Id { get; set; }

    [Required] 
    public string Nome { get; set; } = string.Empty;

    [Range(1, 120, ErrorMessage = "A idade deve estar entre 1 e 120 anos.")]
    public int Idade { get; set; }

    [Required, EmailAddress] 
    public string Email { get; set; } = string.Empty;

    [Required, MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
    public string Senha { get; set; } = string.Empty;

    [Required]
    public string Plano { get; set; } = string.Empty;
}
