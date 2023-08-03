using System.ComponentModel.DataAnnotations;

namespace FilmeAPI_NET6.Data.DTOS;

public class ReadFilmeDto
{
    public string Titulo { get; set; }

    public string Genero { get; set; }

    public string Lancamento { get; set; }

    public int Duracao { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
