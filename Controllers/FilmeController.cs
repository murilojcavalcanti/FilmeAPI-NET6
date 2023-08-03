using AutoMapper;
using FilmeAPI_NET6.Data;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI_NET6.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext Context;
    private IMapper Mapper;
    public FilmeController(FilmeContext _Context, IMapper _Mapper)
    {
        Context = _Context;
        Mapper = _Mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public CreatedAtActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = Mapper.Map<Filme>(filmeDto);
        Context.Filmes.Add(filme);
        Context.SaveChanges();

        return CreatedAtAction
            (
            nameof(RecuperaFilmePorId), 
            new { id=filme.Id},
            filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip=0,int take=50)
    {    //esses reursos fazem com que possamos paginar o findall e assim precisamos não carregar todos os dados
        return Mapper.Map<List<ReadFilmeDto>>(Context.Filmes.Skip(skip).Take(take));
    }
    
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        Filme filme = Context.Filmes.FirstOrDefault(f=>f.Id==id);
        if (filme == null)
        {
            return NotFound();
        }
        var filmeDto = Mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = Context.Filmes.FirstOrDefault(Filme => Filme.Id == id);
        if (filme==null) return NotFound();
        Mapper.Map(filmeDto,filme);
        Context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = Context.Filmes.FirstOrDefault(Filme => Filme.Id == id);
        
        if (filme == null) return NotFound();
        
        var filmeParaAtualizar = Mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        Mapper.Map(filmeParaAtualizar, filme);
        Context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = Context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        
        Context.Remove(filme);
        Context.SaveChanges();
        return NoContent();
    }

}
