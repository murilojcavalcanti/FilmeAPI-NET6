using AutoMapper;
using FilmeAPI_NET6.Data;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmeAPI_NET6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private FilmeContext Context;
        private IMapper Mapper;
        public SessaoController(FilmeContext _Context, IMapper _Mapper)
        {
            Context = _Context;
            Mapper = _Mapper;
        }

        
        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            var sessao = Mapper.Map<Sessao>(sessaoDTO);
            Context.Sessoes.Add(sessao);
            Context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new {filmeId=sessao.FilmeId,cinemaId=sessao.CinemaId},sessao);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDTO> RecuperaSessoes()
        {
            return Mapper.Map<List<ReadSessaoDTO>>(Context.Sessoes.ToList());
        }

        [HttpGet("{filmeid}/{cinemaid}")]
        public IActionResult RecuperaSessaoPorId(int filmeId, int cinemaId)
        {
            var sessao = Context.Sessoes.FirstOrDefault(s => s.FilmeId == filmeId 
            && s.CinemaId==cinemaId) ;
            
            if(sessao==null) return NotFound();
            
            var sessaDTO = Mapper.Map<ReadSessaoDTO>(sessao);
            return Ok(sessao);
        }
    }
}
