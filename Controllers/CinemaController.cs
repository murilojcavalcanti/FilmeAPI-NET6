using AutoMapper;
using FilmeAPI_NET6.Data;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI_NET6.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController:ControllerBase
{
    private FilmeContext Context;
    private IMapper Mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDto)
    {
        Cinema cinema = Mapper.Map<Cinema>(cinemaDto);
        Context.Cinemas.Add(cinema);
        Context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorID), new { Id = cinema.Id }, cinemaDto);
    }


    [HttpGet]
    public IEnumerable<ReadCinemaDTO> RecuperaCinemas([FromQuery] int? enderecoId=null)
    {
        var cinemas = Mapper.Map<ICollection<ReadCinemaDTO>>(Context.Cinemas.ToList());
        if (enderecoId == null) return cinemas;
        //usando SQLRAW

        //usando linq
        /* 
        var cinemaPorEndereco = cinemas.Where(cinemas => cinemas.Endereco.Id == enderecoId); 
        */
          
        return Mapper.Map<List<ReadCinemaDTO>>(Context.Cinemas
            .FromSqlRaw($"SELECT Id,Nome,EnderecoId FROM cinemas WHERE cinemas.EnderecoId = {enderecoId}").ToList());
        //return cinemaPorEndereco;
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorID(int id)
    {
        var cinema = Context.Cinemas.FirstOrDefault(c=>c.Id==id);
        if (cinema == null) return NotFound();
        var cinemaDTO = Mapper.Map<ReadCinemaDTO>(cinema);
        return Ok(cinemaDTO);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
    {
        Cinema cinema = Context.Cinemas.FirstOrDefault(c=>c.Id ==id);
        if(cinema==null) return NotFound();

        Mapper.Map(cinemaDto, cinema);
        Context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        Cinema cinema = Context.Cinemas.FirstOrDefault(c => c.Id == id);
        
        if (cinema == null) return NotFound();
        
        Context.Remove(cinema);
        Context.SaveChanges();
        return NoContent();
    }


}
