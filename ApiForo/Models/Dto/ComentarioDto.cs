using System.ComponentModel.DataAnnotations;

namespace ApiForo.Models.Dto;

public class ComentarioDto
{
    public int Id { get; set; }
    public string Contenido { get; set; }
    public bool Editado { get; set; }
    public int?  ComentarioPadreId { get; set; }
    public  ComentarioDto ComentarioPadre { get; set; }
    public  List<ComentarioDto> Hijos { get; set; } = null;
}