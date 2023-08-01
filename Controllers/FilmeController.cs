using FilmeAPI_NET6.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI_NET6.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController
{
    private static List<Filme> filmes = new();
    [HttpPost]
    public void AddFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);

        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }

}
