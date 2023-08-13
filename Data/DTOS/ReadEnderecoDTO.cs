using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Data.DTOS;

public class ReadEnderecoDTO
{

    public int Id { get; set; }
    public string Logradouro { get; set; }

    public int Numero { get; set; }
}
