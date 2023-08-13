using AutoMapper;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;

namespace FilmeAPI_NET6.Profiles;

public class SessaoProfile:Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDTO, Sessao>();
        CreateMap< Sessao, ReadSessaoDTO>();
    }

}
