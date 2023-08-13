using FilmeAPI_NET6.Data.DTOS;
using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="Titulo Obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage ="Genero Obrigatorio")]
    [MaxLength(50,ErrorMessage ="Genero muito grande")]
    public string Genero { get; set; }
        
    [Required]
    [Range(70,600, ErrorMessage = "Duração inválida Max:600min Min:70minn")]
    public int Duracao { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }

}
