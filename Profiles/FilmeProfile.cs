using AutoMapper;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;

namespace FilmeAPI_NET6.Profiles;

public class FilmeProfile:Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>(); 
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme,UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
