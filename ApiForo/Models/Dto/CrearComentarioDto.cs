namespace ApiForo.Models.Dto;

public class CrearComentarioDto
{
    public string Contenido { get; set; }
    public int?  ComentarioPadreId { get; set; }
    public Comentario ComentarioPadre { get; set; }
    public ICollection<Comentario> Hijos { get; set; } = null;
}