using AutoMapper;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;

namespace FilmeAPI_NET6.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDTO, Cinema>(); 
        CreateMap<Cinema, ReadCinemaDTO>()
            .ForMember(cinemaDto=>cinemaDto.Endereco,
            opt=>opt.MapFrom(cinema=>cinema.Endereco))
            .ForMember(cinemaDto=>cinemaDto.sessao,
            opt=>opt.MapFrom(cinema=>cinema.Sessoes));
        CreateMap<UpdateCinemaDTO, Cinema>();
    }
}
