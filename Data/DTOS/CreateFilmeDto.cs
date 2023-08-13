using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Data.DTOS;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "Titulo Obrigatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Genero Obrigatorio")]
    [StringLength(50, ErrorMessage = "Genero muito grande")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "Duração inválida Max:600min Min:70minn")]
    public int Duracao { get; set; }

}
