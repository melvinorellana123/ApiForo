using ApiForo.Models;
using ApiForo.Models.Dto;

namespace ApiForo.Repository.IRepository;

public interface IComentarioRepositorio
{
    IEnumerable<Comentario> getComentarios();
    Comentario GetComentario(int comentarioId);
    bool ExisteComentario(int id);
    bool CrearComentario(string contenido);
    bool CrearComentario(string contenido, int comentarioPadreId);
    bool ActualizarComentario(ComentarioActualizarDto comentarioActualizarDto);
    bool BorrarComentario(int id);
    
    bool Guardar();
}