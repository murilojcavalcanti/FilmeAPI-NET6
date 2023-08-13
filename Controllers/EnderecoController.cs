using AutoMapper;
using FilmeAPI_NET6.Data;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI_NET6.Controllers;

[ApiController]
[Route("Controller")]
public class EnderecoController:ControllerBase
{
    private FilmeContext Context;
    private IMapper Mapper;
    public EnderecoController(FilmeContext _Context,IMapper _Mapper)
    {
        Context = _Context;
        Mapper = _Mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
    {
        Endereco endereco = Mapper.Map<Endereco>(enderecoDTO);
        Context.Enderecos.Add(endereco);
        Context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { id = endereco.Id },enderecoDTO);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDTO> RecuperaEnderecos()
    {
        return Mapper.Map<List<ReadEnderecoDTO>>(Context.Enderecos);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEnderecoPorId(int id)
    {
        var endereco = Context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null) return NotFound();

        ReadEnderecoDTO enderecoDto = Mapper.Map<ReadEnderecoDTO>(endereco);
        return Ok(enderecoDto);

    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(int id, [FromBody]UpdateEnderecoDTO enderecoDTO)
    {
        Endereco endereco = Context.Enderecos.FirstOrDefault(e=>e.Id==id);
        if(endereco==null) return NotFound();
        Mapper.Map(enderecoDTO, endereco);
        Context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaEndereco(int id)
    {
        var endereco = Context.Enderecos.FirstOrDefault(e=>e.Id==id);
        if (endereco==null) return NotFound();
        Context.Remove(endereco);
        Context.SaveChanges();
        return NoContent();

    }

}
