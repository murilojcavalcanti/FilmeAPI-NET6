using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Data.DTOS;

public class CreateSessaoDTO
{
    [Required]
    public int filmeId { get; set; }
    [Required]
    public int cinemaId { get; set; }


}
