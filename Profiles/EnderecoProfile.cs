using AutoMapper;
using FilmeAPI_NET6.Data.DTOS;
using FilmeAPI_NET6.Models;

namespace FilmeAPI_NET6.Profiles;

public class EnderecoProfile:Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDTO, Endereco>(); 
        CreateMap<UpdateEnderecoDTO, Endereco>();
        CreateMap< Endereco, ReadEnderecoDTO>();
    }
}
