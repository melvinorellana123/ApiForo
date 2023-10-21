using ApiForo.Models;

namespace ApiForo.Repository.IRepository;

public interface IComentarioRepositorio
{
    IEnumerable<Comentario> GetComentarios();
    Comentario GetComentario(int comentarioId);
    bool ExisteComentario(int id);
    bool CrearComentario(Comentario comentario);
   
    bool ActualizarComentario(Comentario comentario);
    bool BorrarComentario(Comentario comentario);
    
    bool Guardar();
}