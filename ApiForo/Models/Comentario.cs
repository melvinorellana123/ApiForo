using System.ComponentModel.DataAnnotations;

namespace ApiForo.Models;

public class Comentario
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Contenido { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool Editado { get; set; }
    
    public int?  ComentarioPadreId { get; set; }
    public Comentario ComentarioPadre { get; set; }
    public ICollection<Comentario> Hijos { get; set; } = null;
}