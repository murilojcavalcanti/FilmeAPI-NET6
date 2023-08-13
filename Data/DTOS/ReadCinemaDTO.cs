using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Data.DTOS;

public class ReadCinemaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDTO Endereco { get; set; }
    public ICollection<ReadSessaoDTO> sessao { get; set; }
}
