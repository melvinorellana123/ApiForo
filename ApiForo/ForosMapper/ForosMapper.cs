using ApiForo.Models;
using ApiForo.Models.Dto;
using AutoMapper;

namespace ApiForo.ForosMapper;

public class ForosMapper : Profile
{
    public ForosMapper()
    {
        CreateMap<Comentario, ComentarioDto>().ReverseMap();
        CreateMap<Comentario, CrearComentarioDto>().ReverseMap();
    }
}